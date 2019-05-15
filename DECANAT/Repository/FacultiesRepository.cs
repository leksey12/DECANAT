using System;
using System.Collections.Generic;
using System.Data;
using DECANAT.ModelData;
using DECANAT.Models;
using Oracle.ManagedDataAccess.Client;

namespace DECANAT.Repozitory
{
    public class FacultiesRepository : IRepository<NewFaculty,Faculty>
    {
        public IEnumerable<Faculty> GetAll(string querry = null)
        {
            OracleConnection connection = SingltoneConnection.GetInstance();
            using (OracleCommand command = connection.CreateCommand())
            {
                command.CommandType = CommandType.Text;
                command.CommandText = "select * from FACULTY_LIST";
                if (querry != null) command.CommandText += " " + querry;
                using (OracleDataReader reader = command.ExecuteReader())
                {
                    List<Faculty> facultys = new List<Faculty>();
                    while (reader.Read())
                    {
                        facultys.Add(new NewFaculty
                        {
                            Name = reader["Название_факультета"].ToString(),
                            id = Convert.ToInt32(reader["Код_факультета"].ToString())
                        });
                    }
                    return facultys;
                }
            }
        }
        public NewFaculty Get(int id)
        {
            OracleConnection connection = SingltoneConnection.GetInstance();
            using (OracleCommand command = connection.CreateCommand())
            {
                command.CommandType = CommandType.Text;
                command.CommandText = "select * from FACULTY_LIST where \"Код_факультета\"=:id";
                OracleParameter id_parameter = new OracleParameter()
                {
                    ParameterName = "id",
                    Direction = ParameterDirection.Input,
                    OracleDbType = OracleDbType.Varchar2,
                    Value = id
                };
                command.Parameters.Add(id_parameter);
                using (OracleDataReader reader = command.ExecuteReader())
                {

                    reader.Read();
                    NewFaculty faculty = new NewFaculty()
                    {
                        Name = reader["Название_факультета"].ToString(),
                        id = Convert.ToInt32(reader["Код_факультета"].ToString())
                    };
                    return faculty;
                }
            }
        }

        public void Create(Faculty item)
        {
            OracleConnection connection = SingltoneConnection.GetInstance();
            using (OracleCommand command = connection.CreateCommand())
            {
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "ADD_FACULTY";
                OracleParameter name_parameter = new OracleParameter()
                {
                    ParameterName = "new_faculty",
                    Direction = ParameterDirection.Input,
                    OracleDbType = OracleDbType.Varchar2,
                    Value = item.Name
                };
                command.Parameters.Add(name_parameter);
                command.ExecuteNonQuery();
            }
        }

        public void Update(NewFaculty item)
        {
            OracleConnection connection = SingltoneConnection.GetInstance();
            using (OracleCommand command = connection.CreateCommand())
            {
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "EDIT_FACULTY";
                OracleParameter identifer_parameter = new OracleParameter()
                {
                    ParameterName = "identifer",
                    Direction = ParameterDirection.Input,
                    OracleDbType = OracleDbType.Varchar2,
                    Value = item.id
                };
                OracleParameter new_name_parameter = new OracleParameter()
                {
                    ParameterName = "new_name",
                    Direction = ParameterDirection.Input,
                    OracleDbType = OracleDbType.Varchar2,
                    Value = item.NewName
                };
                command.Parameters.Add(identifer_parameter);
                command.Parameters.Add(new_name_parameter);
                command.ExecuteNonQuery();
            }
        }
        public void Delete(int id)
        {
            OracleConnection connection = SingltoneConnection.GetInstance();
            using (OracleCommand command = connection.CreateCommand())
            {
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "REMOVE_FACULTY";
                OracleParameter identifer_parameter = new OracleParameter()
                {
                    ParameterName = "identifer",
                    Direction = ParameterDirection.Input,
                    OracleDbType = OracleDbType.Varchar2,
                    Value = id
                };
                command.Parameters.Add(identifer_parameter);
                command.ExecuteNonQuery();
            }
        }
    }
}