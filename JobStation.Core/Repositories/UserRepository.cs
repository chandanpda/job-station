using JobStation.Core.Domain;
using JobStation.Core.IRepository;
using JobStation.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobStation.Core.Repositories
{
    public class UserRepository: Repository<ApplicationUser> , IUserRepository
    {
       
        private readonly AppDbContext context;

        public UserRepository(AppDbContext context)
            : base(context)
        {
            this.context = context;
        }


        public async Task<UserDto> GetById(string userId)
        {
            var users = _context.Users.Where(e => e.Id == userId).AsQueryable().AsNoTracking();
            var roles = _context.Roles.AsQueryable().AsNoTracking();
            var userRoles = _context.UserRoles.AsQueryable().AsNoTracking();

            var query = from user in users
                        join userRole in userRoles on user.Id equals userRole.UserId
                        join role in roles on userRole.RoleId equals role.Id
                        select (new UserDto
                        {
                            Id = user.Id,
                            UserName = user.UserName,
                            NormalizedUserName = user.NormalizedUserName,
                            Email = user.Email,
                            NormalizedEmail = user.NormalizedEmail,
                          
                            PhoneNumber = user.PhoneNumber,
                            PhoneNumberConfirmed = user.PhoneNumberConfirmed,
                            TwoFactorEnabled = user.TwoFactorEnabled,
                          
                            LockoutEnd = user.LockoutEnd,
                            LockoutEnabled = user.LockoutEnabled,
                            AccessFailedCount = user.AccessFailedCount,
                           
                            Role = new RoleDto
                            {
                                Id = role.Id,
                                Name = role.Name
                            }
                        });


            var result = await query.FirstOrDefaultAsync();

            return result;
        }

        public async Task<ApplicationUser> GetByUserId(string id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(e => e.Id == id);
            return user;
        }
    }
}
