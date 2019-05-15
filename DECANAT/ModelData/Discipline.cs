using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DECANAT.ModelData
{
    /// <summary>
    /// Модель дисциплины
    /// </summary>
    public class Discipline
    {
        /// <summary>
        /// Код факультета
        /// </summary>
        public int faculty_code { get; set; }

        /// <summary>
        /// Название факультета
        /// </summary>
        [Required]
        [Display(Name = "Факультет")]
        public string faculty_name { get; set; }

        /// <summary>
        /// Id специальности
        /// </summary>
        public int speciality_code { get; set; }

        /// <summary>
        ///  Код специальности
        /// </summary>
        [Required]
        [Display(Name = "Код специальности")]
        public int speciality_number { get; set; }

        /// <summary>
        /// Название специальности
        /// </summary>
        [Required]
        [Display(Name = "Специальность")]
        public string speciality_name { get; set; }

        /// <summary>
        /// Идентификатор специальности
        /// </summary>
        public int id { get; set; }

        /// <summary>
        /// Название дисциплины
        /// </summary>
        [Required]
        [Display(Name = "Дисциплина")]
        public string discipline_name { get; set; }
    }
}