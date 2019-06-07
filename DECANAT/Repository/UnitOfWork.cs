using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DECANAT.Repozitory
{
    public static class UnitOfWork
    {
        private static FacultiesRepository faculties;
        public static FacultiesRepository Faculties
        {
            get
            {
                if (faculties == null) faculties = new FacultiesRepository();
                return faculties;
            }
        }
        private static SpecialityRepozitory specialitys;
        public static SpecialityRepozitory Specialitys
        {
            get
            {
                if (specialitys == null) specialitys = new SpecialityRepozitory();
                return specialitys;
            }
        }
        private static DisciplineRepozitory disciplines;
        public static DisciplineRepozitory Disciplines
        {
            get
            {
                if (disciplines == null) disciplines = new DisciplineRepozitory();
                return disciplines;
            }
        }
        private static GroupRepozitory groups;
        public static GroupRepozitory Groups
        {
            get
            {
                if (groups == null) groups = new GroupRepozitory();
                return groups;
            }
        }
        private static StudentRepozitory students;
        public static StudentRepozitory Students
        {
            get
            {
                if (students == null) students = new StudentRepozitory();
                return students;
            }
        }
        private static WorkRepository works;
        public static WorkRepository Works
        {
            get
            {
                if (works == null) works = new WorkRepository();
                return works;
            }
        }
        private static TeacherRepozitory teachers;
        public static TeacherRepozitory Teachers
        {
            get
            {
                if (teachers == null) teachers = new TeacherRepozitory();
                return teachers;
            }
        }
        private static LabRepozitory labs;
        public static LabRepozitory Labs
        {
            get
            {
                if (labs == null) labs = new LabRepozitory();
                return labs;
            }
        }
        private static LabProgressRepozitory labProgress;
        public static LabProgressRepozitory LabProgress
        {
            get
            {
                if (labProgress == null) labProgress = new LabProgressRepozitory();
                return labProgress;
            }
        }
        private static RolesRepozitory roles;
        public static RolesRepozitory Roles
        {
            get
            {
                if (roles == null) roles = new RolesRepozitory();
                return roles;
            }
        }
        private static StudingRepizitory studing;
        public static StudingRepizitory Studing
        {
            get
            {
                if (roles == null) studing = new StudingRepizitory();
                return studing;
            }
        }
    }
}