using DECANAT.ModelData;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace DECANAT.Repozitory
{
    public class GroupRepozitory:IRepository<Group,Group>
    {
        public IEnumerable<Group> GetAll(string querry = null)
        {
            OracleConnection connection = SingltoneConnection.GetInstance();
            using (OracleCommand command = connection.CreateCommand())
            {
                command.CommandType = CommandType.Text;
                command.CommandText = "select * from KOORS_LIST";
                if (querry != null) command.CommandText += " " + querry;
                using (OracleDataReader reader = command.ExecuteReader())
                {
                    List<Group> groups = new List<Group>();
                    while (reader.Read())
                    {
                        groups.Add(new Group
                        {
                            id = Convert.ToInt32(reader["Код_группы"].ToString()),
                            faculty_name = reader["Факультет"].ToString(),
                            speciality_name = reader["Специальность"].ToString(),
                            speciality_id = Convert.ToInt32(reader["Код_специальности"].ToString()),
                            speciality_number = Convert.ToInt32(reader["Номер_специальности"].ToString()),
                            coors = Convert.ToInt32(reader["Курс"].ToString()),
                            year = Convert.ToInt32(reader["Год_поступления"].ToString()),
                            group_number = reader["Наименование_группы"].ToString(),
                            peoples_count = Convert.ToInt32(reader["Студентов"].ToString())
                        });
                    }
                    return groups;
                }
            }
        }

        public Group Get(int id)
        {
            OracleConnection connection = SingltoneConnection.GetInstance();
            using (OracleCommand command = connection.CreateCommand())
            {
                command.CommandType = CommandType.Text;
                command.CommandText = "select * from KOORS_LIST where \"Код_группы\"=:id";
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
                    Group group = new Group()
                        {
                            id = Convert.ToInt32(reader["Код_группы"].ToString()),
                            faculty_name = reader["Факультет"].ToString(),
                            speciality_name = reader["Специальность"].ToString(),
                            speciality_id = Convert.ToInt32(reader["Код_специальности"].ToString()),
                            speciality_number = Convert.ToInt32(reader["Номер_специальности"].ToString()),
                            coors = Convert.ToInt32(reader["Курс"].ToString()),
                            year = Convert.ToInt32(reader["Год_поступления"].ToString()),
                        group_number = reader["Наименование_группы"].ToString(),
                        peoples_count = Convert.ToInt32(reader["Студентов"].ToString())

                    };
                    return group;
                }
            }
        }

        public void Create(Group item)
        {
            OracleConnection connection = SingltoneConnection.GetInstance();
            using (OracleCommand command = connection.CreateCommand())
            {
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "ADD_GROUP";
                OracleParameter speciality_code_param = new OracleParameter()
                {
                    ParameterName = "speciality_code",
                    Direction = ParameterDirection.Input,
                    OracleDbType = OracleDbType.Varchar2,
                    Value = item.speciality_id
                };
                OracleParameter age_param = new OracleParameter()
                {
                    ParameterName = "age",
                    Direction = ParameterDirection.Input,
                    OracleDbType = OracleDbType.Varchar2,
                    Value = item.year
                };
                OracleParameter group_number_param = new OracleParameter()
                {
                    ParameterName = "group_number",
                    Direction = ParameterDirection.Input,
                    OracleDbType = OracleDbType.Varchar2,
                    Value = item.group_number
                };
                command.Parameters.Add(speciality_code_param);
                command.Parameters.Add(age_param);
                command.Parameters.Add(group_number_param);
                command.ExecuteNonQuery();
            }
        }

        public void Update(Group item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            OracleConnection connection = SingltoneConnection.GetInstance();
            using (OracleCommand command = connection.CreateCommand())
            {
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "REMOVE_GROUP";
                OracleParameter id_param = new OracleParameter()
                {
                    ParameterName = "group_code",
                    Direction = ParameterDirection.Input,
                    OracleDbType = OracleDbType.Varchar2,
                    Value = id
                };
                command.Parameters.Add(id_param);
                command.ExecuteNonQuery();
            }
        }
    }
}