using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SmartGoals
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");



            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Login", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

            routes.MapRoute(
                "Meta", // Route name
                "Projeto/{id2}/{controller}/{action}/{id}", // URL with parameters
                new { id2 = "", controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );
                routes.MapRoute(
               "Projeto", // Route name
               "Cliente/{id2}/{controller}/{action}/{id}", // URL with parameters
               new { id2 = "", controller = "Projeto", action = "Index", id = UrlParameter.Optional } // Parameter defaults
           );
                    routes.MapRoute(
              "Tarefa", // Route name
              "Usuario/{id2}/{id3}/{controller}/{action}/{id}", // URL with parameters
              new { id2 = "", controller = "Usuario", action = "Index", id = UrlParameter.Optional } // Parameter defaults
          );
                    routes.MapRoute(
              "TarefaGrupo", // Route name
              "Projeto/{id3}/{controller}/{action}/{id}", // URL with parameters
              new { id3 = UrlParameter.Optional, controller = "TarefaGrupo", action = "Index", id = UrlParameter.Optional } // Parameter defaults
          );


        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
        }
    }
}