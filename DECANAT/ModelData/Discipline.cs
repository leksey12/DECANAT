using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DECANAT.ModelData
{
    public class Discipline
    {
        public int faculty_code { get; set; }
        [Required]
        [Display(Name = "Факультет")]
        public string faculty_name { get; set; }
        public int speciality_code { get; set; }
        [Required]
        [Display(Name = "Код специальности")]
        public int speciality_number { get; set; }
        [Required]
        [Display(Name = "Специальность")]
        public string speciality_name { get; set; }
        public int id { get; set; }
        [Required]
        [Display(Name = "Дисциплина")]
        public string discipline_name { get; set; }
    }
}