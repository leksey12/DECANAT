using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DECANAT.ModelData
{
    public class NewWork
    {
        public Work work;
        public List<SelectListItem> teachers;
        public List<SelectListItem> disciplines;
    }
}