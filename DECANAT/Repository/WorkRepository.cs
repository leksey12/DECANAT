using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using System.Web.Mvc;
using DECANAT.ModelData;

namespace DECANAT.Repozitory
{
    public class WorkRepository : IRepository<Work, Work>
    {
        public IEnumerable<Work> GetAll(string querry = null)
        {
            OracleConnection connection = SingltoneConnection.GetInstance();
            using (OracleCommand command = connection.CreateCommand())
            {
                command.CommandType = CommandType.Text;
                command.CommandText = "select * from TEACHER_DISCIPLINE_LIST";
                if (querry != null) command.CommandText += " " + querry;
                using (OracleDataReader reader = command.ExecuteReader())
                {
                    List<Work> works = new List<Work>();
                    while (reader.Read())
                    {
                        works.Add(new Work
                        {
                            id = Convert.ToInt32(reader["Код_нагрузки"].ToString()),
                            teacher_id = reader["Код_преподавателя"].ToString(),
                            teacher_name = reader["Преподаватель"].ToString(),
                            speciality_name = reader["Имя_специальности"].ToString(),
                            discipline_name = reader["Наименование_дисциплины"].ToString(),
                            discipline_id = Convert.ToInt32(reader["Код_дисциплины"].ToString()),
                            coors = Convert.ToInt32(reader["Курс"].ToString()),
                            group_number = reader["Наименование_группы"].ToString(),
                            faculty_name = reader["Название_факультета"].ToString(),
                            speciality_number = Convert.ToInt32(reader["Номер_специальности"].ToString()),
                            group_id = Convert.ToInt32(reader["Код_группы"].ToString()),
                            speciality_id = Convert.ToInt32(reader["Код_специальности"].ToString())
                        });
                    }
                    return works;
                }
            }
        }
        public Work Get(int id)
        {
            OracleConnection connection = SingltoneConnection.GetInstance();
            using (OracleCommand command = connection.CreateCommand())
            {
                command.CommandType = CommandType.Text;
                command.CommandText = "select * from TEACHER_DISCIPLINE_LIST where \"Код_нагрузки\"=:id";
                OracleParameter id_param = new OracleParameter()
                {
                    ParameterName = "id",
                    Direction = ParameterDirection.Input,
                    OracleDbType = OracleDbType.Varchar2,
                    Value = id
                };
                command.Parameters.Add(id_param);
                using (OracleDataReader reader = command.ExecuteReader())
                {
                    reader.Read();
                    Work work = new Work 
                        {
                            id = Convert.ToInt32(reader["Код_нагрузки"].ToString()),
                            teacher_id = reader["Код_преподавателя"].ToString(),
                            teacher_name = reader["Преподаватель"].ToString(),
                            speciality_name = reader["Имя_специальности"].ToString(),
                            discipline_name = reader["Наименование_дисциплины"].ToString(),
                            discipline_id = Convert.ToInt32(reader["Код_дисциплины"].ToString()),
                            coors = Convert.ToInt32(reader["Курс"].ToString()),
                            group_number = reader["Наименование_группы"].ToString(),
                            faculty_name = reader["Название_факультета"].ToString(),
                            speciality_number = Convert.ToInt32(reader["Номер_специальности"].ToString()),
                            group_id = Convert.ToInt32(reader["Код_группы"].ToString()),
                            speciality_id = Convert.ToInt32(reader["Код_специальности"].ToString())
                        };
                    return work;
                }
            }
        }

        public void Create(Work item)
        {
            OracleConnection connection = SingltoneConnection.GetInstance();
            using (OracleCommand command = connection.CreateCommand())
            {
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "ADD_WORK";
                OracleParameter group_id_param = new OracleParameter()
                {
                    ParameterName = "group_code",
                    Direction = ParameterDirection.Input,
                    OracleDbType = OracleDbType.Varchar2,
                    Value = item.group_id
                };
                OracleParameter teacher_id_param = new OracleParameter()
                {
                    ParameterName = "teacher_kode",
                    Direction = ParameterDirection.Input,
                    OracleDbType = OracleDbType.Varchar2,
                    Value = item.teacher_id
                };
                OracleParameter discipline_id_param = new OracleParameter()
                {
                    ParameterName = "discipline_code",
                    Direction = ParameterDirection.Input,
                    OracleDbType = OracleDbType.Varchar2,
                    Value = item.discipline_id
                };
                command.Parameters.Add(group_id_param);
                command.Parameters.Add(teacher_id_param);
                command.Parameters.Add(discipline_id_param);
                command.ExecuteNonQuery();
            }
        }

        public void Update(Work item)
        {
            throw new NotImplementedException();
        }
        public void Delete(int id)
        {
            OracleConnection connection = SingltoneConnection.GetInstance();
            using (OracleCommand command = connection.CreateCommand())
            {
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "REMOVE_WORK";
                OracleParameter id_param = new OracleParameter()
                {
                    ParameterName = "kode",
                    Direction = ParameterDirection.Input,
                    OracleDbType = OracleDbType.Varchar2,
                    Value = id
                };
                command.Parameters.Add(id_param);
                command.ExecuteNonQuery();
            }
        }
        public List<SelectListItem> GetDisciplinesFromSpecialityId(int id)
        { 
            OracleConnection connection = SingltoneConnection.GetInstance();
            using (OracleCommand command = connection.CreateCommand())
            {
                command.CommandType = CommandType.Text;
                command.CommandText = "select * from \"Дисциплина\" where \"Код_специальности\"=:id";
                OracleParameter id_param = new OracleParameter()
                {
                    ParameterName = "id",
                    Direction = ParameterDirection.Input,
                    OracleDbType = OracleDbType.Varchar2,
                    Value = id
                };
                command.Parameters.Add(id_param);
                using (OracleDataReader reader = command.ExecuteReader())
                {
                    List<SelectListItem> result = new List<SelectListItem>();
                    while (reader.Read())
                    {
                        result.Add(new SelectListItem
                        {
                            Value = reader["Код_дисциплины"].ToString(),
                            Text = reader["Наименование_дисциплины"].ToString()
                        });
                    }
                    return result;
                }
            }
        }
        public List<SelectListItem> GetTeachers()
        {
            OracleConnection connection = SingltoneConnection.GetInstance();
            using (OracleCommand command = connection.CreateCommand())
            {
                command.CommandType = CommandType.Text;
                command.CommandText = "select * from \"Преподаватель\"";
                using (OracleDataReader reader = command.ExecuteReader())
                {
                    List<SelectListItem> result = new List<SelectListItem>();
                    while (reader.Read())
                    {
                        result.Add(new SelectListItem
                        {
                            Value = reader["Код_преподавателя"].ToString(),
                            Text = reader["ФИО"].ToString()
                        });
                    }
                    return result;
                }
            }
        }
    }
}