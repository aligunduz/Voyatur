using DataAccessLayer;
using DataAccessLayer.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Voyatur.extensions;

namespace Voyatur.ExceptionFilters
{
    public class Logs : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            var ctx = new Model1();
            ErrorLog lf = new ErrorLog();

            if (filterContext.RequestContext.HttpContext.Session["User"] != null)
            {
                lf.UserId = ((Users)filterContext.RequestContext.HttpContext.Session["User"]).Id;
            }
            lf.Error = filterContext.Exception.ToString().ControlledSubs(1000, "");
            lf.rawUrl = filterContext.RequestContext.HttpContext.Request.RawUrl;

            ctx.ErrorLogs.Add(lf);
            if (lf.UserId == 0)
                lf.UserId = 1;
            ctx.SaveChanges();

            filterContext.RequestContext.HttpContext.Response.Redirect("/User/Login");
            filterContext.RequestContext.HttpContext.Response.End();
        }
    }
}