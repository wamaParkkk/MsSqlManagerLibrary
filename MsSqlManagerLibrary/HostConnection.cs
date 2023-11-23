using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;

namespace MsSqlManagerLibrary
{
    public class HostConnection
    {
        public static MsSqlManager msSql = null;
        public static bool bConnection = false;

        public static string Connect()
        {
            if (msSql != null)
                return "NG";

            string strConnetion = string.Format("server=10.131.15.18;database=EE;user id=eeuser;password=Amkor123!");

            msSql = new MsSqlManager(strConnetion);

            if (msSql.OpenTest() == false)
            {
                bConnection = false;
                return "NG";
            }
            else
            {
                bConnection = true;
            }
            
            return "OK";
        }

        #region SystemStatus
        public static string Host_Get_SystemStatus(string EquipmentName, string module)
        {
            string query = "";
            query = string.Format(@"SELECT * FROM {0}", EquipmentName);

            DataTable dT = msSql.GetData(query);

            if (dT.Rows.Count < 1)
                return null;

            string rtnStr = dT.Rows[0][string.Format("{0}_Status", module)].ToString();

            return rtnStr;
        }

        public static void Host_Set_SystemStatus(string EquipmentName, string module, string setStr)
        {
            setStr = setStr.Trim();

            // 지우고 추가
            List<string> queryList = new List<string>();

            Host_Delete_SystemStatus(EquipmentName, module);

            //string query = string.Format(@"INSERT INTO {0} ({1}_Status) VALUES ('{2}')", EquipmentName, module, setStr);
            string query = string.Format("UPDATE {0} SET {1}_Status = '{2}'", EquipmentName, module, setStr);
            queryList.Add(query);

            msSql.SetData(queryList);
        }

        public static int Host_Delete_SystemStatus(string EquipmentName, string module)
        {
            string query = string.Format("DELETE FROM {0} WHERE {1}_Status", EquipmentName, module);

            int n = msSql.SetData(query);

            return n;
        }
        #endregion

        #region Module RunStatus
        public static string Host_Get_RunStatus(string EquipmentName, string module)
        {
            string query = "";
            query = string.Format(@"SELECT * FROM {0}", EquipmentName);

            DataTable dT = msSql.GetData(query);

            if (dT.Rows.Count < 1)
                return null;

            string rtnStr = dT.Rows[0][string.Format("{0}_RunStatus", module)].ToString();            

            return rtnStr;
        }

        public static void Host_Set_RunStatus(string EquipmentName, string module, string setStr)
        {
            setStr = setStr.Trim();

            // 지우고 추가
            List<string> queryList = new List<string>();

            Host_Delete_RunStatus(EquipmentName, module);

            //string query = string.Format(@"INSERT INTO {0} ({1}_RunStatus) VALUES ('{2}')", EquipmentName, module, setStr);
            string query = string.Format("UPDATE {0} SET {1}_RunStatus = '{2}'", EquipmentName, module, setStr);
            queryList.Add(query);

            msSql.SetData(queryList);
        }

        public static int Host_Delete_RunStatus(string EquipmentName, string module)
        {
            string query = string.Format("DELETE FROM {0} WHERE {1}_RunStatus", EquipmentName, module);

            int n = msSql.SetData(query);

            return n;
        }
        #endregion

        #region RecipeName
        public static string Host_Get_RecipeName(string EquipmentName, string module)
        {
            string query = "";
            query = string.Format(@"SELECT * FROM {0}", EquipmentName);

            DataTable dT = msSql.GetData(query);

            if (dT.Rows.Count < 1)
                return null;

            string rtnStr = dT.Rows[0][string.Format("{0}_RecipeName", module)].ToString();

            return rtnStr;
        }

        public static void Host_Set_RecipeName(string EquipmentName, string module, string setStr)
        {
            setStr = setStr.Trim();

            // 지우고 추가
            List<string> queryList = new List<string>();

            Host_Delete_RecipeName(EquipmentName, module);

            //string query = string.Format(@"INSERT INTO {0} ({1}_RecipeName) VALUES ('{2}')", EquipmentName, module, setStr);
            string query = string.Format("UPDATE {0} SET {1}_RecipeName = '{2}'", EquipmentName, module, setStr);
            queryList.Add(query);

            msSql.SetData(queryList);
        }

