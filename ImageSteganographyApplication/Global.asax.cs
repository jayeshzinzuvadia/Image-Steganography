using System;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;

namespace ImageSteganographyApplication
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            Application["Api_baseAddress"] = "http://localhost:9000/";
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}