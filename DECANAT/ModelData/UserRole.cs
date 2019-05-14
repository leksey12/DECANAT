using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DECANAT.ModelData
{
    public class UserRole :Teacher
    {
        public List<string> roles { get; set; }
    }
}