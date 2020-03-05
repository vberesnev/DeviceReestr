using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Microsoft.Data.Sqlite;

namespace DeviceReestr.Model
{
    static class DataBase
    {
        private static string CONNECTION_STRING;
        private static string CONNECTION_STRING_SQLITE;
        private static string selectedConnection;

        static DataBase()
        {
            CONNECTION_STRING = ConfigurationManager.ConnectionStrings["DeviceReestrDBConnectionString"].ConnectionString;
            CONNECTION_STRING_SQLITE = ConfigurationManager.ConnectionStrings["DeviceReestrSqliteConnectionString"].ConnectionString;

            selectedConnection = CONNECTION_STRING_SQLITE;
        }

        internal static int TryAuthorize(User user, string password)
        {
            using (SqliteConnection sqlConn = new SqliteConnection(selectedConnection))
            {
                try
                {
                    sqlConn.Open();
                    var command = sqlConn.CreateCommand();
                    command.CommandText = $"SELECT Id FROM [Users] WHERE Login = '{user.Login}' AND Password = '{password}'";
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
            SqliteConnection sqlConn = new SqliteConnection(selectedConnection);
            try
            {
                sqlConn.Open();

                var command = sqlConn.CreateCommand();
                command.CommandText = @"INSERT INTO [Devices] VALUES ($id, $serialNo, $type, $description, $owner, $createAt)";
                command.Parameters.AddWithValue("$id", device.Id);
                command.Parameters.AddWithValue("$serialNo", device.SerialNo);
                command.Parameters.AddWithValue("$type", device.Type);
                command.Parameters.AddWithValue("$description", device.Description);
                command.Parameters.AddWithValue("$owner", device.Owner.Id);
                command.Parameters.AddWithValue("$createAt", device.CreatedAt);

                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                sqlConn.Close();
            }
        }

        internal static List<Device> TryGetDevicesByUser(User user)
        {
            List<Device> list = new List<Device>();
            using (SqliteConnection sqlConn = new SqliteConnection(selectedConnection))
            {
                try
                {
                    sqlConn.Open();
                    var command = sqlConn.CreateCommand();
                    command.CommandText = $"SELECT * FROM [Devices] WHERE Owner = {user.Id}";
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
            using (SqliteConnection sqlConn = new SqliteConnection(selectedConnection))
            {
                try
                {
                    sqlConn.Open();
                    var command = sqlConn.CreateCommand();
                    command.CommandText = $"SELECT * FROM [Devices]";
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
