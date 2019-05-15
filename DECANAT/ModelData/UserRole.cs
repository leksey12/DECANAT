using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DECANAT.ModelData
{
    /// <summary>
    /// Наследование преподователя
    /// </summary>
    public class UserRole :Teacher
    {
        /// <summary>
        /// Список ролей
        /// </summary>
        public List<string> roles { get; set; }
    }
}