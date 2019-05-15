using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using DECANAT.ModelData;
using Oracle.ManagedDataAccess.Client;

namespace DECANAT.Repozitory
{
    public class SpecialityRepozitory : IRepository<NewSpeciality, Speciality>
    {
        public IEnumerable<Speciality> GetAll(string querry = null)
        {
            OracleConnection connection = SingltoneConnection.GetInstance();
            using (OracleCommand command = connection.CreateCommand())
            {
                command.CommandType = CommandType.Text;
                command.CommandText = "select * from SPECIALITY_LIST";
                if (querry != null)
                {
                    command.CommandText += " " + querry;
                }
                using (OracleDataReader reader = command.ExecuteReader())
                {
                    List<Speciality> specyalitys = new List<Speciality>();
                    while (reader.Read())
                    {
                        specyalitys.Add(new NewSpeciality
                        {
                            faculty_name = reader["Название_факультета"].ToString(),
                            faculty_code = Convert.ToInt32(reader["Код_факультета"].ToString()),
                            id = Convert.ToInt32(reader["Код_специальности"].ToString()),
                            speciality_number = Convert.ToInt32(reader["Номер_специальности"].ToString()),
                            speciality_name = reader["Имя_специальности"].ToString(),
                            group_count = Convert.ToInt32(reader["Групп"].ToString())
                        });
                    }
                    return specyalitys;
                }
            }
        }

        public NewSpeciality Get(int id)
        {
            OracleConnection connection = SingltoneConnection.GetInstance();
            using (OracleCommand command = connection.CreateCommand())
            {
                command.CommandType = CommandType.Text;
                command.CommandText = "select * from SPECIALITY_LIST where \"Код_специальности\"=:id";
                OracleParameter id_parametr = new OracleParameter()
                {
                    ParameterName = "id",
                    Direction = ParameterDirection.Input,
                    OracleDbType = OracleDbType.Varchar2,
                    Value = id
                };
                command.Parameters.Add(id_parametr);
                using (OracleDataReader reader = command.ExecuteReader())
                {
                    reader.Read();
                    NewSpeciality specyality = new NewSpeciality
                    {
                        faculty_name = reader["Название_факультета"].ToString(),
                        faculty_code = Convert.ToInt32(reader["Код_факультета"].ToString()),
                        id = Convert.ToInt32(reader["Код_специальности"].ToString()),
                        speciality_number = Convert.ToInt32(reader["Номер_специальности"].ToString()),
                        speciality_name = reader["Имя_специальности"].ToString(),
                        group_count = Convert.ToInt32(reader["Групп"].ToString())
                    };
                    return specyality;
                }
            }
        }

        public void Create(Speciality item)
        {
            OracleConnection connection = SingltoneConnection.GetInstance();
            using (OracleCommand command = connection.CreateCommand())
            {
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "ADD_SPECIALITIS";
                OracleParameter faculty_name = new OracleParameter()
                {
                    ParameterName = "faculty_code",
                    Direction = ParameterDirection.Input,
                    OracleDbType = OracleDbType.Varchar2,
                    Value = item.faculty_code
                };
                OracleParameter speciality_number = new OracleParameter()
                {
                    ParameterName = "speciality_number",
                    Direction = ParameterDirection.Input,
                    OracleDbType = OracleDbType.Varchar2,
                    Value = item.speciality_number
                };
                OracleParameter speciality_name = new OracleParameter()
                {
                    ParameterName = "speciality_name",
                    Direction = ParameterDirection.Input,
                    OracleDbType = OracleDbType.Varchar2,
                    Value = item.speciality_name
                };
                command.Parameters.Add(faculty_name);
                command.Parameters.Add(speciality_number);
                command.Parameters.Add(speciality_name);
                command.ExecuteNonQuery();
            }
        }

        public void Update(NewSpeciality item)
        {
            OracleConnection connection = SingltoneConnection.GetInstance();
            using (OracleCommand command = connection.CreateCommand())
            {
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "EDIT_SPECIALITIS";
                OracleParameter faculty_code = new OracleParameter()
                {
                    ParameterName = "faculty_code",
                    Direction = ParameterDirection.Input,
                    OracleDbType = OracleDbType.Varchar2,
                    Value = item.faculty_code
                };
                OracleParameter speciality_code = new OracleParameter()
                {
                    ParameterName = "speciality_code",
                    Direction = ParameterDirection.Input,
                    OracleDbType = OracleDbType.Varchar2,
                    Value = item.id
                };
                OracleParameter new_speciality_number = new OracleParameter()
                {
                    ParameterName = "new_speciality_number",
                    Direction = ParameterDirection.Input,
                    OracleDbType = OracleDbType.Varchar2,
                    Value = item.new_speciality_number
                };
                OracleParameter new_speciality_name = new OracleParameter()
                {
                    ParameterName = "new_speciality_name",
                    Direction = ParameterDirection.Input,
                    OracleDbType = OracleDbType.Varchar2,
                    Value = item.new_speciality_name
                };
                command.Parameters.Add(faculty_code);
                command.Parameters.Add(speciality_code);
                command.Parameters.Add(new_speciality_number);
                command.Parameters.Add(new_speciality_name);
                command.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            OracleConnection connection = SingltoneConnection.GetInstance();
            using (OracleCommand command = connection.CreateCommand())
            {
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "REMOVE_SPECIALITIS";
                OracleParameter speciality_code = new OracleParameter()
                {
                    ParameterName = "speciality_code",
                    Direction = ParameterDirection.Input,
                    OracleDbType = OracleDbType.Varchar2,
                    Value = id
                };
                command.Parameters.Add(speciality_code);
                command.ExecuteNonQuery();
            }
        }
    }
}