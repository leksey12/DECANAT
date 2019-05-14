using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DECANAT.ModelData
{
    public class Study
    {
        public string student_name{get;set;}
        public int speciality_id{get;set;}
        public int student_id{get;set;}
        public int subgroup_id{get;set;}
        public int coors{get;set;}
        public int group{get;set;}
        public int subgroup{get;set;}
        public int complited{get;set;}
        public int not_complited{get;set;}
        public int all_labs{get;set;}
        public double procent{get;set;}
    }
}