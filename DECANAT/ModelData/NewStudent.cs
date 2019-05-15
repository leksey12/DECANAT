using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DECANAT.ModelData
{
    /// <summary>
    /// Наследование студента
    /// </summary>
    public class NewStudent :Student
    {
        /// <summary>
        /// Фамилия Имя Отчество
        /// </summary>
        [Required]
        [Display(Name = "новое ФИО")]
        public string new_FIO { get; set; }
    }
}