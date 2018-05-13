using Newtonsoft.Json.Linq;
using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KPINetwork.Web.Data
{
    public class DashboardItem
    {
        public Dictionary<string, object> Data = new Dictionary<string, object>();
        private static Random Rnd = new Random();

        public void GenerateRandomData(int rowIndex)
        {
            var columnModel = Dashboard.GetColumnModel();
            foreach(var column in columnModel)
            {
                string colName = column["name"].Value<string>();

                if (string.Compare(colName, "id", true) == 0)
                {
                    Data.Add(colName, Rnd.Next());
                }
                else if (string.Compare(colName, "Description", true) == 0)
                {
                    if (rowIndex == 0)
                    {
                        Data.Add(colName, "Actual");
                    }
                    else
                    {
                        Data.Add(colName, "Budget");
                    }
                }
                else
                {
                    Data.Add(colName, Rnd.NextDouble());
                }
            }
        }
        public JObject ToJson()
        {
            var returnObj = new JObject();
            foreach (var item in Data)
            {
                if (string.Compare(item.Key, "id", true) == 0)
                {
                    returnObj.Add(item.Key, (int?)item.Value);
                }
                else if (string.Compare(item.Key, "Description", true) == 0)
                {
                    returnObj.Add(item.Key, (string)item.Value);
                }
                else
                {
                    returnObj.Add(item.Key, (double ?)item.Value);
                }
            }

            return returnObj;
        }
    }
}
