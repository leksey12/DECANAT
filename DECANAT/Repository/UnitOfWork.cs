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
    }
}