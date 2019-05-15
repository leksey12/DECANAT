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
    }
}