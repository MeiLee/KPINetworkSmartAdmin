using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KPINetwork.Web.Data
{
    public class DashboardItem
    {
        public int Id;
        public DateTime Date;
        public string Name;
        public string Note;
        public string Amount;
        public string Tax;
        public string Total;

        public JObject ToJson()
        {
            return new JObject
            {
                ["id"] = Id,
                ["date"] = Date.ToShortDateString(),
                ["name"] = Name,
                ["note"] = Note,
                ["amount"] = Amount,
                ["tax"] = Tax,
                ["total"] = Total,
            };
        }



    }
}
