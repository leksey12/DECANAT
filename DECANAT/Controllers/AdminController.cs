using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DECANAT.ModelData;
using DECANAT.Repozitory;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace DECANAT.Controllers
{
    public class AdminController : Controller
    {
        private string ParseOracleError(string error)
        {
            return error.Split(':').ElementAt(1).Split('O').ElementAt(0);
        }
        private ApplicationUserManager _userManager;
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        #region FACULTY
        public ActionResult Facultes()
        {
            return View(UnitOfWork.Faculties.GetAll());
        }
        public ActionResult AddFaculty()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddFaculty(NewFaculty faculty)
        {
            try
            {
                UnitOfWork.Faculties.Create(faculty);
                return RedirectToAction("Facultes");
            }
            catch
            {
                ModelState.AddModelError("Name", "ошибка добавления, возможно такой факультет уже есть?");
                return View(faculty);
            }
        }
        public ActionResult EditFaculty(int id)
        {
            Faculty oldFaculty = UnitOfWork.Faculties.Get(id);
            NewFaculty faculty = new NewFaculty { Name = oldFaculty.Name };
            return View(faculty);
        }
        [HttpPost]
        public ActionResult EditFaculty(NewFaculty faculty)
        {
            try
            {
                UnitOfWork.Faculties.Update(faculty);
            }
            catch
            {
                ModelState.AddModelError("NewName", "Не удалось переименовать факультет, возможно, факультет с таким именем уже есть?");
                return View(faculty);
            }
            return RedirectToAction("Facultes");
        }
        public ActionResult DeleteFaculty(int id)
        {
            Faculty oldFaculty = UnitOfWork.Faculties.Get(id);
            Faculty faculty = new Faculty { Name = oldFaculty.Name };
            return View(faculty);
        }
        [HttpPost]
        public ActionResult DeleteFaculty(Faculty faculty)
        {
            try
            {
                UnitOfWork.Faculties.Delete(faculty.id);
            }
            catch(Exception)
            {
                ModelState.AddModelError("Name", "Невозможно удалить этот факультет, так как он не пустой");
            }
            if (ModelState.IsValid)
            {
                return RedirectToAction("Facultes");
            }
            else
            {
                return View();
            }
        }
        #endregion
        #region SPECIALITIS
        public ActionResult Specialitis(int faculty_id)
        {
            ViewBag.faculty_id = faculty_id;
            ViewBag.faculty = UnitOfWork.Faculties.Get(faculty_id).Name;
            return View(UnitOfWork.Specialitys.GetAll("where \"Код_факультета\"=" + faculty_id));
        }
        public ActionResult AddSpeciality(int faculty_id)
        {
            Faculty faculty = UnitOfWork.Faculties.Get(faculty_id);
            Speciality speciality = new Speciality { faculty_code = faculty_id, faculty_name = faculty.Name };
            return View(speciality);
        }
        [HttpPost]
        public ActionResult AddSpeciality(Speciality speciality)
        {
            try
            {
                UnitOfWork.Specialitys.Create(speciality);
                return RedirectToAction("Specialitis", new { faculty_id = speciality.faculty_code });
            }
            catch
            {
                ModelState.AddModelError("speciality_name", "ошибка добавления, возможно такая специальность уже есть?");
                return View(speciality);
            }

        }
        public ActionResult EditSpeciality(int id)
        {
            NewSpeciality speciality = UnitOfWork.Specialitys.Get(id);
            speciality.new_speciality_number = speciality.speciality_number;
            speciality.new_speciality_name = speciality.speciality_name;
            return View(speciality);
        }
        [HttpPost]
        public ActionResult EditSpeciality(NewSpeciality speciality)
        {
            try
            {
                UnitOfWork.Specialitys.Update(speciality);
                return RedirectToAction("Specialitis", new { faculty_id = speciality.faculty_code });
            }
            catch { return View(speciality); }
        }
        public ActionResult DeleteSpeciality(int id)
        {
            Speciality speciality = UnitOfWork.Specialitys.Get(id);
            return View(speciality);
        }
        [HttpPost]
        public ActionResult DeleteSpeciality(Speciality speciality)
        {
            try
            {
                UnitOfWork.Specialitys.Delete(speciality.id);
                return RedirectToAction("Specialitis", new { faculty_id = speciality.faculty_code });
            }
            catch (Exception)
            {
                ModelState.AddModelError("speciality_name", "Невозможно удалить эту специальность, так как она не пустая");
                return View(speciality);
            }
        }
        #endregion
    }
}