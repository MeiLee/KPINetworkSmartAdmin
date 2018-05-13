using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace KPINetwork.Web.Data
{
    public class Dashboard
    {
        public string Name;
        public JArray List;
        private static JArray ColumnNames;
        private static JArray ColumnModel;

        public JObject ToJson()
        {
            var returnObj = new JObject();
            returnObj["Name"] = Name;
            returnObj["List"] = List;
            returnObj["ColumnNames"] = GetColumnNames();
            returnObj["ColumnModel"] = GetColumnModel();

            return returnObj;
        }

        public JArray GetDummyData(int max)
        {
            if (List == null)
            {
                if (ColumnNames == null)
                {
                    GetColumnNames();
                }

                if (ColumnModel == null)
                {
                    GetColumnModel();
                }

                List = new JArray();
                for (int i = 0; i < max; i++)
                {
                    var item = new DashboardItem();
                    item.GenerateRandomData(i);
                    List.Add(item.ToJson());
                }
            }

            return List;
        }

        public static JArray GetColumnNames()
        {
            if (ColumnNames == null)
            { 
                ColumnNames = new JArray();
                ColumnNames.Add("Id");
                ColumnNames.Add("Description");
                for (var month = 1; month <= 12; month++)
                {
                    var tempDate = new DateTime(2018, month, 1);
                    ColumnNames.Add(tempDate.ToString("MMMM", CultureInfo.InvariantCulture));
                }

                ColumnNames.Add("Actions");
            }

            return ColumnNames;
        }

        public static JArray GetColumnModel()
        {
            if (ColumnModel == null)
            {
                ColumnModel = new JArray();
                var item = new JObject
                {
                    ["name"] = "id",
                    ["index"] = "id",
                    ["sortable"] = true,
                    ["editable"] = false,
                    ["hidden"] = true,
                };
                ColumnModel.Add(item);

                item = new JObject
                {
                    ["name"] = "description",
                    ["index"] = "description",
                    ["sortable"] = true,
                    ["editable"] = false,
                    ["hidden"] = false,
                };
                ColumnModel.Add(item);

                for (var month = 1; month <= 12; month++)
                {
                    var tempDate = new DateTime(2018, month, 1);
                    item = new JObject
                    {
                        ["name"] = tempDate.ToString("MMMM", CultureInfo.InvariantCulture),
                        ["index"] = tempDate.ToString("MMMM", CultureInfo.InvariantCulture),
                        ["sortable"] = true,
                        ["editable"] = true
                    };
                    ColumnModel.Add(item);
                }

                item = new JObject
                {
                    ["name"] = "act",
                    ["index"] = "act",
                    ["sortable"] = false
                };
                ColumnModel.Add(item);
            }

            return ColumnModel;
        }
    }
}
