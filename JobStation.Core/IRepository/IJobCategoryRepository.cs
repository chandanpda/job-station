using JobStation.Core.Domain;
using JobStation.Dto;
using JobStation.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobStation.Core.IRepository
{
    public interface IJobCategoryRepository :IRepository<JobCategory>
    {
        Task<List<JobCategoryDto>> GetAllAsync(string q = "");
        Task<JobCategoryListingResponseDto> GetAllWithPagination(JobCategoryListParams p);
    }
}
