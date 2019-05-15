using DECANAT.ModelData;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace DECANAT.Repozitory
{
    public class DisciplineRepozitory :IRepository<NewDiscipline,Discipline>
    {
        public IEnumerable<Discipline> GetAll(string querry = null)
        {
            OracleConnection connection = SingltoneConnection.GetInstance();
            using (OracleCommand command = connection.CreateCommand())
            {
                command.CommandType = CommandType.Text;
                command.CommandText = "select * from DISCIPLINE_LIST";
                if (querry != null) command.CommandText +=" " + querry;
                using (OracleDataReader reader = command.ExecuteReader())
                {
                    List<Discipline> discyplines = new List<Discipline>();
                    while (reader.Read())
                    {
                        discyplines.Add(new NewDiscipline
                        {
                            faculty_code = Convert.ToInt32(reader["Код_факультета"].ToString()),
                            speciality_code = Convert.ToInt32(reader["Код_специальности"].ToString()),
                            id = Convert.ToInt32(reader["Код_дисциплины"].ToString()),
                            faculty_name = reader["Название_факультета"].ToString(),
                            speciality_number = Convert.ToInt32(reader["Номер_специальности"].ToString()),
                            speciality_name = reader["Имя_специальности"].ToString(),
                            discipline_name = reader["Наименование_дисциплины"].ToString()
                        });
                    }
                    return discyplines;
                }
            }
        }

        public NewDiscipline Get(int id)
        {
            OracleConnection connection = SingltoneConnection.GetInstance();
            using (OracleCommand command = connection.CreateCommand())
            {
                command.CommandType = CommandType.Text;
                command.CommandText = "select * from DISCIPLINE_LIST where \"Код_дисциплины\"=:id";
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
                    NewDiscipline discypline = new NewDiscipline
                        {
                            faculty_code = Convert.ToInt32(reader["Код_факультета"].ToString()),
                            speciality_code = Convert.ToInt32(reader["Код_специальности"].ToString()),
                            id = Convert.ToInt32(reader["Код_дисциплины"].ToString()),
                            faculty_name = reader["Название_факультета"].ToString(),
                            speciality_number = Convert.ToInt32(reader["Номер_специальности"].ToString()),
                            speciality_name = reader["Имя_специальности"].ToString(),
                            discipline_name = reader["Наименование_дисциплины"].ToString()
                        };
                    return discypline;
                }
            }
        }

        public void Create(Discipline item)
        {
            OracleConnection connection = SingltoneConnection.GetInstance();
            using (OracleCommand command = connection.CreateCommand())
            {
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "ADD_DISCIPLINE";
                OracleParameter speciality_code_param = new OracleParameter()
                {
                    ParameterName = "speciality_code",
                    Direction = ParameterDirection.Input,
                    OracleDbType = OracleDbType.Varchar2,
                    Value = item.speciality_code
                };
                OracleParameter discipline_name_param = new OracleParameter()
                {
                    ParameterName = "discipline_name",
                    Direction = ParameterDirection.Input,
                    OracleDbType = OracleDbType.Varchar2,
                    Value = item.discipline_name
                };
                command.Parameters.Add(speciality_code_param);
                command.Parameters.Add(discipline_name_param);
                command.ExecuteNonQuery();
            }
        }

        public void Update(NewDiscipline item)
        {
            OracleConnection connection = SingltoneConnection.GetInstance();
            using (OracleCommand command = connection.CreateCommand())
            {
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "EDIT_DISCIPLINE";
                OracleParameter speciality_code_param = new OracleParameter()
                {
                    ParameterName = "speciality_code",
                    Direction = ParameterDirection.Input,
                    OracleDbType = OracleDbType.Varchar2,
                    Value = item.speciality_code
                };
                OracleParameter new_discipline_name_param = new OracleParameter()
                {
                    ParameterName = "new_discipline_name",
                    Direction = ParameterDirection.Input,
                    OracleDbType = OracleDbType.Varchar2,
                    Value = item.discipline_name
                };
                command.Parameters.Add(speciality_code_param);
                command.Parameters.Add(new_discipline_name_param);
                command.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            OracleConnection connection = SingltoneConnection.GetInstance();
            using (OracleCommand command = connection.CreateCommand())
            {
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "REMOVE_DISCIPLINE";
                OracleParameter discipline_code_param = new OracleParameter()
                {
                    ParameterName = "discipline_code",
                    Direction = ParameterDirection.Input,
                    OracleDbType = OracleDbType.Varchar2,
                    Value = id
                };
                command.Parameters.Add(discipline_code_param);
                command.ExecuteNonQuery();
            }
        }
        public List<Discipline> getTeacherDisciplines(string id)
        {
            OracleConnection connection = SingltoneConnection.GetInstance();
            using (OracleCommand command = connection.CreateCommand())
            {
                command.CommandType = CommandType.Text;
                command.CommandText = "select * from \"TEACHER_DISCIPLINE\" where \"Код_преподавателя\" = :id";
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
                    List<Discipline> disciplines = new List<Discipline>();
                    while (reader.Read())
                    {
                        disciplines.Add(new Discipline
                        {
                            discipline_name = reader["Наименование_дисциплины"].ToString(),
                            id = Convert.ToInt32(reader["Код_дисциплины"].ToString()),
                            speciality_name = reader["Имя_специальности"].ToString()
                        });
                    }
                    return disciplines;
                }
            }
        }
    }
}