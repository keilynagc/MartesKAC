﻿using System.Web.Mvc;
using System.Web.Routing;

namespace ProyectoWeb_Martes.Models
{
    public class FiltroSeguridad : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Session["NombreUsuario"] == null)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary
                {
                    { "controller", "Inicio" },
                    { "action", "IniciarSesion"}
                });
            }

            base.OnActionExecuting(filterContext);
        }

    }
}