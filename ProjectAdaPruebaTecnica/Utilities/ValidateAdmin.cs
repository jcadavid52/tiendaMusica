using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectAdaPruebaTecnica.Utilities
{
    public class ValidateAdmin : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (HttpContext.Current.Session["IdRol"] == null)
            {
                filterContext.Result = new RedirectResult("~/Account/AutenticationView");
            }

            if (HttpContext.Current.Session["IdRol"].ToString() == "2")
            {
                filterContext.Result = new RedirectResult("~/Store/Index");
            }

            base.OnActionExecuting(filterContext);
        }
    }
}