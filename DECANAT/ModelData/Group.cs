using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DECANAT.ModelData
{
    /// <summary>
    /// Модель группы
    /// </summary>
    public class Group
    {
        /// <summary>
        /// Идентификатор группы
        /// </summary>
        [Required]
        public int id { get; set; }

        /// <summary>
        /// Идентификатор специальности
        /// </summary>
        public int speciality_id { get; set; }

        /// <summary>
        /// Название факультета
        /// </summary>
        [Required]
        [Display(Name = "Факультет")]
        public string faculty_name { get; set; }

        /// <summary>
        /// Название специальности
        /// </summary>
        [Required]
        [Display(Name = "Специальность")]
        public string speciality_name { get; set; }

        /// <summary>
        /// Код специальности
        /// </summary>
        [Required]
        [Display(Name = "Код специальности")]
        public int speciality_number { get; set; }

        /// <summary>
        /// Курс
        /// </summary>
        [Display(Name = "Курс")]
        public int coors { get; set; }

        /// <summary>
        /// Год поступления
        /// </summary>
        [Required]
        [Display(Name = "Год поступления")]
        public int year { get; set; }

        /// <summary>
        /// Номер группы
        /// </summary>
        [Required]
        [Display(Name = "Наименование группы")]
        public string group_number { get; set; }

        /// <summary>
        /// студенты
        /// </summary>
        public int peoples_count { get; set; }

    }
}