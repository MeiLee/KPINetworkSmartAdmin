#region Using

using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartAdmin.Web.Models;
using Newtonsoft.Json.Linq;
using KPINetwork.Web.Data;
using System.Collections.Generic;

#endregion

namespace SmartAdmin.Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var dashboards = new Dashboards();
            var dashboard = new Dashboard()
            {
                Name = "Financial KPIs",
                List = Dashboard.GetDummyData(2)
            };
            dashboards.List.Add(dashboard);

            dashboard = new Dashboard()
            {
                Name = "Product KPIs",
                List = Dashboard.GetDummyData(3)
            };
            dashboards.List.Add(dashboard);

            dashboard = new Dashboard()
            {
                Name = "Something 1 KPIs",
                List = Dashboard.GetDummyData(4)
            };
            dashboards.List.Add(dashboard);

            dashboard = new Dashboard()
            {
                Name = "Something 2 KPIs",
                List = Dashboard.GetDummyData(5)
            };
            dashboards.List.Add(dashboard);

            ViewBag.KPICount = dashboards.List.Count;


            ViewBag.Dashboards = dashboards.ToJson();
            Debug.WriteLine(dashboards.ToJson());

            return View();
        }

        [Route("dashboard-marketing")]
        public IActionResult DashboardMarketing() => View();

        [Route("dashboard-social")]
        public IActionResult SocialWall() => View();

        public IActionResult Inbox() => View();

        public IActionResult Chat() => View();

        public IActionResult Widgets() => View();

        public IActionResult Company() => View();

        public IActionResult Error() => View(new ErrorViewModel
        {
            RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
        });

        // GET: /forms/wizard/
        public IActionResult Wizards() => View();

    }
}
