using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DECANAT.ModelData
{
    /// <summary>
    /// Наследование от Факультета
    /// </summary>
    public class NewFaculty :Faculty
    {
        /// <summary>
        /// Новое название факультета
        /// </summary>
        [Required]
        [Display(Name = "Новое название")]
        public string NewName { get; set; }
    }
}