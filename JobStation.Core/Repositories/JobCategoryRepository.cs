using JobStation.Core.Domain;
using JobStation.Core.IRepository;
using JobStation.Dto;
using JobStation.Parameters;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobStation.Core.Repositories
{
    public class JobCategoryRepository : Repository<JobCategory>, IJobCategoryRepository
    {
        public JobCategoryRepository(AppDbContext context) : base(context)
        {

        }
        public async Task<List<JobCategoryDto>> GetAllAsync(string q = "")
        {
            var jobCategories = _context.JobCategories.AsQueryable();

            var query = from categ in jobCategories
                        select (new JobCategoryDto
                        {
                            Id = categ.Id,
                            UniqueGuid = categ.UniqueGuid,
                            CategoryName = categ.CategoryName,
                            CreatedOn = categ.CreatedOn,
                            UpdatedOn = categ.UpdatedOn,
                        });
            var result = await query.OrderByDescending(e => e.CreatedOn).ToListAsync();

            return result;
        }

        public async Task<JobCategoryListingResponseDto> GetAllWithPagination(JobCategoryListParams p)
        {
            if (p.Page < 1)
                p.Page = 1;

            if (p.RecordPerPage < 1)
                p.RecordPerPage = 1;

            if (string.IsNullOrWhiteSpace(p.SortBy))
                p.SortBy = "updateddate";

            if (!string.IsNullOrWhiteSpace(p.SortBy))
                p.SortBy = p.SortBy.Trim().ToLower();

            if (string.IsNullOrWhiteSpace(p.SortDirection))
                p.SortDirection = "desc";

            if (!string.IsNullOrWhiteSpace(p.SortDirection))
                p.SortDirection = p.SortDirection.Trim().ToLower();

            var categories = _context.JobCategories.AsNoTracking();

            if (!string.IsNullOrWhiteSpace(p.Q))
                categories = categories.Where(e => e.CategoryName.Contains(p.Q) );

           

            var query = from category in categories
                        select (new JobCategoryDto
                        {
                            Id = category.Id,
                            UniqueGuid = category.UniqueGuid,
                            CategoryName = category.CategoryName,
                            CreatedOn = category.CreatedOn,
                            UpdatedOn = category.UpdatedOn,
                        });

            var countQuery = query;
            var totalRecord = await countQuery.Select(e => e.Id).CountAsync();

            #region Sorting

            var sorting = $"{p.SortBy}_{p.SortDirection}";

            if (sorting == "id_asc")
                query = query.OrderBy(e => e.Id);
            else if (sorting == "id_desc")
                query = query.OrderByDescending(e => e.Id);
            else if (sorting == "name_asc")
                query = query.OrderBy(e => e.CategoryName);
            else if (sorting == "name_desc")
                query = query.OrderByDescending(e => e.CategoryName);
        
            else if (sorting == "updateddate_asc")
                query = query.OrderBy(e => e.UpdatedOn);
            else if (sorting == "updateddate_desc")
                query = query.OrderByDescending(e => e.UpdatedOn);
            else
                query = query.OrderByDescending(e => e.UpdatedOn).ThenBy(e => e.CategoryName);
            #endregion

            query = query.Skip((p.Page - 1) * p.RecordPerPage).Take(p.RecordPerPage);

            var result = await query.AsNoTracking().ToListAsync();

            var response = new JobCategoryListingResponseDto
            {
                TotalRecord = totalRecord,
                Data = result
            };

            return response;
        }
    }
}
