using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DECANAT.ModelData
{
    /// <summary>
    /// Наследование роли
    /// </summary>
    public class NewUserRole :UserRole
    {
        /// <summary>
        /// Новая роль
        /// </summary>
        [Required]
        [Display(Name = "Новая роль")]
        public string new_role { get; set; }
        /// <summary>
        /// Открывает список ролей
        /// </summary>
        public List<SelectListItem> roles_list { get; set; }
    }
}