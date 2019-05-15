using DECANAT.ModelData;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace DECANAT.Repozitory
{
    public class StudingRepizitory 
    {
        public IEnumerable<Study> GetAll(string querry = null)
        {
            OracleConnection connection = SingltoneConnection.GetInstance();
            using (OracleCommand command = connection.CreateCommand())
            {
                command.CommandType = CommandType.Text;
                command.CommandText = "select * from STUDENT_LABS";
                if (querry != null) command.CommandText += " " + querry;
                using (OracleDataReader reader = command.ExecuteReader())
                {
                    List<Study> studyes = new List<Study>();
                    while (reader.Read())
                    {
                        studyes.Add(new Study
                        {
                            student_name=reader["ФИО"].ToString(),
                            student_id = Convert.ToInt32(reader["Код_студента"].ToString()),
                            speciality_id = Convert.ToInt32(reader["Код_специальности"].ToString()),
                            subgroup_id = Convert.ToInt32(reader["Код_подгруппы"].ToString()),
                            group = Convert.ToInt32(reader["Номер_группы"].ToString()),
                            subgroup = Convert.ToInt32(reader["Номер_подгруппы"].ToString()),
                            coors = Convert.ToInt32(reader["Курс"].ToString()),
                            complited = Convert.ToInt32(reader["Сданных"].ToString()),
                            not_complited = Convert.ToInt32(reader["Не_сданных"].ToString()),
                            all_labs = Convert.ToInt32(reader["Всего"].ToString()),
                            procent = Convert.ToDouble(reader["Процент_сдачи"].ToString())
                        });
                    }
                    return studyes;
                }
            }
        }

        public IEnumerable<DisciplineStudy> GetDisciplines(string querry = null)
        {
            OracleConnection connection = SingltoneConnection.GetInstance();
            using (OracleCommand command = connection.CreateCommand())
            {
                command.CommandType = CommandType.Text;
                command.CommandText = "select * from STUDENT_LAB_DISCIPLINE";
                if (querry != null) command.CommandText += " " + querry;
                using (OracleDataReader reader = command.ExecuteReader())
                {
                    List<DisciplineStudy> studyes = new List<DisciplineStudy>();
                    while (reader.Read())
                    {
                        studyes.Add(new DisciplineStudy
                        {
                            student_name = reader["ФИО"].ToString(),
                            student_id = Convert.ToInt32(reader["Код_студента"].ToString()),
                            speciality_id = Convert.ToInt32(reader["Код_специальности"].ToString()),
                            subgroup_id = Convert.ToInt32(reader["Код_подгруппы"].ToString()),
                            group = Convert.ToInt32(reader["Номер_группы"].ToString()),
                            subgroup = Convert.ToInt32(reader["Номер_подгруппы"].ToString()),
                            coors = Convert.ToInt32(reader["Курс"].ToString()),
                            complited = Convert.ToInt32(reader["Сданных"].ToString()),
                            not_complited = Convert.ToInt32(reader["Не_сданных"].ToString()),
                            all_labs = Convert.ToInt32(reader["Всего"].ToString()),
                            procent = Convert.ToDouble(reader["Процент_сдачи"].ToString()),
                            discipline = reader["Наименование_дисциплины"].ToString()
                        });
                    }
                    return studyes;
                }
            }
        }
    }
}