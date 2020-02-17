using DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Voyatur.ExceptionFilters;

namespace Voyatur.Controllers
{
    [Logs]
    public class HomeController : Controller
    {
        YacthRepository rep;
        TourRepository trep;
        public HomeController(YacthRepository _rep, TourRepository _trep)
        {
            trep = _trep;
            rep = _rep;
        }
        public ActionResult Index()
        {
            ViewBag.turlar = trep.List();
            return View(rep.List());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        
        public ActionResult Hata()
        {
            ViewBag.Message = "Your application description page.";


            int a = 5;
            int b = Convert.ToInt32(Request.QueryString["sayi"]);
            int c = a / b;
            ViewBag.result = a / b;

            ViewBag.result = "Beklenmeyen hata";
            return View();
        }
    }
}