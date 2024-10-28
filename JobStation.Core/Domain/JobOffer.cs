using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobStation.Core.Domain
{
    public class JobOffer
    {
        public int Id { get; set; }
        public string UniqueGuid { get; set; }
        public int JobCategoryId  { get; set; }
        public int JobTypeId { get; set; }
        public int CompanyId { get; set; }
        public int LocationId { get; set; }
        public string Title { get; set; }       
        public string Description { get; set; }
        public int Experience { get; set; }
        public string Salary { get; set; }
        public bool IsActive { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public DateTimeOffset UpdatedOn { get; set; }
    }
}
