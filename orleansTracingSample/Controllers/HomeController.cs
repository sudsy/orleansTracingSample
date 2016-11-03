using Orleans.Runtime;
using Orleans.Runtime.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace orleansTracingSample.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";


            ClientConfiguration clientConfig = new ClientConfiguration
            {
                GatewayProvider = ClientConfiguration.GatewayProviderType.Config,
                ResponseTimeout = TimeSpan.FromSeconds(30),
                Gateways = new List<IPEndPoint>() { new IPEndPoint(IPAddress.Parse("127.0.0.1"), 40000)},
                DefaultTraceLevel = Severity.Info,
                TraceToConsole = false,
                TraceFileName = null
            };

            try
            {
                Orleans.GrainClient.Initialize(clientConfig);
            }catch
            {
                System.Diagnostics.Trace.TraceError("Could not connect to orleans silo");
            }
           

            return View();
        }
    }
}
