using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DECANAT.ModelData
{
    public enum LabStatus{Complete,NotComlete,Wait,Error}
    public class LabProgress
    {
        public int id { get; set; }
        public int student_id { get; set; }
        public string speciality_id { get; set; }
        [Display(Name = "Дисциплина")]
        public string discipline_name { get; set; }
        public int discipline_id { get; set; }
        public string teacher_id { get; set; }
        [Display(Name = "Преподаватель")]
        public string teacher_name {get;set;}
        [Display(Name = "Студент")]
        public string student_name { get; set; }
        public int coors { get; set; }
        public int subgroop_id { get; set; }
        public int subgroop_number { get; set; }
        public int group_number { get; set; }
        [Display(Name = "Лабораторная")]
        public string lab_name { get; set; }
        private LabStatus status;
        [Required]
        [Display(Name = "Статус лабораторной")]
        public string lab_status
        {
            get 
            {
                switch (status)
                {
                    case LabStatus.Complete: return "Сдано";
                    case LabStatus.NotComlete: return "Не сдано";
                    case LabStatus.Wait: return "Проверяется";
                    default: return "Ошибка";
                }
            }
            set
            {
                switch(value)
                {
                    case "Сдано": status = LabStatus.Complete;
                        break;
                    case "Не сдано": status = LabStatus.NotComlete;
                        break;
                    case "Проверяется": status = LabStatus.Wait;
                        break;
                    default: status = LabStatus.Error;
                        break;
                }
            }
        }
        public IEnumerable<SelectListItem> Statuses { get; set; }
        public static List<SelectListItem> GetAllStatus()
        {
            List<SelectListItem> selectList = new List<SelectListItem>();
            selectList.Add(new SelectListItem
            {
                Value = "Сдано",
                Text = "Сдано"
            });
            selectList.Add(new SelectListItem
            {
                Value = "Не сдано",
                Text = "Не сдано"
            });
            selectList.Add(new SelectListItem
            {
                Value = "Проверяется",
                Text = "Проверяется"
            });
            return selectList;
        }
    }
}