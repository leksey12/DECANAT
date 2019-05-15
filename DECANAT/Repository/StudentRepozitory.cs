using DECANAT.ModelData;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace DECANAT.Repozitory
{
    public class StudentRepozitory: IRepository<NewStudent,Student>
    {
        public IEnumerable<Student> GetAll(string querry = null)
        {
            OracleConnection connection = SingltoneConnection.GetInstance();
            using (OracleCommand command = connection.CreateCommand())
            {
                command.CommandType = CommandType.Text;
                command.CommandText = "select * from STUDENT_LIST";
                if (querry != null){ command.CommandText += " " + querry; }
                using (OracleDataReader reader = command.ExecuteReader())
                {
                    List<Student> student = new List<Student>();
                    while (reader.Read())
                    {
                        student.Add(new Student
                        {
                            FIO = reader["ФИО"].ToString(),
                            faculty_name = reader["Факультет"].ToString(),
                            speciality_name = reader["Специальность"].ToString(),
                            speciality_id = Convert.ToInt32(reader["Код_специальности"].ToString()),
                            speciality_number = Convert.ToInt32(reader["Номер_специальности"].ToString()),
                            year = Convert.ToInt32(reader["Год_поступления"].ToString()),
                            coors = Convert.ToInt32(reader["Курс"].ToString()),
                            group_id = Convert.ToInt32(reader["Код_группы"].ToString()),
                            subgroup_id = Convert.ToInt32(reader["Код_подгруппы"].ToString()),
                            subgroup_number = Convert.ToInt32(reader["Номер_подгруппы"].ToString()),
                            group_number = Convert.ToInt32(reader["Номер_группы"].ToString()),
                            id = Convert.ToInt32(reader["Код_студента"].ToString())
                        });
                    }
                    return student;
                }
            }
        }

        public NewStudent Get(int id)
        {
            OracleConnection connection = SingltoneConnection.GetInstance();
            using (OracleCommand command = connection.CreateCommand())
            {
                command.CommandType = CommandType.Text;
                command.CommandText = "select * from STUDENT_LIST where \"Код_студента\" =:id";
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
                    NewStudent student = new NewStudent
                        {
                            FIO = reader["ФИО"].ToString(),
                            faculty_name = reader["Факультет"].ToString(),
                            speciality_name = reader["Специальность"].ToString(),
                            speciality_id = Convert.ToInt32(reader["Код_специальности"].ToString()),
                            speciality_number = Convert.ToInt32(reader["Номер_специальности"].ToString()),
                            year = Convert.ToInt32(reader["Год_поступления"].ToString()),
                            coors = Convert.ToInt32(reader["Курс"].ToString()),
                            group_id = Convert.ToInt32(reader["Код_группы"].ToString()),
                            subgroup_id = Convert.ToInt32(reader["Код_подгруппы"].ToString()),
                            subgroup_number = Convert.ToInt32(reader["Номер_подгруппы"].ToString()),
                            group_number = Convert.ToInt32(reader["Номер_группы"].ToString()),
                            id = Convert.ToInt32(reader["Код_студента"].ToString())
                        };
                    return student;
                }
            }
        }

        public void Create(Student item)
        {
            OracleConnection connection = SingltoneConnection.GetInstance();
            using (OracleCommand command = connection.CreateCommand())
            {
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "ADD_STUDENT";
                OracleParameter subgroup_code = new OracleParameter()
                {
                    ParameterName = "subgroup_code",
                    Direction = ParameterDirection.Input,
                    OracleDbType = OracleDbType.Varchar2,
                    Value = item.subgroup_id
                };
                OracleParameter student_name = new OracleParameter()
                {
                    ParameterName = "student_name",
                    Direction = ParameterDirection.Input,
                    OracleDbType = OracleDbType.Varchar2,
                    Value = item.FIO
                };
                command.Parameters.Add(subgroup_code);
                command.Parameters.Add(student_name);
                command.ExecuteNonQuery();
            }
        }

        public void Update(NewStudent item)
        {
            OracleConnection connection = SingltoneConnection.GetInstance();
            using (OracleCommand command = connection.CreateCommand())
            {
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "EDIT_STUDENT";
                OracleParameter subgroup_code = new OracleParameter()
                {
                    ParameterName = "student_code",
                    Direction = ParameterDirection.Input,
                    OracleDbType = OracleDbType.Varchar2,
                    Value = item.id
                };
                OracleParameter new_student_name = new OracleParameter()
                {
                    ParameterName = "new_student_name",
                    Direction = ParameterDirection.Input,
                    OracleDbType = OracleDbType.Varchar2,
                    Value = item.new_FIO
                };
                command.Parameters.Add(subgroup_code);
                command.Parameters.Add(new_student_name);
                command.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            OracleConnection connection = SingltoneConnection.GetInstance();
            using (OracleCommand command = connection.CreateCommand())
            {
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "REMOVE_STUDENT";
                OracleParameter student_code = new OracleParameter()
                {
                    ParameterName = "student_code",
                    Direction = ParameterDirection.Input,
                    OracleDbType = OracleDbType.Varchar2,
                    Value = id
                };
                command.Parameters.Add(student_code);
                command.ExecuteNonQuery();
            }
        }
    }
}