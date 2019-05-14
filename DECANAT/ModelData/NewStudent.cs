using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DECANAT.ModelData
{
    public class NewStudent :Student
    {
        [Required]
        [Display(Name = "новое ФИО")]
        public string new_FIO { get; set; }
    }
}