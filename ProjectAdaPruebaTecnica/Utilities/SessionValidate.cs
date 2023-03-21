using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectAdaPruebaTecnica.Utilities
{
    public class SessionValidate: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (HttpContext.Current.Session["IdUsuario"] == null || HttpContext.Current.Session["IdRol"] == null || HttpContext.Current.Session["Nombre"] == null)
            {
                filterContext.Result = new RedirectResult("~/Account/AutenticationView");
            }
            base.OnActionExecuting(filterContext);
        }
    }
}