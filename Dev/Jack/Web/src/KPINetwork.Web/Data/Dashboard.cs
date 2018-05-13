using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KPINetwork.Web.Data
{
    public class Dashboard
    {
        public string Name;
        public JArray List;

        public JObject ToJson()
        {
            var returnObj = new JObject();
            returnObj["Name"] = Name;
            returnObj["List"] = List;
            returnObj["ColumnNames"] = GetColumnNames();
            returnObj["ColumnModel"] = GetColumnModel();

            return returnObj;
        }

        public static JArray GetDummyData(int max)
        {
            var list = new JArray();
            var dashboardItem = new DashboardItem();
            var item = new JObject
            {
                ["id"] = "1",
                ["date"] = "2007 -10-01",
                ["name"] = "test",
                ["note"] = "note",
                ["amount"] = "200.00",
                ["tax"] = "10.00",
                ["total"] = "210.00"
            };
            list.Add(item);

            if (max == 1)
                return list;

            item = new JObject
            {
                ["id"] = "2",
                ["date"] = "2007-10-02",
                ["name"] = "test2",
                ["note"] = "note2",
                ["amount"] = "300.00",
                ["tax"] = "20.00",
                ["total"] = "320.00"
            };
            list.Add(item);
            if (max == 2)
                return list;

            item = new JObject
            {
                ["id"] = "3",
                ["date"] = "2007-09-01",
                ["name"] = "test3",
                ["note"] = "note3",
                ["amount"] = "400.00",
                ["tax"] = "30.00",
                ["total"] = "430.00"
            };
            list.Add(item);
            if (max == 3)
                return list;

            item = new JObject
            {
                ["id"] = "4",
                ["date"] = "2007-10-04",
                ["name"] = "test4",
                ["note"] = "note4",
                ["amount"] = "200.00",
                ["tax"] = "10.00",
                ["total"] = "2100.00"
            };
            list.Add(item);
            if (max == 4)
                return list;

            item = new JObject
            {
                ["id"] = "5",
                ["date"] = "2007-10-04",
                ["name"] = "test5",
                ["note"] = "note5",
                ["amount"] = "200.00",
                ["tax"] = "10.00",
                ["total"] = "2100.00"
            };
            list.Add(item);

            return list;
        }

        public static JArray GetColumnNames()
        {
            return new JArray
            {
                "Id",
                "Date",
                "Client",
                "Amount",
                "Tax",
                "Total",
                "Notes",
                "Actions",
            };
        }

        public static JArray GetColumnModel()
        {
            var columnModels = new JArray();

            var item = new JObject
            {
                ["name"] = "id",
                ["index"] = "id",
                ["sortable"] = true,
                ["editable"] = false,
                ["hidden"] = true,
            };
            columnModels.Add(item);

            item = new JObject
            {
                ["name"] = "date",
                ["index"] = "date",
                ["sortable"] = true,
                ["editable"] = true
            };
            columnModels.Add(item);

            item = new JObject
            {
                ["name"] = "name",
                ["index"] = "name",
                ["sortable"] = true,
                ["editable"] = true
            };
            columnModels.Add(item);

            item = new JObject
            {
                ["name"] = "amount",
                ["index"] = "amount",
                ["sortable"] = true,
                ["editable"] = true
            };
            columnModels.Add(item);

            item = new JObject
            {
                ["name"] = "tax",
                ["index"] = "tax",
                ["sortable"] = true,
                ["editable"] = true
            };
            columnModels.Add(item);
            item = new JObject
            {
                ["name"] = "total",
                ["index"] = "total",
                ["sortable"] = true,
                ["editable"] = true
            };
            columnModels.Add(item);

            item = new JObject
            {
                ["name"] = "note",
                ["index"] = "note",
                ["sortable"] = true,
                ["editable"] = true
            };
            columnModels.Add(item);

            item = new JObject
            {
                ["name"] = "act",
                ["index"] = "act",
                ["sortable"] = false
            };
            columnModels.Add(item);

            return columnModels;
        }
    }
}
