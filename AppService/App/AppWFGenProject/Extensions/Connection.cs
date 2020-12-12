using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace AppWFGenProject.Extensions
{
    public class Connection
    {
        public bool ConnectTest(string server, string user, string pass, string db)
        {
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = server;
                builder.UserID = user;
                builder.Password = pass;
                builder.InitialCatalog = db;

                // Connect to SQL
                //Console.Write("Connecting to SQL Server ... ");
                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    connection.Open();

                    connection.Close();
                    return true;
                }
            }
            catch (SqlException ex)
            {
                return false;

            }
        }
        public SqlConnectionStringBuilder Connect()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = ConfigurationSettings.AppSettings["DataSource"].ToString();
            builder.UserID = ConfigurationSettings.AppSettings["UserID"].ToString();
            builder.Password = ConfigurationSettings.AppSettings["Password"].ToString();
            builder.InitialCatalog = ConfigurationSettings.AppSettings["InitialCatalog"].ToString();
            return builder;
        }
        public DataTable GetAllTable(string server, string user, string pass, string db)
        {
            DataTable dt = new DataTable();
            string queryString = @"SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE' AND TABLE_CATALOG = 'dbName'";
            using (SqlConnection cnn = new SqlConnection(Connect().ConnectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    SqlDataAdapter da = new SqlDataAdapter();
                    using (SqlConnection connection = new SqlConnection(Connect().ConnectionString))
                    {
                        SqlCommand command = new SqlCommand(queryString, connection);
                        //command.Parameters.AddWithValue("@tPatSName", "Your-Parm-Value");
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        try
                        {
                            while (reader.Read())
                            {
                                //Console.WriteLine(String.Format("{0}, {1}", reader["tPatCulIntPatIDPk"], reader["tPatSFirstname"]));// etc
                            }
                        }
                        finally
                        {
                            reader.Close();
                            cmd.Dispose();
                            cnn.Close();
                        }
                        cnn.Close();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Can not open connection ! ");
                }
            }
            return dt;
        }
        public DataTable GetAllEntry(string db, string selectkey, string colname)
        {
            DataTable dt = new DataTable();
            using (SqlConnection cnn = new SqlConnection(Connect().ConnectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    SqlDataAdapter da = new SqlDataAdapter();
                    string _storeproce = ConfigurationSettings.AppSettings["SPGetALLEntry"].ToString();
                    try
                    {
                        cmd = new SqlCommand(_storeproce, cnn);
                        cmd.Parameters.Add(new SqlParameter("@DBlink", db));
                        cmd.Parameters.Add(new SqlParameter("@SearchKey", selectkey));
                        cmd.Parameters.Add(new SqlParameter("@ColName", "[" + colname + "]"));
                        cmd.CommandType = CommandType.StoredProcedure;
                        da.SelectCommand = cmd;
                        da.Fill(dt);
                    }
                    catch (Exception ex)
                    {

                    }
                    finally
                    {
                        cmd.Dispose();
                        cnn.Close();
                    }
                    cnn.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Can not open connection ! ");
                }
            }
            return dt;
        }
        public HashSet<string> ConvertDTRowsToList(DataTable dt, string colname)
        {
            HashSet<string> _newList = new HashSet<string>();
            foreach (DataRow row in dt.Rows)
            {
                _newList.Add(row[colname].ToString());
            }
            return _newList;
        }
        public HashSet<string> getListEntry(string db, string selectkey, string colname)
        {
            DataTable dt = GetAllEntry(db, selectkey, colname);
            return ConvertDTRowsToList(dt, colname);
        }
    }
}
