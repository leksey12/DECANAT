using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DECANAT.ModelData
{
    /// <summary>
    /// Наследование преподователя
    /// </summary>
    public class NewTeacher :Teacher
    {
        /// <summary>
        /// Новое ФИО
        /// </summary>
        [Required]
        [Display(Name = "Новое ФИО")]
        public string new_username { get; set; }
    }
}