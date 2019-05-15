using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DECANAT.ModelData
{
    /// <summary>
    /// Наследование лабораторной
    /// </summary>
    public class NewLab :Lab
    {
        /// <summary>
        /// Новое название лабораторной
        /// </summary>
        [Required]
        [Display(Name = "Новое название лабораторной")]
        public string new_lab_name { get; set; }
    }
}