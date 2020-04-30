using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using ApplicationModel;
using ApplicationDAL;
using ApplicationBusinessLogic;

namespace WebApiApp.Controllers
{
    [EnableCors("", "*", "GET,POST,PUT")]
    public class ValuesController : ApiController
    {
         
        // GET api/values
        AppModel value = new AppModel();


        static List<AppModel> getAllApps = new List<AppModel>();

        AppBL bl = new AppBL();

        // GET api/values/5/5
        public IEnumerable<AppModel> Get()
        {
            return bl.GetAppData();
        }

        // PUT api/values/5
        public bool Put(int appId, [FromBody]AppModel value)
        {
            return bl.UpdateApp(appId, value);
        }

        // POST api/values
        public bool Post([FromBody]AppModel value)
        {
            return bl.InsertSavePage(value);
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
