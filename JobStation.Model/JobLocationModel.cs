using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobStation.Model
{
    public class JobLocationModel
    {
        public int Id { get; set; }
        public string UniqueGuid { get; set; }
        [Required(ErrorMessage = "City is Required")]
        public string City { get; set; }
        [Required(ErrorMessage = "State is Required")]
        public string State { get; set; }
        public DateTimeOffset AddedOn { get; set; }
    }
}
