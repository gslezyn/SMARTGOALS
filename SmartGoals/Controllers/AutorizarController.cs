using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace SmartGoals
{
    public class Autorizar : ActionFilterAttribute
    {


        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {


            base.OnActionExecuted(filterContext);


            if (filterContext.HttpContext.Session[Constantes.Constantes.SESSION_ACESSO] == null)
            {
                filterContext.HttpContext.Response.Redirect("~/Login/Index");
            }

        }

    }
}