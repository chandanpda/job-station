using JobStation.Parameters;
using System;
using System.Collections.Generic;

namespace JobStation.Dto
{
    public class JobCategoryDto
    {
        public int Id { get; set; }
        public string UniqueGuid { get; set; }
        public string CategoryName { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public DateTimeOffset UpdatedOn { get; set; }
    }

    public class JobCategoryListingResponseDto
    {
        public int TotalRecord { get; set; }
        public JobCategoryListParams Params { get; set; }
        public List<JobCategoryDto> Data { get; set; }
    }
}
