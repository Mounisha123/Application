using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationDAL;
using ApplicationModel;

namespace ApplicationBusinessLogic
{
    public class AppBL
    {
        AppDAL dal;
        public AppBL()
        {
            dal = new AppDAL();
        }
        public bool InsertSavePage(AppModel saveData)
        {

            return dal.ApplicationSaveData(saveData);
        }
        public List<AppModel> GetAppData()
        {
            return dal.GetAppPageData();
        }
        public List<AppModel> GetAppDataforUpdatePage(int appId)
        {
            return dal.GetAppForUpdatePage(appId);
        }
        public bool UpdateApp(int appId, AppModel value)
        {
            return dal.AppUpdate(appId, value);
        }
        public bool SoftDeleteApp(int appId, int isDeleted)
        {
            return dal.SoftDelete(appId, isDeleted);
        }
    }
}