        public static int Host_Delete_RecipeName(string EquipmentName, string module)
        {
            string query = string.Format("DELETE FROM {0} WHERE {1}_RecipeName", EquipmentName, module);

            int n = msSql.SetData(query);

            return n;
        }
        #endregion

        #region AlarmName
        public static string Host_Get_AlarmName(string EquipmentName, string module)
        {
            string query = "";
            query = string.Format(@"SELECT * FROM {0}", EquipmentName);

            DataTable dT = msSql.GetData(query);

            if (dT.Rows.Count < 1)
                return null;

            string rtnStr = dT.Rows[0][string.Format("{0}_AlarmName", module)].ToString();

            return rtnStr;
        }

        public static void Host_Set_AlarmName(string EquipmentName, string module, string setStr)
        {
            setStr = setStr.Trim();

            // 지우고 추가
            List<string> queryList = new List<string>();

            Host_Delete_AlarmName(EquipmentName, module);

            //string query = string.Format(@"INSERT INTO {0} ({1}_AlarmName) VALUES ('{2}')", EquipmentName, module, setStr);
            string query = string.Format("UPDATE {0} SET {1}_AlarmName = '{2}'", EquipmentName, module, setStr);
            queryList.Add(query);

            msSql.SetData(queryList);
        }

        public static int Host_Delete_AlarmName(string EquipmentName, string module)
        {
            string query = string.Format("DELETE FROM {0} WHERE {1}_AlarmName", EquipmentName, module);

            int n = msSql.SetData(query);

            return n;
        }
        #endregion

        # region DailyCount
        public static string Host_Get_DailyCount(string EquipmentName, string module)
        {
            string query = "";
            query = string.Format(@"SELECT * FROM {0}", EquipmentName);

            DataTable dT = msSql.GetData(query);

            if (dT.Rows.Count < 1)
                return null;

            string rtnStr = dT.Rows[0][string.Format("{0}_DailyCount", module)].ToString();

            return rtnStr;
        }

        public static void Host_Set_DailyCount(string EquipmentName, string module, string setStr)
        {
            setStr = setStr.Trim();

            // 지우고 추가
            List<string> queryList = new List<string>();

            Host_Delete_DailyCount(EquipmentName, module);

            //string query = string.Format(@"INSERT INTO {0} ({1}_DailyCount) VALUES ('{2}')", EquipmentName, module, setStr);
            string query = string.Format("UPDATE {0} SET {1}_DailyCount = '{2}'", EquipmentName, module, setStr);
            queryList.Add(query);

            msSql.SetData(queryList);
        }

        public static int Host_Delete_DailyCount(string EquipmentName, string module)
        {
            string query = string.Format("DELETE FROM {0} WHERE {1}_DailyCount", EquipmentName, module);

            int n = msSql.SetData(query);

            return n;
        }
        #endregion

        #region Progress Time
        public static string Host_Get_ProgressTime(string EquipmentName, string module)
        {
            string query = "";
            query = string.Format(@"SELECT * FROM {0}", EquipmentName);

            DataTable dT = msSql.GetData(query);

            if (dT.Rows.Count < 1)
                return null;

            string rtnStr = dT.Rows[0][string.Format("{0}_ProgressTime", module)].ToString();

            return rtnStr;
        }

        public static void Host_Set_ProgressTime(string EquipmentName, string module, string setStr)
        {
            setStr = setStr.Trim();

            // 지우고 추가
            List<string> queryList = new List<string>();

            Host_Delete_ProgressTime(EquipmentName, module);

            //string query = string.Format(@"INSERT INTO {0} ({1}_ProgressTime) VALUES ('{2}')", EquipmentName, module, setStr);
            string query = string.Format("UPDATE {0} SET {1}_ProgressTime = '{2}'", EquipmentName, module, setStr);
            queryList.Add(query);

            msSql.SetData(queryList);
        }

        public static int Host_Delete_ProgressTime(string EquipmentName, string module)
        {
            string query = string.Format("DELETE FROM {0} WHERE {1}_ProgressTime", EquipmentName, module);

            int n = msSql.SetData(query);

            return n;
        }
        #endregion

