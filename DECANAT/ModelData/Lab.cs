using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DECANAT.ModelData
{
    public class Lab
    {
        public int id { get; set; }
        public int discipline_id { get; set; }
        [Display(Name = "Специальность")]
        public string speciality { get; set; }
        [Display(Name = "Дисциплина")]
        public string discipline { get; set; }
        [Display(Name = "Лабораторная")]
        public string lab_name { get; set; }
    }
}