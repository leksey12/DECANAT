using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DECANAT.ModelData
{
    /// <summary>
    /// Модель Преподователя
    /// </summary>
    public class Teacher
    {
        /// <summary>
        /// Идентификатор преподователя
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// ФИО Преподователя
        /// </summary>
        [Display(Name = "Преподаватель")]
        public string username { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        [Display(Name = "Email")]
        public string email { get; set; }
    }
}