        #region Process End Time
        public static string Host_Get_ProcessEndTime(string EquipmentName, string module)
        {
            string query = "";
            query = string.Format(@"SELECT * FROM {0}", EquipmentName);

            DataTable dT = msSql.GetData(query);

            if (dT.Rows.Count < 1)
                return null;

            string rtnStr = dT.Rows[0][string.Format("{0}_ProcessEndTime", module)].ToString();

            return rtnStr;
        }

        public static void Host_Set_ProcessEndTime(string EquipmentName, string module, string setStr)
        {
            setStr = setStr.Trim();

            // 지우고 추가
            List<string> queryList = new List<string>();

            Host_Delete_ProcessEndTime(EquipmentName, module);

            //string query = string.Format(@"INSERT INTO {0} ({1}_ProcessEndTime) VALUES ('{2}')", EquipmentName, module, setStr);
            string query = string.Format("UPDATE {0} SET {1}_ProcessEndTime = '{2}'", EquipmentName, module, setStr);
            queryList.Add(query);

            msSql.SetData(queryList);
        }

        public static int Host_Delete_ProcessEndTime(string EquipmentName, string module)
        {
            string query = string.Format("DELETE FROM {0} WHERE {1}_ProcessEndTime", EquipmentName, module);

            int n = msSql.SetData(query);

            return n;
        }
        #endregion

        #region Tool Sensor1
        public static string Host_Get_ToolSensor1(string EquipmentName, string module)
        {
            string query = "";
            query = string.Format(@"SELECT * FROM {0}", EquipmentName);

            DataTable dT = msSql.GetData(query);

            if (dT.Rows.Count < 1)
                return null;

            string rtnStr = dT.Rows[0][string.Format("{0}_ToolSensor1", module)].ToString();

            return rtnStr;
        }

        public static void Host_Set_ToolSensor1(string EquipmentName, string module, string setStr)
        {
            setStr = setStr.Trim();

            // 지우고 추가
            List<string> queryList = new List<string>();

            Host_Delete_ToolSensor1(EquipmentName, module);

            //string query = string.Format(@"INSERT INTO {0} ({1}_ToolSensor1) VALUES ('{2}')", EquipmentName, module, setStr);
            string query = string.Format("UPDATE {0} SET {1}_ToolSensor1 = '{2}'", EquipmentName, module, setStr);
            queryList.Add(query);

            msSql.SetData(queryList);
        }

        public static int Host_Delete_ToolSensor1(string EquipmentName, string module)
        {
            string query = string.Format("DELETE FROM {0} WHERE {1}_ToolSensor1", EquipmentName, module);

            int n = msSql.SetData(query);

            return n;
        }
        #endregion

        #region Tool Sensor2
        public static string Host_Get_ToolSensor2(string EquipmentName, string module)
        {
            string query = "";
            query = string.Format(@"SELECT * FROM {0}", EquipmentName);

            DataTable dT = msSql.GetData(query);

            if (dT.Rows.Count < 1)
                return null;

            string rtnStr = dT.Rows[0][string.Format("{0}_ToolSensor2", module)].ToString();

            return rtnStr;
        }

        public static void Host_Set_ToolSensor2(string EquipmentName, string module, string setStr)
        {
            setStr = setStr.Trim();

            // 지우고 추가
            List<string> queryList = new List<string>();

            Host_Delete_ToolSensor2(EquipmentName, module);

            //string query = string.Format(@"INSERT INTO {0} ({1}_ToolSensor2) VALUES ('{2}')", EquipmentName, module, setStr);
            string query = string.Format("UPDATE {0} SET {1}_ToolSensor2 = '{2}'", EquipmentName, module, setStr);
            queryList.Add(query);

            msSql.SetData(queryList);
        }

        public static int Host_Delete_ToolSensor2(string EquipmentName, string module)
        {
            string query = string.Format("DELETE FROM {0} WHERE {1}_ToolSensor2", EquipmentName, module);

            int n = msSql.SetData(query);

            return n;
        }
        #endregion

        # region UPH
        public static string Host_Get_UPH(string EquipmentName)
        {
            string query = "";
            query = string.Format(@"SELECT * FROM {0}", EquipmentName);

            DataTable dT = msSql.GetData(query);

            if (dT.Rows.Count < 1)
                return null;

            string rtnStr = dT.Rows[0][string.Format("UPH")].ToString();

            return rtnStr;
        }

