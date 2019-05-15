using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DECANAT.ModelData
{
    /// <summary>
    /// Наследование дисциплины
    /// </summary>
    public class NewDiscipline :Discipline
    {
        /// <summary>
        /// название дисциплины
        /// </summary>
        [Required]
        [Display(Name = "Новое название дисциплины")]
        public string new_discipline_name { get; set; }
    }
}