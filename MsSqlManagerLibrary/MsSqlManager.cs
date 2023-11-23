using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading;

namespace MsSqlManagerLibrary
{
    public class MsSqlManager
    {
        private string sqlConnectionString;
        int GetRetryMax = 5;
        int RetryMax = 5;
        
        public string ParameterServerIP { get; set; }

        public string ParameterDatabaseName { get; set; }

        public string ParameterUserId { get; set; }

        public string ParameterPassword { get; set; }

        public string DatabasePath { get; set; }

        // Database가 존재 하지 않을 경우 처리를 위하여 Datasource를 파싱 및 재 조합
        public MsSqlManager(string sqlConnectionString)
        {
            if (sqlConnectionString.Substring(0, 1) == "D")
            {

            }
            else
            {
                ParameterServerIP = sqlConnectionString.Split(';')[0].Split('=')[1].ToString();
                ParameterDatabaseName = sqlConnectionString.Split(';')[1].Split('=')[1].ToString();
                ParameterUserId = sqlConnectionString.Split(';')[2].Split('=')[1].ToString();
                ParameterPassword = sqlConnectionString.Split(';')[3].Split('=')[1].ToString();

            }            

            this.sqlConnectionString = sqlConnectionString;
        }

        public bool OpenTest(bool first = true)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(sqlConnectionString))
                {
                    connection.Open();
                }

                return true;
            }            
            catch (Exception)
            {                
                //
            }

            return false;
        }

        public DataTable GetData(string queryString, int retry = 1)
        {
            DataTable dT = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(sqlConnectionString))
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand(queryString, connection))
                    {
                        using (SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd))
                        {
                            dataAdapter.Fill(dT);
                        }
                    }
                }
            }
            catch (Exception)
            {
                if (retry == GetRetryMax)
                {
                    
                }
                else
                {
                    Thread.Sleep(100);                    
                    return GetData(queryString, ++retry);
                }
            }
            return dT;
        }

        public int SetData(string queryString, SqlParameter[] sqlParam = null, CommandType cmdType = CommandType.Text, int retry = 1)
        {
            int ret = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(sqlConnectionString))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(queryString, connection))
                    {
                        if (sqlParam != null)
                            cmd.Parameters.AddRange(sqlParam);

                        cmd.CommandType = cmdType;
                        cmd.CommandTimeout = 300;

                        ret = cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException)
            {
                if (retry == RetryMax)
                {                    
                    return ret;
                }
                else
                {
                    Thread.Sleep(100);                    
                    return SetData(queryString, sqlParam, cmdType, ++retry);
                }
            }
            return ret;
        }

        public int SetData(List<string> queryList, CommandType cmdType = CommandType.Text, int retry = 1)
        {
            if (queryList.Count == 0)
                return 0;

            int ret = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(sqlConnectionString))
                {
                    connection.Open();
                    SqlTransaction transaction = connection.BeginTransaction();

                    foreach (var query in queryList)
                    {
                        using (SqlCommand cmd = new SqlCommand(query, connection))
                        {
                            cmd.CommandType = cmdType;
                            cmd.Transaction = transaction;
                            ret = cmd.ExecuteNonQuery();
                        }
                    }
                    transaction.Commit();                    
                }
            }
            catch (SqlException)
            {
                if (retry == RetryMax)
                {                    
                    return ret;
                }
                else
                {
                    Thread.Sleep(100);                    
                    return SetData(queryList, cmdType, ++retry);
                }
            }
            return ret;
        }        
    }
}
