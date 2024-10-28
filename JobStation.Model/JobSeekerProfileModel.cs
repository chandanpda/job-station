using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobStation.Model
{
    public class JobSeekerProfileModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "First Name is Required")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is Required")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public string Mobile { get; set; }

        [Required(ErrorMessage = "Email is Required")]
        public string Email { get; set; }
        public bool IsExperienced { get; set; }

        [Required(ErrorMessage = "Highest Qualification is Required")]
        public string HighestQualification { get; set; }

        [Required(ErrorMessage = "Branch is Required")]
        public string Branch { get; set; }

        [Required(ErrorMessage = "InstituteName is Required")]
        public string InstituteName { get; set; }

        [Required(ErrorMessage = "Year is Required")]
        public int Year { get; set; }

        [Required(ErrorMessage = "Percentage is Required")]
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