        public static void Host_Set_UPH(string EquipmentName, string setStr)
        {
            setStr = setStr.Trim();

            // 지우고 추가
            List<string> queryList = new List<string>();

            Host_Delete_UPH(EquipmentName);
            
            string query = string.Format("UPDATE {0} SET UPH = '{1}'", EquipmentName, setStr);
            queryList.Add(query);

            msSql.SetData(queryList);
        }

        public static int Host_Delete_UPH(string EquipmentName)
        {
            string query = string.Format("DELETE FROM {0} WHERE UPH", EquipmentName);

            int n = msSql.SetData(query);

            return n;
        }
        #endregion

        #region LOG
        public static string[] Host_Get_Log(string EquipmentName, string dateTime)
        {            
            string[] rtnStr = new string[7];

            string dbConnetion = string.Format("Provider=SQLOLEDB;server=10.131.15.18;database=EE;user id=eeuser;password=Amkor123!");

            using (OleDbConnection dbConn = new OleDbConnection(dbConnetion))
            {
                dbConn.Open();

                try
                {                    
                    string query = string.Format(@"SELECT * FROM {0} WHERE Time = '{1}'", EquipmentName, dateTime);
                    OleDbCommand cmd = new OleDbCommand(query, dbConn);
                    OleDbDataReader reader;
                    reader = cmd.ExecuteReader();

                    while (true)
                    {
                        if (reader.Read())
                        {
                            rtnStr[0] = reader.GetValue(0).ToString().Trim();   // DateTime
                            rtnStr[1] = reader.GetValue(1).ToString().Trim();   // CH1 daily count
                            rtnStr[2] = reader.GetValue(2).ToString().Trim();   // CH2 daily count
                            rtnStr[3] = reader.GetValue(3).ToString().Trim();   // CH3 daily count
                            rtnStr[4] = reader.GetValue(4).ToString().Trim();   // Performance (Only daily count)
                            rtnStr[5] = reader.GetValue(5).ToString().Trim();   // Today run time
                            rtnStr[6] = reader.GetValue(6).ToString().Trim();   // Performance (실제 가동 시간 기준)
                            break;
                        }
                        else
                        {
                            rtnStr[0] = "";
                        }
                    }
                    
                    return rtnStr;
                }
                catch
                {                    
                    rtnStr[0] = "";
                    return rtnStr;
                }
                finally
                {
                    dbConn.Close();
                }            
            }     
        }

        public static void Host_Set_Log(string EquipmentName, string dateTime, string module1Value, string module2Value, string module3Value, string setStr1, string setStr2, string setStr3)
        {
            setStr1 = setStr1.Trim();
            setStr2 = setStr2.Trim();

            List<string> queryList = new List<string>();            
            
            string query = string.Format(@"INSERT INTO {0} VALUES ('{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}')", EquipmentName, dateTime, module1Value, module2Value, module3Value, setStr1, setStr2, setStr3);            
            queryList.Add(query);

            msSql.SetData(queryList);
        }
        #endregion

        #region Freezer&Refrigerator temp monitoring
        public static string Host_Get_TempHumi(string EquipmentName, int PiNo, string Item)
        {
            string query = "";
            query = string.Format(@"SELECT * FROM {0}", EquipmentName);

            DataTable dT = msSql.GetData(query);

            if (dT.Rows.Count < 1)
                return null;

            string rtnStr = dT.Rows[PiNo-1][string.Format("{0}", Item)].ToString();

            return rtnStr;
        }

        public static void Host_Set_TempHumi(string EquipmentName, string PiNo, string Item, string setStr)
        {
            setStr = setStr.Trim();

            // 지우고 추가
            List<string> queryList = new List<string>();

            Host_Delete_TempHumi(EquipmentName, PiNo, Item);
            
            string query = string.Format("UPDATE {0} SET {1} = '{2}' WHERE PiNo = {3}", EquipmentName, Item, setStr, PiNo);
            queryList.Add(query);

            msSql.SetData(queryList);
        }

        public static int Host_Delete_TempHumi(string EquipmentName, string PiNo, string Item)
        {
            string query = string.Format("DELETE FROM {0} {1} WHERE {2}", EquipmentName, Item, PiNo);

            int n = msSql.SetData(query);

            return n;
        }
        #endregion
    }
}
