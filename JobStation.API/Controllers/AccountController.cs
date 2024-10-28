using AutoMapper;
using JobStation.Core;
using JobStation.Core.Domain;
using JobStation.Dto;
using JobStation.Model;
using JobStation.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace JobStation.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IConfiguration configuration;
        private readonly IunitOfWork unitOfWork;
        private readonly IMapper mapper;

        public AccountController(UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IConfiguration configuration,
            IunitOfWork unitOfWork,
            IMapper mapper)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.configuration = configuration;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginModel model)
        {
            var user = await userManager.FindByNameAsync(model.Email);
            if (user == null)
                return Unauthorized();

            //if (!user.IsActive)
            //    return Unauthorized();

            var result = await userManager.CheckPasswordAsync(user, model.Password);
            if (!result)
                return Unauthorized();


            var userRoles = await userManager.GetRolesAsync(user);

            var authClaims = new List<Claim>
                {
                new Claim(JwtRegisteredClaimNames.Jti, user.Id),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim("UserName", user.UserName)
                };

            foreach (var userRole in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, userRole));
            }

            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: configuration["JWT_ValidIssuer"],
                audience: configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(24),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
            );

            var tokenAsString = new JwtSecurityTokenHandler().WriteToken(token);

            HttpContext.Response.Cookies.Append("access-token", tokenAsString, new CookieOptions
            {
                HttpOnly = true,
                Expires = token.ValidTo,
                Secure = true,
                SameSite = SameSiteMode.None
            });

            HttpContext.Response.Cookies.Append("user-id", user.Id, new CookieOptions
            {
                HttpOnly = true,
                Expires = token.ValidTo,
                Secure = true,
                SameSite = SameSiteMode.None
            });

            var updatedUser = await unitOfWork.UserRepository.GetById(user.Id);
            if (updatedUser != null)
            {
                updatedUser.Token = tokenAsString;
            }
            return StatusCode(StatusCodes.Status200OK, new
            {
                token = tokenAsString,
                expiration = token.ValidTo,
                user = updatedUser
            });
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(RegisterModel model)
        {
            var role = await roleManager.FindByNameAsync(model.RoleName);
            if (role == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new Response<RegisterModel>()
                {
                    Success = false,
                    ErrorCode = ErrorCode.ERROR_3,
                    Message = "",
                    Errors = new List<string> { "Invalid role" }
                });
            }

            var user = new ApplicationUser
            {
                UserName = model.Email,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber
            };

            var result = await userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new Response<RegisterModel>()
                {
                    Success = false,
                    ErrorCode = ErrorCode.ERROR_7,
                    Message = "",
                    Errors = AddErrors(result)
                });
            }

            //add user to role
            await userManager.AddToRoleAsync(user, model.RoleName);

            var createdUser = mapper.Map<ApplicationUserDto>(user);
            return StatusCode(StatusCodes.Status201Created, new Response<ApplicationUserDto>(createdUser));
        }

        private List<string> AddErrors(IdentityResult result)
        {
            var errors = new List<string>();
            foreach (var error in result.Errors)
            {
                errors.Add(error.Description);
            }
            return errors;
        }
    }
}
