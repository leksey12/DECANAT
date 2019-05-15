using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DECANAT.ModelData
{
    /// <summary>
    /// Модель подгруппы
    /// </summary>
    public class Subgroup : Group
    {
        /// <summary>
        /// Номер подгруппа
        /// </summary>
        [Required]
        [Display(Name = "Подгруппа")]
        public int subgroup_number { get; set; }

        /// <summary>
        /// Идентификатор группы
        /// </summary>
        public int group_id { get; set; }

        /// <summary>
        /// студенты
        /// </summary>
        public int peoples_count { get; set; }
    }
}