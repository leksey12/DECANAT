using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DECANAT.ModelData
{
    public class NewSpeciality :Speciality
    {
        [Required]
        [Display(Name = "Новый номер специальности")]
        public int new_speciality_number { get; set; }
        [Required]
        [Display(Name = "Новое название специальности")]
        public string new_speciality_name { get; set; }
    }
}