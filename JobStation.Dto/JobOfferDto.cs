using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobStation.Dto
{
    public class JobOfferDto
    {
        public int Id { get; set; }
        public string UniqueGuid { get; set; }
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public string JobType { get; set; }
        public string Description { get; set; }
        public int Experience { get; set; }
        public string Salary { get; set; }
        public string Location { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public DateTimeOffset UpdatedOn { get; set; }
    }
}
