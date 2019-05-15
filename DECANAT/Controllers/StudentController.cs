using DECANAT.ModelData;
using DECANAT.Repozitory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DECANAT.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index(string name)
        {
            if (!String.IsNullOrWhiteSpace(name))
            {
                ViewBag.querry = name;
                return View(UnitOfWork.Students.GetAll("where \"ФИО\" LIKE '%" + name + "%'"));
            }
            else
            {
                ViewBag.querry = "";
                return View(new List<Student>());
            }
        }
    }
}