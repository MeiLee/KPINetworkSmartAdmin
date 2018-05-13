using KPINetwork.Web.Data;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartAdmin.Web.Models
{
    public class Dashboards
    {
        public List<Dashboard> List = new List<Dashboard>();

        public JArray ToJson()
        {
            var returnArray = new JArray();
            foreach(var item in List)
            {
                returnArray.Add(item.ToJson());
            }

            return returnArray;
        }
    }
}
