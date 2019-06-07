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

    /// <summary>
    /// Модель успеваемости
    /// </summary>
    public class LabProgress
    {
        /// <summary>
        /// Идентификатор успеваемости
        /// </summary>
        public int id { get; set; }

        /// <summary>
        /// Идентификатор студента
        /// </summary>
        public int student_id { get; set; }

        /// <summary>
        /// Идентификатор специальности
        /// </summary>
        public string speciality_id { get; set; }

        /// <summary>
        /// Название дисциплины
        /// </summary>
        [Display(Name = "Дисциплина")]
        public string discipline_name { get; set; }

        /// <summary>
        /// Идентификатор дисциплины
        /// </summary>
        public int discipline_id { get; set; }

        /// <summary>
        /// Идентификатор преподователя
        /// </summary>
        public string teacher_id { get; set; }

        /// <summary>
        /// Название преподователя
        /// </summary>
        [Display(Name = "Преподаватель")]
        public string teacher_name {get;set;}

        /// <summary>
        /// ФИО студента
        /// </summary>
        [Display(Name = "Студент")]
        public string student_name { get; set; }

        /// <summary>
        /// Курс
        /// </summary>
        public int coors { get; set; }

        /// <summary>
        /// Идентификатор группы
        /// </summary>
        public int group_id { get; set; }

        

        /// <summary>
        /// Номер группы
        /// </summary>
        public string group_number { get; set; }

        /// <summary>
        /// Название лаборатной
        /// </summary>
        [Display(Name = "Лабораторная")]
        public string lab_name { get; set; }
        private LabStatus status;

        /// <summary>
        /// Статус лабораторной
        /// </summary>
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