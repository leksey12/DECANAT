using DECANAT.ModelData;
using DECANAT.Repozitory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DECANAT.Controllers
{
    [Authorize(Roles = "decanat")]
    public class DekanController : Controller
    {
        public ActionResult Facultes()
        {
            return View(UnitOfWork.Faculties.GetAll());
        }
        public ActionResult Specialitis(int faculty_id)
        {
            ViewBag.faculty_id = faculty_id;
            ViewBag.faculty = UnitOfWork.Faculties.Get(faculty_id).Name;
            return View(UnitOfWork.Specialitys.GetAll("where \"Код_факультета\"=" + faculty_id));
        }
        public ActionResult Groups(int speciality_id)
        {
            Speciality speciality = UnitOfWork.Specialitys.Get(speciality_id);
            ViewBag.faculty_id = speciality.faculty_code;
            ViewBag.faculty = speciality.faculty_name;
            ViewBag.speciality_name = speciality.speciality_name;
            ViewBag.speciality_number = speciality.speciality_number;
            ViewBag.speciality_id = speciality.id;
            return View(UnitOfWork.Groups.GetAll("where \"Код_специальности\"=" + speciality_id));
        }
        public ActionResult Studing(int group_id, int speciality_id)
        {
            Group group = UnitOfWork.Groups.Get(group_id);
            ViewBag.faculty_name = group.faculty_name;
            ViewBag.speciality_name = group.speciality_name;
            ViewBag.speciality_number = group.speciality_number;
            ViewBag.speciality_id = group.speciality_id;
            ViewBag.coors = group.coors;
            ViewBag.group_number = group.group_number;
            return View(UnitOfWork.Studing.GetAll("where \"Код_специальности\"=" + speciality_id + " and \"Код_группы\"=" + group_id));
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