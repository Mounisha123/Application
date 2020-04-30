using ApplicationBusinessLogic;
using ApplicationModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace WebApiApplication.Controllers
{
    [EnableCors("http://localhost:4200", "*", "GET,POST,PUT")]
    public class ValuesController : ApiController
    {
        // GET api/values
        AppModel value = new AppModel();


        static List<AppModel> getAllApps = new List<AppModel>();

        AppBL bl = new AppBL();
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/values/5/5
        public IEnumerable<AppModel> Get()
        {
            return bl.GetAppData();
        }


        // POST api/values
        public bool Post([FromBody]AppModel value)
        {
            return bl.InsertSavePage(value);
        }

        // PUT api/values/5
        public bool Put(int appId, [FromBody]AppModel value)
        {
            return bl.UpdateApp(appId, value);
        }


        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
