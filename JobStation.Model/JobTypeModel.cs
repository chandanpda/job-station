using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobStation.Model
{
    public class JobTypeModel
    {
        public int Id { get; set; }
        public string UniqueGuid { get; set; }

        [Required(ErrorMessage = "Type Name is required")]
        [Display(Name = "Job Type Name")]
        public string TypeName { get; set; }
    }
}
