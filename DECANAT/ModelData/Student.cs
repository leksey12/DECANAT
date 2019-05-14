using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DECANAT.ModelData
{
    public class Student : Subgroup
    {
        public int subgroup_id { get; set; }
        [Required]
        [Display(Name = "ФИО")]
        public string FIO { get; set; }
    }
}