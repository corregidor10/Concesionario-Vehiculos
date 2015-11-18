using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Concesionario_Vehiculos_18_11
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "DetalleMarca",
                url: "elvehiculo/{marca}",
                defaults: new
                {
                    controller="Tipo",
                    action="BuscarMarca",
                    marca=UrlParameter.Optional
                }
                );

            routes.MapRoute(
                name: "DetalleMatricula",
                url: "mivehiculo/{matricula}",
                defaults: new
                {
                    controller = "Tipo",
                    action = "BuscarMatricula",
                    matricula = UrlParameter.Optional
                }
                );


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new {controller = "Tipo", action = "Index", id = UrlParameter.Optional}
                );
        }
    }
}
