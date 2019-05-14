using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DECANAT.ModelData
{
    public class TeacherWork
    {
        public string teacher_name { get; set; }
        public int speciality_id { get; set; }
        public string speciality_code { get; set; }
        public string speciality_name { get; set; }
        public string discipline_name { get; set; }
        public int coors { get; set; }
        public int year { get; set; }
        public int group_number { get; set; }
        public int subgroop_number { get; set; }
        public int subgroop_code { get; set; }
    }
}