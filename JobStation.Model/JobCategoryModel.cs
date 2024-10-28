using System;
using System.ComponentModel.DataAnnotations;

namespace JobStation.Model
{
    public class JobCategoryModel
    {
        public int Id { get; set; }
        public string UniqueGuid { get; set; }

        [Required(ErrorMessage = "Category Name is required")]
        [Display(Name = "Category Name")]
        public string CategoryName { get; set; }
       
    }
}
