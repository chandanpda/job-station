using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobStation.Core.Domain
{
    public class JobSeekerProfile
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Mobile { get; set; }
        public string  Email { get; set; }
        public bool IsExperienced { get; set; }
        public string HighestQualification { get; set; }
        public string Branch { get; set; }
        public string InstituteName { get; set; }
        public int Year { get; set; }
        public int Percentage { get; set; }
        public bool StillWorking { get; set; }
        public string Title { get; set; }
        public string CompanyName { get; set; }
        public string Location { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset LastDate { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
    }
}
