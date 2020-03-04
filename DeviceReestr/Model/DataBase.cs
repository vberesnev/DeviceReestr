using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace DeviceReestr.Model
{
    static class DataBase
    {
        private static string CONNECTION_STRING;

        static DataBase()
        {
            CONNECTION_STRING = ConfigurationManager.ConnectionStrings["DeviceReestrDBConnectionString"].ConnectionString;
        }

        internal static int TryAuthorize(User user, string password)
        {
            using (SqlConnection sqlConn = new SqlConnection(CONNECTION_STRING))
            {
                try
                {
                    sqlConn.Open();
                    SqlCommand command = new SqlCommand($"SELECT TOP 1 Id FROM [Users] WHERE Login = '{user.Login}' AND Password = '{password}'", sqlConn);
                    var reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        int id = 0;
                        while (reader.Read())
                        {
                            id = Convert.ToInt32(reader[0]);
                        }
                        return id;
                    }
                    else
                        return 0;
                }
                catch (Exception ex)
                {
                    return -1;
                }
            }
        }

        internal static bool TrySave(Device device)
        {
            SqlConnection connection = new SqlConnection(CONNECTION_STRING);
            try
            {
                connection.Open();

                SqlCommand command = new SqlCommand("sp_InsertDevice", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter idParam = new SqlParameter() { ParameterName = "@id", Value = device.Id };
                command.Parameters.Add(idParam);
                SqlParameter serialParam = new SqlParameter() { ParameterName = "@serialNo", Value = device.SerialNo };
                command.Parameters.Add(serialParam);
                SqlParameter typeParam = new SqlParameter() { ParameterName = "@type", Value = device.Type };
                command.Parameters.Add(typeParam);
                SqlParameter descParam = new SqlParameter() { ParameterName = "@description", Value = device.Description };
                command.Parameters.Add(descParam);
                SqlParameter ownerParam = new SqlParameter() { ParameterName = "@owner", Value = device.Owner.Id };
                command.Parameters.Add(ownerParam);
                SqlParameter dateParam = new SqlParameter() { ParameterName = "@createAt", Value = device.CreatedAt };
                command.Parameters.Add(dateParam);

                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        internal static List<Device> TryGetDevicesByUser(User user)
        {
            List<Device> list = new List<Device>();
            using (SqlConnection sqlConn = new SqlConnection(CONNECTION_STRING))
            {
                try
                {
                    sqlConn.Open();
                    SqlCommand command = new SqlCommand($"SELECT * FROM [Devices] WHERE Owner = {user.Id}", sqlConn);
                    var reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            list.Add(new Device(reader[0].ToString(), 
                                                reader[1].ToString(), 
                                                reader[2].ToString(), 
                                                reader[3].ToString(), 
                                                Convert.ToInt32(reader[4]), 
                                                Convert.ToDateTime(reader[5])));
                        }
                        return list;
                    }
                    else
                        return list;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

        internal static List<Device> TryGetDevicesAll()
        {
            List<Device> list = new List<Device>();
            using (SqlConnection sqlConn = new SqlConnection(CONNECTION_STRING))
            {
                try
                {
                    sqlConn.Open();
                    SqlCommand command = new SqlCommand($"SELECT * FROM [Devices]", sqlConn);
                    var reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            list.Add(new Device(reader[0].ToString(),
                                                reader[1].ToString(),
                                                reader[2].ToString(),
                                                reader[3].ToString(),
                                                Convert.ToInt32(reader[4]),
                                                Convert.ToDateTime(reader[5])));
                        }
                        return list;
                    }
                    else
                        return list;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }
    }

}
