using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobStation.Model
{
    public class OrganisationDetailsModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Organisation name is Required")]
        [Display(Name ="Organisation")]
        public string OrganisationName { get; set; }
        [Required(ErrorMessage = "Domain name is Required")]
        public string Domain { get; set; }
        [Required(ErrorMessage = "Established Year is Required")]
        public string EstablishedYear { get; set; }
        [Required(ErrorMessage = "Email is Required")]
        public string Email { get; set; }
        public string Url { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
    }
}
