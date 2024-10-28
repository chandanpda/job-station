using AutoMapper;
using JobStation.Core;
using JobStation.Core.Domain;
using JobStation.Dto;
using JobStation.Model;
using JobStation.Parameters;
using JobStation.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobStation.API.Controllers
{
    
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly IunitOfWork unitOfWork;
        private readonly IMapper mapper;

        public CategoryController(IunitOfWork unitOfWork,
            IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }



        [HttpGet]
        public async Task<IActionResult> Get(string q = "")
        {
            var categoryList = await unitOfWork.JobCategory.GetAllAsync(q);
            return Ok(new Response<List<JobCategoryDto>>(categoryList));
        }

        
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll([FromQuery] JobCategoryListParams parameter)
        {
            var categories = await unitOfWork.JobCategory.GetAllWithPagination(parameter);
            return StatusCode(StatusCodes.Status200OK, new Response<JobCategoryListingResponseDto>(categories));
        }

        [HttpGet("GetByGuid/{UniqueGuid}")]
        public async Task<IActionResult> GetByGuid(string UniqueGuid)
        {
            var category = await unitOfWork.JobCategory.FirstOrDefaultAsync(e => e.UniqueGuid == UniqueGuid);
            var categoryResponse = mapper.Map<JobCategoryDto>(category);
            return StatusCode(StatusCodes.Status200OK, new Response<JobCategoryDto>(categoryResponse));
        }

        [HttpPost]
        public async Task<IActionResult> Post(JobCategoryModel model)
        {
           

            var category = mapper.Map<JobCategory>(model);
            category.CreatedOn = DateTime.Now;
            category.UpdatedOn = DateTime.Now;

            //if (model.Default)
            //{
            //    var defaultCategories = await unitOfWork.BlogCategory.FindAsync(e => e.Default == true);
            //    if (defaultCategories != null && defaultCategories.Count > 0)
            //    {
            //        foreach (var item in defaultCategories)
            //            item.Default = false;

            //        unitOfWork.BlogCategory.UpdateRange(defaultCategories);
            //        await unitOfWork.SaveChangesAsync();
            //    }
            //}

            unitOfWork.JobCategory.Add(category);
            var result = await unitOfWork.SaveChangesAsync();
            if (result > 0)
            {
               

                return StatusCode(StatusCodes.Status201Created, new Response<JobCategoryDto>(mapper.Map<JobCategoryDto>(category)));
            }


            return StatusCode(StatusCodes.Status400BadRequest);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, JobCategoryModel model)
        {
            var category = await unitOfWork.JobCategory.FirstOrDefaultAsync(e => e.Id == id);
            if (category == null)
                return CategoryNotFound();            

            var oldValue = category;

            category.CategoryName = model.CategoryName;    
            category.UpdatedOn = DateTime.Now;           

            unitOfWork.JobCategory.Update(category);
            var result = await unitOfWork.SaveChangesAsync();
            if (result > 0)
            {               
                return StatusCode(StatusCodes.Status200OK, new Response<JobCategoryDto>(mapper.Map<JobCategoryDto>(category)));
            }

            return StatusCode(StatusCodes.Status400BadRequest);
        }

        [NonAction]
        public ObjectResult CategoryNotFound()
        {
            return StatusCode(StatusCodes.Status404NotFound, new Response<JobCategoryModel>()
            {
                Success = false,
                ErrorCode = ErrorCode.ERROR_5,
                Message = "Job category not found",
                Errors = new List<string> { "Job category not found" }
            });
        }
    }
}
