using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DECANAT.ModelData
{
    public class NewTeacher :Teacher
    {
        [Required]
        [Display(Name = "Новое ФИО")]
        public string new_username { get; set; }
    }
}