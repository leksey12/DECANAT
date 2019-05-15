using DECANAT.ModelData;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace DECANAT.Repozitory
{
    public class LabRepozitory :IRepository<NewLab,Lab>
    {
        public IEnumerable<Lab> GetAll(string querry = null)
        {
            OracleConnection connection = SingltoneConnection.GetInstance();
            using (OracleCommand command = connection.CreateCommand())
            {
                command.CommandType = CommandType.Text;
                command.CommandText = "select * from LABS_DISCIPLINE";
                if (querry != null) command.CommandText += " " + querry;
                using (OracleDataReader reader = command.ExecuteReader())
                {
                    List<Lab> labs = new List<Lab>();
                    while (reader.Read())
                    {
                        labs.Add(new Lab 
                        { 
                            lab_name = reader["Название_лабораторной"].ToString(),
                            discipline = reader["Наименование_дисциплины"].ToString(),
                            speciality = reader["Имя_специальности"].ToString(),
                            discipline_id = Convert.ToInt32(reader["Код_дисциплины"].ToString()),
                            id = Convert.ToInt32(reader["Код_лабораторной"].ToString())
                        });
                    }
                    return labs;
                }
            }
        }

        public NewLab Get(int id)
        {
            OracleConnection connection = SingltoneConnection.GetInstance();
            using (OracleCommand command = connection.CreateCommand())
            {
                command.CommandType = CommandType.Text;
                command.CommandText = "select * from LABS_DISCIPLINE where \"Код_лабораторной\"=:lab_id";
                OracleParameter lab_id = new OracleParameter()
                {
                    ParameterName = "lab_id",
                    Direction = ParameterDirection.Input,
                    OracleDbType = OracleDbType.Varchar2,
                    Value = id
                };
                command.Parameters.Add(lab_id);
                using (OracleDataReader reader = command.ExecuteReader())
                {
                    reader.Read();
                    NewLab lab = new NewLab
                        {
                            lab_name = reader["Название_лабораторной"].ToString(),
                            discipline = reader["Наименование_дисциплины"].ToString(),
                            speciality = reader["Имя_специальности"].ToString(),
                            discipline_id = Convert.ToInt32(reader["Код_дисциплины"].ToString()),
                            id = Convert.ToInt32(reader["Код_лабораторной"].ToString())
                        };
                    return lab;
                }
            }
        }

        public void Create(Lab item)
        {
            OracleConnection connection = SingltoneConnection.GetInstance();
            using (OracleCommand command = connection.CreateCommand())
            {
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "ADD_LAB";
                OracleParameter discipline_id_param = new OracleParameter()
                {
                    ParameterName = "discipline_id",
                    Direction = ParameterDirection.Input,
                    OracleDbType = OracleDbType.Varchar2,
                    Value = item.discipline_id
                };
                OracleParameter discipline_name = new OracleParameter()
                {
                    ParameterName = "discipline_name",
                    Direction = ParameterDirection.Input,
                    OracleDbType = OracleDbType.Varchar2,
                    Value = item.discipline
                };
                OracleParameter lab_name = new OracleParameter()
                {
                    ParameterName = "lab_name",
                    Direction = ParameterDirection.Input,
                    OracleDbType = OracleDbType.Varchar2,
                    Value = item.lab_name
                };
                command.Parameters.Add(discipline_id_param);
                command.Parameters.Add(lab_name);
                command.ExecuteNonQuery();
            }
        }

        public void Update(NewLab item)
        {
            OracleConnection connection = SingltoneConnection.GetInstance();
            using (OracleCommand command = connection.CreateCommand())
            {
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "EDIT_LAB";
                OracleParameter lab_code_param = new OracleParameter()
                {
                    ParameterName = "speciality_name",
                    Direction = ParameterDirection.Input,
                    OracleDbType = OracleDbType.Varchar2,
                    Value = item.id
                };
                OracleParameter new_lab_name_param = new OracleParameter()
                {
                    ParameterName = "new_lab_name",
                    Direction = ParameterDirection.Input,
                    OracleDbType = OracleDbType.Varchar2,
                    Value = item.new_lab_name
                };
                command.Parameters.Add(lab_code_param);
                command.Parameters.Add(new_lab_name_param);
                command.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            OracleConnection connection = SingltoneConnection.GetInstance();
            using (OracleCommand command = connection.CreateCommand())
            {
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "REMOVE_LAB";
                OracleParameter lab_code_param = new OracleParameter()
                {
                    ParameterName = "lab_code",
                    Direction = ParameterDirection.Input,
                    OracleDbType = OracleDbType.Varchar2,
                    Value = id
                };
                command.Parameters.Add(lab_code_param);
                command.ExecuteNonQuery();
            }
        }
    }
}