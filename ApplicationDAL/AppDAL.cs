using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using ApplicationModel;

namespace ApplicationDAL
{
    public class AppDAL
    {
        SqlConnection conn;
        SqlCommand cmdAppPage, cmdGetApps, cmdUpdate, cmdDelete;
        public AppDAL()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conApp"].ConnectionString);
        }

        public bool ApplicationSaveData(AppModel saveData)
        {
            bool applicationStatus = false;
            conn.Open();
            cmdAppPage = new SqlCommand("proc_insertApp", conn);

            cmdAppPage.Parameters.AddWithValue("@appName", saveData.appName);
            cmdAppPage.Parameters.AddWithValue("@appDesp", saveData.appDesp);
            cmdAppPage.Parameters.AddWithValue("@isDeleted", saveData.isDeleted);
            cmdAppPage.CommandType = CommandType.StoredProcedure;


            if (cmdAppPage.ExecuteNonQuery() > 0)
            {
                return applicationStatus = true;
            }
            conn.Close();
            return applicationStatus;
        }
        public List<AppModel> GetAppPageData()
        {
            conn.Open();
            List<AppModel> getAll = new List<AppModel>();
            cmdGetApps = new SqlCommand("getDetails", conn);
            cmdGetApps.CommandType = CommandType.StoredProcedure;
            AppModel GetApp;
            SqlDataReader dataReader = cmdGetApps.ExecuteReader();
            try
            {
                while (dataReader.Read())
                {
                    GetApp = new AppModel();
                    GetApp.appId = Convert.ToInt32(dataReader[0].ToString());
                    GetApp.appName = dataReader[1].ToString();
                    GetApp.appDesp = dataReader[2].ToString();
                    
                    getAll.Add(GetApp);


                }
            }
            catch (Exception Io)
            {
                Console.WriteLine("Exception");
            }


            conn.Close();
            return getAll;
        }
        public List<AppModel> GetAppForUpdatePage(int userId)
        {
            conn.Open();
            List<AppModel> getAll = new List<AppModel>();
            cmdGetApps = new SqlCommand("getDetails", conn);
            cmdGetApps.CommandType = CommandType.StoredProcedure;
            AppModel GetApp;
            SqlDataReader dataReader = cmdGetApps.ExecuteReader();
            try
            {
                while (dataReader.Read())
                {
                    GetApp = new AppModel();
                    GetApp.appName = dataReader[1].ToString();
                    GetApp.appDesp = dataReader[2].ToString();
                    getAll.Add(GetApp);
                }
            }
            catch (Exception Io)
            {
                Console.WriteLine("Exception");
            }

            conn.Close();
            return getAll;
        }
        public bool AppUpdate(int appId, AppModel data)
        {

            bool applicationStatus = false;
            conn.Open();
            try
            {
                cmdUpdate = new SqlCommand("proc_updateApp", conn);
                cmdUpdate.Parameters.Add("@appId", SqlDbType.Int);
                cmdUpdate.Parameters.Add("@appName", SqlDbType.NVarChar, 200);
                cmdUpdate.Parameters.Add("@appDesp", SqlDbType.NVarChar, 200);
                cmdUpdate.Parameters[0].Value = appId;
                cmdUpdate.Parameters[1].Value = data.appName;
                cmdUpdate.Parameters[2].Value = data.appDesp;
                cmdUpdate.CommandType = CommandType.StoredProcedure;
                if (cmdUpdate.ExecuteNonQuery() > 0)
                {
                    return applicationStatus = true;
                }
            }
            catch (Exception IO)
            {
                Console.WriteLine("update");
            }
            conn.Close();
            return applicationStatus;
        }

        public bool SoftDelete(int appId, int isDeleted)
        {
            bool applicationStatus = false;
            conn.Open();
            cmdDelete = new SqlCommand("softDelete", conn);
            cmdDelete.Parameters.AddWithValue("@appId", appId);
            cmdDelete.Parameters.AddWithValue("@isDeleted", isDeleted);
            cmdDelete.CommandType = CommandType.StoredProcedure;
            if (cmdDelete.ExecuteNonQuery() > 0)
            {
                return applicationStatus = true;
            }
            conn.Close();
            return applicationStatus;
        }

    }
}
