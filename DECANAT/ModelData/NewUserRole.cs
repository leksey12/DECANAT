using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DECANAT.ModelData
{
    public class NewUserRole :UserRole
    {
        [Required]
        [Display(Name = "Новая роль")]
        public string new_role { get; set; }
        public List<SelectListItem> roles_list { get; set; }
    }
}