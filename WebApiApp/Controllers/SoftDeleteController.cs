using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Http;
using System.Web.Http.Cors;
using ApplicationModel;
using ApplicationDAL;
using ApplicationBusinessLogic;

namespace WebApiApp.Controllers
{
    
        // GET: SoftDelete
        [EnableCors("", "*", "GET,POST,PUT")]
        public class SoftDeleteController : ApiController
        {
            // GET: SoftDelete

            AppModel value = new AppModel();


            static List<AppModel> getAllApps = new List<AppModel>();

            AppBL bl = new AppBL();
            public bool Put(int appId, [FromBody]int isDeleted)
            {
                return bl.SoftDeleteApp(appId, isDeleted);
            }

        }
    
}