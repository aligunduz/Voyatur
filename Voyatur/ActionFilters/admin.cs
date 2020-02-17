using DataAccessLayer.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Voyatur.ActionFilters
{
    public class admin : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            Users usr = (Users)filterContext.RequestContext.HttpContext.Session["User"];
            if (usr == null || !usr.UserType)
            {
                filterContext.RequestContext.HttpContext.Response.Redirect("https://localhost:44373/");
            }
            base.OnActionExecuted(filterContext);
        }
    }
}