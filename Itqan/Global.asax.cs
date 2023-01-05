
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Itqan
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

        }

        protected void Application_AcquireRequestState(object sender, EventArgs e)
        {


            var userLang = Request.Cookies["userLang"];
            if (userLang != null)
            {
                if (!string.IsNullOrEmpty( userLang["lang"]))
                {
                    Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo(userLang["lang"].ToString());
                    Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(userLang["lang"].ToString());
                }
            }
            else
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("ar");
                Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("ar");
            }

          
        }




    }


}
