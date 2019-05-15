using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DECANAT.ModelData
{
    /// <summary>
    /// Модель нагрузки преподователя
    /// </summary>
    public class Work
    {
        /// <summary>
        /// Идентификатор нагрузки
        /// </summary>
        public int id{get;set;}

        /// <summary>
        /// Идентификатор дисциплины
        /// </summary>
        [Required]
        public int discipline_id { get; set; }

        /// <summary>
        /// Идентификатор подгруппы
        /// </summary>
        public int subgroup_id{get;set;}

        /// <summary>
        /// Идентификатор группы
        /// </summary>
        public int group_id { get; set; }

        /// <summary>
        /// Идентификатор специальности
        /// </summary>
        public int speciality_id { get; set; }

        /// <summary>
        /// Идентификатор преподователя
        /// </summary>
        [Required]
	    public string teacher_id{get;set;}

        /// <summary>
        /// ФИО преподователя
        /// </summary>
        [Display(Name = "Преподаватель")]
        public string teacher_name{get;set;}

        /// <summary>
        /// Название дисциплины
        /// </summary>
        [Display(Name = "Дисциплина")]
        public string discipline_name{get;set;}

        /// <summary>
        /// Название специальности
        /// </summary>
        [Display(Name = "Специальность")]
        public string speciality_name{get;set;}

        /// <summary>
        /// Код специальности
        /// </summary>
        [Display(Name = "Код специальности")]
        public int speciality_number { get; set; }

        /// <summary>
        /// Название факультета
        /// </summary>
        [Display(Name = "Факультет")]
        public string faculty_name { get; set; }

        /// <summary>
        /// Курс
        /// </summary>
        [Display(Name = "Курс")]
        public int coors{get;set;}

        /// <summary>
        /// Группа
        /// </summary>
        [Display(Name = "Группа")]
        public int group_number{get;set;}

        /// <summary>
        /// Подгруппа
        /// </summary>
        [Display(Name = "Подгруппа")]
        public int subgroup_number{get;set;}
    }
}