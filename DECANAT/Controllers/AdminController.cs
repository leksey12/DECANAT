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
                ModelState.AddModelError("Name", "������ ����������, �������� ����� ��������� ��� ����?");
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
                ModelState.AddModelError("NewName", "�� ������� ������������� ���������, ��������, ��������� � ����� ������ ��� ����?");
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
                ModelState.AddModelError("Name", "���������� ������� ���� ���������, ��� ��� �� �� ������");
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
            return View(UnitOfWork.Specialitys.GetAll("where \"���_����������\"=" + faculty_id));
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
                ModelState.AddModelError("speciality_name", "������ ����������, �������� ����� ������������� ��� ����?");
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
                ModelState.AddModelError("speciality_name", "���������� ������� ��� �������������, ��� ��� ��� �� ������");
                return View(speciality);
            }
        }
        #endregion
        #region DISCIPLINES
        public ActionResult Disciplines(int speciality_id)
        {
            Speciality speciality = UnitOfWork.Specialitys.Get(speciality_id);
            ViewBag.faculty_id = speciality.faculty_code;
            ViewBag.speciality_id = speciality_id;
            ViewBag.faculty = speciality.faculty_name;
            ViewBag.speciality_name = speciality.speciality_name;
            ViewBag.speciality_number = speciality.speciality_number;
            return View(UnitOfWork.Disciplines.GetAll("where \"���_�������������\"=" + speciality_id));
        }
        public ActionResult AddDiscipline(int speciality_id)
        {
            Speciality speciality = UnitOfWork.Specialitys.Get(speciality_id);
            Discipline discipline = new Discipline
            {
                faculty_name = speciality.faculty_name,
                faculty_code = speciality.faculty_code,
                speciality_code = speciality.id,
                speciality_name = speciality.speciality_name,
                speciality_number = speciality.speciality_number
            };
            return View(discipline);
        }
        [HttpPost]
        public ActionResult AddDiscipline(Discipline discipline)
        {
            try
            {
                UnitOfWork.Disciplines.Create(discipline);
                return RedirectToAction("Disciplines", new { speciality_id = discipline.speciality_code });
            }
            catch
            {
                ModelState.AddModelError("discipline_name", "������ ����������, �������� ����� ���������� ��� ����?");
                return View(discipline);
            }

        }
        public ActionResult EditDiscipline(int id)
        {
            NewDiscipline discipline = UnitOfWork.Disciplines.Get(id);
            return View(discipline);
        }
        [HttpPost]
        public ActionResult EditDiscipline(NewDiscipline discipline)
        {
            try
            {
                UnitOfWork.Disciplines.Update(discipline);
                return RedirectToAction("Disciplines", new { speciality_id = discipline.speciality_code });
            }
            catch
            {
                ModelState.AddModelError("newDisciplineName", "������ ��������������, �������� ����� ���������� ��� ����?");
                return View(discipline);
            }
        }
        public ActionResult DeleteDiscipline(int id)
        {
            Discipline discipline = UnitOfWork.Disciplines.Get(id);
            return View(discipline);
        }
        [HttpPost]
        public ActionResult DeleteDiscipline(Discipline discipline)
        {
            try
            {
                UnitOfWork.Disciplines.Delete(discipline.id);
                return RedirectToAction("Disciplines", new { speciality_id = discipline.speciality_code });
            }
            catch (Exception)
            {
                ModelState.AddModelError("discipline_name", "���������� ������� ��� ����������, ��� ��� ��� �� ������");
                return View(discipline);
            }
        }
        #endregion
        #region GROUPS
        public ActionResult Groups(int speciality_id)
        {
            Speciality speciality = UnitOfWork.Specialitys.Get(speciality_id);
            ViewBag.faculty_id = speciality.faculty_code;
            ViewBag.faculty = speciality.faculty_name;
            ViewBag.speciality_name = speciality.speciality_name;
            ViewBag.speciality_number = speciality.speciality_number;
            ViewBag.speciality_id = speciality.id;
            return View(UnitOfWork.Groups.GetAll("where \"���_�������������\"=" + speciality_id));
        }
        public ActionResult AddGroup(int speciality_id)
        {
            Speciality speciality = UnitOfWork.Specialitys.Get(speciality_id);
            Group group = new Group
            {
                faculty_name = speciality.faculty_name,
                speciality_number = speciality.speciality_number,
                speciality_name = speciality.speciality_name,
                speciality_id = speciality.id
            };
            return View(group);
        }
        [HttpPost]
        public ActionResult AddGroup(Group group)
        {
            try
            {
                UnitOfWork.Groups.Create(group);
                return RedirectToAction("Groups", new { speciality_id = group.speciality_id });
            }
            catch
            {
                ModelState.AddModelError("group_number", "������ ����������, �������� ����� ������ ��� ����?");
                return View(group);
            }

        }
        public ActionResult DeleteGroup(int id)
        {
            return View(UnitOfWork.Groups.Get(id));
        }
        [HttpPost]
        public ActionResult DeleteGroup(Group group)
        {
            try
            {
                UnitOfWork.Groups.Delete(group.id);
                return RedirectToAction("Groups", new { speciality_id = group.speciality_id });
            }
            catch (Exception)
            {
                ModelState.AddModelError("group_number", "������ ��������, ������ ������ �� �����");
                return View(group);
            }
        }
        #endregion
        #region SUBGROUPS
        public ActionResult Subgroups(int group_id)
        {
            Group group = UnitOfWork.Groups.Get(group_id);
            ViewBag.speciality_id = group.speciality_id;
            ViewBag.group_id = group_id;
            ViewBag.faculty = group.faculty_name;
            ViewBag.speciality_name = group.speciality_name;
            ViewBag.speciality_number = group.speciality_number;
            ViewBag.coors = group.coors;
            ViewBag.group_number = group.group_number;
            IEnumerable<Subgroup> subgroups = UnitOfWork.Subgroups.GetAll("where \"���_������\"=" + group_id);
            return View(subgroups);
        }
        public ActionResult AddSubgroup(int group_id)
        {
            Group group = UnitOfWork.Groups.Get(group_id);
            Subgroup subgroup = new Subgroup
            {
                speciality_number = group.speciality_number,
                faculty_name = group.faculty_name,
                speciality_name = group.speciality_name,
                group_id = group.id,
                group_number = group.group_number,
                coors = group.coors
            };
            return View(subgroup);
        }
        [HttpPost]
        public ActionResult AddSubgroup(Subgroup subgroup)
        {
            try
            {
                UnitOfWork.Subgroups.Create(subgroup);
                return RedirectToAction("Subgroups", new { group_id = subgroup.group_id });
            }
            catch
            {
                ModelState.AddModelError("subgroup_number", "������ ����������, �������� ����� ������ ��� ����?");
                return View(subgroup);
            }

        }
        public ActionResult DeleteSubgroup(int id)
        {
            Subgroup subgroup = UnitOfWork.Subgroups.Get(id);
            return View(subgroup);
        }
        [HttpPost]
        public ActionResult DeleteSubgroup(Subgroup subgroup)
        {
            try
            {
                UnitOfWork.Subgroups.Delete(subgroup.id);
                return RedirectToAction("Subgroups", new { group_id = subgroup.group_id });
            }
            catch (Exception)
            {
                ModelState.AddModelError("subgroup_number", "������ ��������, ������ ��������� �� �����");
                return View(subgroup);
            }
        }
        #endregion
        #region STUDENTS
        public ActionResult Students(int subgroup_id)
        {
            Subgroup subgroup = UnitOfWork.Subgroups.Get(subgroup_id);
            ViewBag.group_id = subgroup.group_id;
            ViewBag.subgroup_id = subgroup_id;
            ViewBag.faculty = subgroup.faculty_name;
            ViewBag.speciality_name = subgroup.speciality_name;
            ViewBag.speciality_number = subgroup.speciality_number;
            ViewBag.coors = subgroup.coors;
            ViewBag.group_number = subgroup.group_number;
            ViewBag.subgroup_number = subgroup.subgroup_number;
            IEnumerable<Subgroup> subgroups = UnitOfWork.Students.GetAll("where \"���_���������\"=" + subgroup_id);
            return View(subgroups);
        }
        public ActionResult AddStudent(int subgroup_id)
        {
            Subgroup subgroup = UnitOfWork.Subgroups.Get(subgroup_id);
            Student student = new Student
            {
                speciality_number = subgroup.speciality_number,
                faculty_name = subgroup.faculty_name,
                speciality_name = subgroup.speciality_name,
                group_number = subgroup.group_number,
                subgroup_number = subgroup.subgroup_number,
                coors = subgroup.coors,
                subgroup_id = subgroup_id
            };
            return View(student);
        }
        [HttpPost]
        public ActionResult AddStudent(Student student)
        {
            try
            {
                UnitOfWork.Students.Create(student);
                return RedirectToAction("Students", new { subgroup_id = student.subgroup_id });
            }
            catch
            {
                ModelState.AddModelError("FIO", "������ ����������, �������� ����� ������� ��� ����?");
                return View(student);
            }

        }
        public ActionResult EditStudent(int id)
        {
            NewStudent student = UnitOfWork.Students.Get(id);
            return View(student);
        }
        [HttpPost]
        public ActionResult EditStudent(NewStudent student)
        {
            try
            {
                UnitOfWork.Students.Update(student);
                return RedirectToAction("Students", new { subgroup_id = student.subgroup_id });
            }
            catch
            {
                ModelState.AddModelError("FIO", "������ ��������������, �������� ����� ������� ��� ����?");
                return View(student);
            }
        }
        public ActionResult DeleteStudent(int id)
        {
            Student student = UnitOfWork.Students.Get(id);
            return View(student);
        }
        [HttpPost]
        public ActionResult DeleteStudent(Student student)
        {
            try
            {
                UnitOfWork.Students.Delete(student.id);
                return RedirectToAction("Students", new { subgroup_id = student.subgroup_id });
            }
            catch (Exception)
            {
                ModelState.AddModelError("FIO", "������ �������� ��������");
                return View(student);
            }
        }
        #endregion
    }
}