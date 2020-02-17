using DataAccessLayer.entities;
using DataAccessLayer.Repositories;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Voyatur.ExceptionFilters;

namespace Voyatur.Controllers
{
    [Logs]
    public class SalesController : Controller
    {
        YacthRentingsRepository rentrep;
        OrganisationRepository orgrep;
        TourRepository tourrep;
        YacthRepository yrep;
        public SalesController(OrganisationRepository _orgrep, TourRepository _tourrep, YacthRepository _yrep, YacthRentingsRepository _rentrep)
        {
            rentrep = _rentrep;
            yrep = _yrep;
            tourrep = _tourrep;
            orgrep = _orgrep;
        }
        // GET: Sales
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult OrganisationList()
        {
            return View(orgrep.List());
        }
        public ActionResult Sil(int id)
        {
            orgrep.Delete(id);
            return RedirectToAction("OrganisationList");
        }
        public ActionResult OrganisationDetail(int id)
        {
            Organisations org = orgrep.FindbyId(id);
            return View(org);
        }
        public ActionResult ToursList()
        {
            return View(tourrep.List());
        }
        public ActionResult TourSil(int id)
        {
            tourrep.Delete(id);
            return RedirectToAction("ToursList");
        }
        public ActionResult TourDetail(int id)
        {
            return View(tourrep.FindbyId(id));
        }
        public ActionResult YachtList(int? Tip)
        {
            int? ag2;
            if (Tip != null)
                ag2 = Tip;
            else
                ag2 = -1;
            ViewBag.Tip = ag2;
            List<SelectListItem> ag = new List<SelectListItem>()
            {
                new SelectListItem() {Text="Seçiniz",Value="-1"},
                new SelectListItem() {Text = "Gulet",Value="0"},
            new SelectListItem() {Text = "Motoryat",Value="1"},
            new SelectListItem() {Text = "Katamaran",Value="2"},
            new SelectListItem() {Text = "Yelkenli",Value="3"}
            };
            List<SelectListItem> ag1 = new List<SelectListItem>()
            {
                new SelectListItem() {Text="Seçiniz",Value="-1"},
                new SelectListItem() {Text = "1-2",Value="2"},
            new SelectListItem() {Text = "2-4",Value="4"},
            new SelectListItem() {Text = "4-8",Value="8"},
            new SelectListItem() {Text = "8-16",Value="16"},
            new SelectListItem() {Text = "16 ve üzeri",Value="20"}
            };
            ViewBag.kapasite = ag1;
            ViewBag.yattipi = ag;
            return View(yrep.List());
        }
        public PartialViewResult ListYachtPartial(int? tip,int? kapasite,int pageNumber)
        {
            
            if (tip==-1 && kapasite == -1)
            {
                ViewBag.sayfasayisi = sayfasayisi(yrep.List());
                PagedList<Ships> model1 = sayfalama(yrep.List(),pageNumber);
                return PartialView(model1);
            }else if (kapasite == -1)
            {
                ViewBag.sayfasayisi = sayfasayisi(yrep.Select(c => c.ShipType == tip.ToString()).ToList());
                PagedList<Ships> model1 = sayfalama(yrep.Select(c => c.ShipType == tip.ToString()).ToList(), pageNumber);
                return PartialView(model1);
            }else if (tip==-1)
            {
                ViewBag.sayfasayisi = sayfasayisi(yrep.Select(c => c.Kapasite == kapasite).ToList());
                PagedList<Ships> model1 = sayfalama(yrep.Select(c => c.Kapasite == kapasite).ToList(), pageNumber);
                return PartialView(model1);
            }
            else
            {
                ViewBag.sayfasayisi = sayfasayisi(yrep.Select(c => c.Kapasite == kapasite && c.ShipType == tip.ToString()).ToList());
                PagedList<Ships> model1 = sayfalama(yrep.Select(c => c.Kapasite == kapasite && c.ShipType == tip.ToString()).ToList(), pageNumber);
                return PartialView(model1);
            }
        }
        public PagedList<Ships> sayfalama(List<Ships> liste,int pageNumber)
        {
            int pageSize = 3;
            double q = liste.Count();
            double ag = q / pageSize;
            int ks = Convert.ToInt32(Math.Ceiling(ag));
            PagedList<Ships> model1 = new PagedList<Ships>(liste, pageNumber, pageSize);
            return model1;
        }
        public int sayfasayisi(List<Ships> model)
        {
            double q = model.Count();
            double ag = q / 3;
            int ks = Convert.ToInt32(Math.Ceiling(ag));
            return ks;
        }
        public ActionResult YachtEdit(int id)
        {
            return View(yrep.FindbyId(id));
        }
        [HttpPost]
        public ActionResult YachtEdit(Ships model)
        {
            yrep.Update(model, model.Id);
            return RedirectToAction("YachtList");
        }
        public ActionResult YachtSil(int id)
        {
            yrep.Delete(id);
            return RedirectToAction("YachtList");
        }
        public ActionResult YachtDetail(int id)
        {

            return View(yrep.FindbyId(id));
        }
        public ActionResult YachtRent(int id)
        {
            YachtRenting model = new YachtRenting();
            model.Ship = yrep.FindbyId(id);
            Session["shipid"] = id;
            return View(model);
        }
        [HttpPost]
        public ActionResult YachtRent(YachtRenting model)
        {
            Users uid = (Users)Session["user"];
            model.UserId = uid.Id;
            model.YachtId = (int)Session["shipid"];
            rentrep.Add(model);
            return RedirectToAction("Index","Home");
        }
        
    }
}