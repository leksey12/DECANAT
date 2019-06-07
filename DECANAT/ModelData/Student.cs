using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DECANAT.ModelData
{
    /// <summary>
    /// Модель студентов
    /// </summary>
    public class Student : Group
    {
        /// <summary>
        /// Идентификатор группы
        /// </summary>
        public int group_id { get; set; }

        /// <summary>
        /// Фамилия Имя Отчество
        /// </summary>
        [Required]
        [Display(Name = "ФИО")]
        public string FIO { get; set; }
    }
}