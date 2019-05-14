using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DECANAT.ModelData
{
    public class Work
    {
        public int id{get;set;}
        [Required]
        public int discipline_id { get; set; }
        public int subgroup_id{get;set;}
        public int group_id { get; set; }
        public int speciality_id { get; set; }
        [Required]
	    public string teacher_id{get;set;}
        [Display(Name = "Преподаватель")]
        public string teacher_name{get;set;}
        [Display(Name = "Дисциплина")]
        public string discipline_name{get;set;}
        [Display(Name = "Специальность")]
        public string speciality_name{get;set;}
        [Display(Name = "Код специальности")]
        public int speciality_number { get; set; }
        [Display(Name = "Факультет")]
        public string faculty_name { get; set; }
        [Display(Name = "Курс")]
        public int coors{get;set;}
        [Display(Name = "Группа")]
        public int group_number{get;set;}
        [Display(Name = "Подгруппа")]
        public int subgroup_number{get;set;}
    }
}