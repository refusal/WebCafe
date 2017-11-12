using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Http;
using CafeAspNet.Models;

namespace CafeAspNet
{
    public class Global : HttpApplication
    {
        public void Application_Start()
        {
            SampleData.SetDefaultData();

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
