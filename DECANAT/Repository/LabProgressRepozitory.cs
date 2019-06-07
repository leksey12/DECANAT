using DECANAT.ModelData;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace DECANAT.Repozitory
{
    public class LabProgressRepozitory : IRepository<LabProgress, LabProgress>
    {
        public IEnumerable<LabProgress> GetAll(string querry = null)
        {
            OracleConnection connection = SingltoneConnection.GetInstance();
            using (OracleCommand command = connection.CreateCommand())
            {
                command.CommandType = CommandType.Text;
                command.CommandText = "select * from LAB_LIST";
                if (querry != null) command.CommandText += " " + querry;
                List<OracleParameter> parametrs = new List<OracleParameter>();
                using (OracleDataReader reader = command.ExecuteReader())
                {
                    List<LabProgress> result = new List<LabProgress>();
                    while (reader.Read())
                    {
                        result.Add(new LabProgress()
                        {
                            id = Convert.ToInt32(reader["Код_записи"].ToString()),
                            student_id = Convert.ToInt32(reader["Код_студента"].ToString()),
                            teacher_id = reader["Код_преподавателя"].ToString(),
                            speciality_id = reader["Код_специальности"].ToString(),
                            discipline_name = reader["Наименование_дисциплины"].ToString(),
                            discipline_id = Convert.ToInt32(reader["Код_дисциплины"]),
                            teacher_name = reader["Преподаватель"].ToString(),
                            student_name = reader["Студент"].ToString(),
                            coors = Convert.ToInt32(reader["Курс"].ToString()),
                            group_id = Convert.ToInt32(reader["Код_группы"].ToString()),
                            group_number = reader["Наименование_группы"].ToString(),
                            lab_name = reader["Название_лабораторной"].ToString(),
                            lab_status = reader["Статус_сдачи"].ToString()
                        });
                    }
                    return result;
                }
            }
        }

        public LabProgress Get(int id)
        {
            OracleConnection connection = SingltoneConnection.GetInstance();
            using (OracleCommand command = connection.CreateCommand())
            {
                command.CommandType = CommandType.Text;
                command.CommandText = "select * from LAB_LIST where \"Код_записи\"=:id";
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
                    LabProgress result = new LabProgress()
                    {
                        id = Convert.ToInt32(reader["Код_записи"].ToString()),
                        student_id = Convert.ToInt32(reader["Код_студента"].ToString()),
                        teacher_id = reader["Код_преподавателя"].ToString(),
                        speciality_id = reader["Код_специальности"].ToString(),
                        discipline_name = reader["Наименование_дисциплины"].ToString(),
                        discipline_id = Convert.ToInt32(reader["Код_дисциплины"]),
                        teacher_name = reader["Преподаватель"].ToString(),
                        student_name = reader["Студент"].ToString(),
                        coors = Convert.ToInt32(reader["Курс"].ToString()),
                       group_id = Convert.ToInt32(reader["Код_группы"].ToString()),
                        group_number = reader["Наименование_группы"].ToString(),
                        lab_name = reader["Название_лабораторной"].ToString(),
                        lab_status = reader["Статус_сдачи"].ToString()
                    };
                    return result;
                }
            }
        }

        public void Create(LabProgress item)
        {
            throw new NotImplementedException();
        }

        public void Update(LabProgress item)
        {
            OracleConnection connection = SingltoneConnection.GetInstance();
            using (OracleCommand command = connection.CreateCommand())
            {
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "SET_PROGRESS";
                OracleParameter discipline_code = new OracleParameter()
                {
                    ParameterName = "discipline_code",
                    Direction = ParameterDirection.Input,
                    OracleDbType = OracleDbType.Int32,
                    Value = item.discipline_id
                };
                OracleParameter teacher_code = new OracleParameter()
                {
                    ParameterName = "teacher_code",
                    Direction = ParameterDirection.Input,
                    OracleDbType = OracleDbType.Varchar2,
                    Value = item.teacher_id
                };
                OracleParameter student_code = new OracleParameter()
                {
                    ParameterName = "student_code",
                    Direction = ParameterDirection.Input,
                    OracleDbType = OracleDbType.Int32,
                    Value = item.student_id
                };
                OracleParameter lab_name = new OracleParameter()
                {
                    ParameterName = "lab_name",
                    Direction = ParameterDirection.Input,
                    OracleDbType = OracleDbType.Varchar2,
                    Value = item.lab_name
                };
                OracleParameter status = new OracleParameter()
                {
                    ParameterName = "status",
                    Direction = ParameterDirection.Input,
                    OracleDbType = OracleDbType.Varchar2,
                    Value = item.lab_status
                };
                command.Parameters.Add(discipline_code);
                command.Parameters.Add(teacher_code);
                command.Parameters.Add(student_code);
                command.Parameters.Add(lab_name);
                command.Parameters.Add(status);
                command.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}