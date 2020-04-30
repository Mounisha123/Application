using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationModel
{
    public class AppModel
    {
        public string appName { get; set; }
        public string appDesp { get; set; }
        public int appId { get; set; }
        public int isDeleted { get; set; }
        public int status { get; set; }
        public int skipRows { get; set; }
        public int topRows { get; set; }
 
    }
}
