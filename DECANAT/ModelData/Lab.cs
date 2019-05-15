using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DECANAT.ModelData
{
    /// <summary>
    /// Модель лабораторных
    /// </summary>
    public class Lab
    {
        /// <summary>
        /// Идентификатор лаб
        /// </summary>
        public int id { get; set; }

        /// <summary>
        /// Идентификатор дисциплин
        /// </summary>
        public int discipline_id { get; set; }

        /// <summary>
        /// Название специальности
        /// </summary>
        [Display(Name = "Специальность")]
        public string speciality { get; set; }

        /// <summary>
        /// Название дисциплины
        /// </summary>
        [Display(Name = "Дисциплина")]
        public string discipline { get; set; }

        /// <summary>
        /// Название лаборатной
        /// </summary>
        [Display(Name = "Лабораторная")]
        public string lab_name { get; set; }
    }
}