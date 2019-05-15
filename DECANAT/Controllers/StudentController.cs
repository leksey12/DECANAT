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
        public ActionResult Student(int id, string quarry)
        {
            ViewBag.quarry = quarry;
            IEnumerable<LabProgress> list = UnitOfWork.LabProgress.GetAll("where \"Код_студента\"=" + id + " order by \"Наименование_дисциплины\"");
            if (list.Count() != 0)
            {
                ViewBag.FIO = list.ElementAt(0).student_name;
                ViewBag.coors = list.ElementAt(0).coors;
                ViewBag.group_number = list.ElementAt(0).group_number;
                ViewBag.subgroop_number = list.ElementAt(0).subgroop_number;
            }
            return View(list);
        }
    }
}