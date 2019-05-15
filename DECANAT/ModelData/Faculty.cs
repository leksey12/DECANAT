using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DECANAT.ModelData
{
    /// <summary>
    /// Модель Факулета
    /// </summary>
    public class Faculty
    {
        /// <summary>
        /// идентифактор
        /// </summary>
        public int id { get; set; }

        /// <summary>
        ///Название факультета 
        /// </summary>
        [Required]
        [Display(Name = "Факультет")]
        public string Name { get; set; }
    }
}