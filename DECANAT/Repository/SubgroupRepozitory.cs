using DECANAT.ModelData;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace DECANAT.Repozitory
{
    public class SubgroupRepozitory : IRepository<Subgroup, Subgroup>
    {
        public IEnumerable<Subgroup> GetAll(string querry = null)
        {
            OracleConnection connection = SingltoneConnection.GetInstance();
            using (OracleCommand command = connection.CreateCommand())
            {
                command.CommandType = CommandType.Text;
                command.CommandText = "select * from SUBGROUP_LIST";
                if (querry != null) command.CommandText += " " + querry;
                using (OracleDataReader reader = command.ExecuteReader())
                {
                    List<Subgroup> subgroups = new List<Subgroup>();
                    while (reader.Read())
                    {
                        subgroups.Add(new Subgroup
                        {
                            id = Convert.ToInt32(reader["Код_подгруппы"].ToString()),
                            group_id = Convert.ToInt32(reader["Код_группы"].ToString()),
                            faculty_name = reader["Факультет"].ToString(),
                            speciality_name = reader["Специальность"].ToString(),
                            speciality_id = Convert.ToInt32(reader["Код_специальности"].ToString()),
                            speciality_number = Convert.ToInt32(reader["Номер_специальности"].ToString()),
                            coors = Convert.ToInt32(reader["Курс"].ToString()),
                            year = Convert.ToInt32(reader["Год_поступления"].ToString()),
                            group_number = Convert.ToInt32(reader["Номер_группы"].ToString()),
                            subgroup_number = Convert.ToInt32(reader["Номер_подгруппы"].ToString()),
                            peoples_count = Convert.ToInt32(reader["Студентов"].ToString())
                        });
                    }
                    return subgroups;
                }
            }
        }

        public Subgroup Get(int id)
        {
            OracleConnection connection = SingltoneConnection.GetInstance();
            using (OracleCommand command = connection.CreateCommand())
            {
                command.CommandType = CommandType.Text;
                command.CommandText = "select * from SUBGROUP_LIST where \"Код_подгруппы\"=:id";
                OracleParameter group_code_param = new OracleParameter()
                {
                    ParameterName = "id",
                    Direction = ParameterDirection.Input,
                    OracleDbType = OracleDbType.Varchar2,
                    Value = id
                };
                command.Parameters.Add(group_code_param);
                using (OracleDataReader reader = command.ExecuteReader())
                {
                    reader.Read();
                    Subgroup subgroup = new Subgroup
                    {
                        id = Convert.ToInt32(reader["Код_подгруппы"].ToString()),
                        group_id = Convert.ToInt32(reader["Код_группы"].ToString()),
                        faculty_name = reader["Факультет"].ToString(),
                        speciality_name = reader["Специальность"].ToString(),
                        speciality_id = Convert.ToInt32(reader["Код_специальности"].ToString()),
                        speciality_number = Convert.ToInt32(reader["Номер_специальности"].ToString()),
                        coors = Convert.ToInt32(reader["Курс"].ToString()),
                        year = Convert.ToInt32(reader["Год_поступления"].ToString()),
                        group_number = Convert.ToInt32(reader["Номер_группы"].ToString()),
                        subgroup_number = Convert.ToInt32(reader["Номер_подгруппы"].ToString()),
                        peoples_count = Convert.ToInt32(reader["Студентов"].ToString())
                    };
                    return subgroup;
                }
            }
        }

        public void Create(Subgroup item)
        {
            OracleConnection connection = SingltoneConnection.GetInstance();
            using (OracleCommand command = connection.CreateCommand())
            {
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "ADD_SUBGROUP";
                OracleParameter group_code_param = new OracleParameter()
                {
                    ParameterName = "group_code",
                    Direction = ParameterDirection.Input,
                    OracleDbType = OracleDbType.Int32,
                    Value = item.group_id
                };
                OracleParameter subgroup_number_param = new OracleParameter()
                {
                    ParameterName = "subgroup_number",
                    Direction = ParameterDirection.Input,
                    OracleDbType = OracleDbType.Int32,
                    Value = item.subgroup_number
                };
                command.Parameters.Add(group_code_param);
                command.Parameters.Add(subgroup_number_param);
                command.ExecuteNonQuery();
            }
        }

        public void Update(Subgroup item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            OracleConnection connection = SingltoneConnection.GetInstance();
            using (OracleCommand command = connection.CreateCommand())
            {
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "REMOVE_SUBGROUP";
                OracleParameter subgroup_code_param = new OracleParameter()
                {
                    ParameterName = "subgroup_code",
                    Direction = ParameterDirection.Input,
                    OracleDbType = OracleDbType.Int32,
                    Value = id
                };
                command.Parameters.Add(subgroup_code_param);
                command.ExecuteNonQuery();
            }
        }
    }
}