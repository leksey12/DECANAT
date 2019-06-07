using DECANAT.ModelData;
using DECANAT.Repozitory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace DECANAT.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index(string name)
        {

           if (!String.IsNullOrEmpty(name))
            //if (ViewBag.querry == ""|| ViewBag.querry.length==5)
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
            }
            return View(list);
        }
        public ActionResult DisciplineStuding(int student_id)
        {
            Student student = UnitOfWork.Students.Get(student_id);
            ViewBag.faculty_name = student.faculty_name;
            ViewBag.speciality_name = student.speciality_name;
            ViewBag.speciality_number = student.speciality_number;
            ViewBag.speciality_id = student.speciality_id;
            ViewBag.coors = student.coors;
            ViewBag.group_number = student.group_number;
            ViewBag.student_name = student.FIO;
            return View(UnitOfWork.Studing.GetDisciplines("where \"Код_студента\"=" + student_id));
        }
    }
}