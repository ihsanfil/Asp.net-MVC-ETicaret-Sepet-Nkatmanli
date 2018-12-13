using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Northwind.Entities;
using Northwind.MvcWebUI.Infrastructor;
using Northwind.MvcWebUI.ModelBinders;

namespace Northwind.MvcWebUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            //bunu ekledik
            ControllerBuilder.Current.SetControllerFactory(new NinjectControllerFactory());

            //bunu ekledik //senden biri bind edildiği yerde(yani parametre olarak) cart isterse ona CartModelBinder() ' ı ver dedik
            System.Web.Mvc.ModelBinders.Binders.Add(typeof(Cart),new CartModelBinder());
        }
    }
}
