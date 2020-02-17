using DataAccessLayer.entities;
using DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Voyatur.ActionFilters;
using Voyatur.ExceptionFilters;
using Voyatur.Models;

namespace Voyatur.Controllers
{
    [Logs]
    public class UserController : Controller
    {
        UserRepository rep;
        OrganisationRepository orgrep;
        productImageRepository imagerep;
        TourRepository tourrep;
        YacthRepository yachtrep;
        YacthRentingsRepository rentrep;
        public UserController(UserRepository _rep,OrganisationRepository _orgrep,productImageRepository _imagerep, TourRepository _tourrep, YacthRepository _yachtrep, YacthRentingsRepository _rentrep)
        {
            rentrep = _rentrep;
            rep = _rep;
            orgrep = _orgrep;
            imagerep = _imagerep;
            tourrep = _tourrep;
            yachtrep = _yachtrep;
        }
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(Users model)
        {
            if (!ModelState.IsValid)
            {
                return View("Add", model);
            }
            rep.Add(model);
            Session["User"] = model;
            return RedirectToAction("Index","Home", yachtrep.List());
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Users model)
        {
            foreach(var item in rep.List())
            {
                if(model.UserName==item.UserName && model.Password == item.Password)
                {
                    Session["User"] = item;
                    if (item.UserType)
                    {
                        return RedirectToAction("Admin");
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            return View();
        }
        [admin]
        public ActionResult Admin()
        {
            List<SelectListItem> ag = new List<SelectListItem>()
            {
                new SelectListItem() {Text = "Yat",Value="0"},
            new SelectListItem() {Text = "Organizasyon",Value="1"},
            new SelectListItem() {Text = "Tur",Value="2"}
            };
            ViewBag.IlanEkle = ag;
            return View(rep.List());
        }
        public ActionResult UserUpdate(int id)
        {

            return View(rep.FindbyId(id));
        }
        [HttpPost]
        public ActionResult UserUpdate(Users model)
        {
            rep.Update(model,model.Id);
            return RedirectToAction("Admin");
        }
        public ActionResult UserDelete(int id)
        {
            rep.Delete(id);
            return RedirectToAction("Admin");
        }

        public ActionResult LogOut()
        {
            Session["User"] = null;
            return RedirectToAction("Index", "Home");
        }
        
        public ActionResult YacthIlan()
        {
            return View();
        }
        public ActionResult OrganisationIlan()
        {
            return View();
        }
        [HttpPost]
        public ActionResult OrganisationIlan(Organisations model)
        {
            orgrep.Add(model);
            return RedirectToAction("FotoEkle",new { id=model.Id,tip=1});
        }




        public ActionResult TourIlan()
        {
            return View();
        }
        [HttpPost]
        public ActionResult TourIlan(Tours model)
        {
            tourrep.Add(model);
            return RedirectToAction("FotoEkle",new { id=model.Id, tip = 2 });
        }
        public ActionResult YachtIlan()
        {
            List<SelectListItem> ag = new List<SelectListItem>()
            {
                new SelectListItem() {Text = "Gulet",Value="0"},
            new SelectListItem() {Text = "Motoryat",Value="1"},
            new SelectListItem() {Text = "Katamaran",Value="2"},
            new SelectListItem() {Text = "Yelkenli",Value="3"}
            };
            List<SelectListItem> ag1 = new List<SelectListItem>()
            {
                new SelectListItem() {Text = "1-2",Value="2"},
            new SelectListItem() {Text = "2-4",Value="4"},
            new SelectListItem() {Text = "4-8",Value="8"},
            new SelectListItem() {Text = "8-16",Value="16"},
            new SelectListItem() {Text = "16 ve üzeri",Value="20"}
            };
            ViewBag.kapasite = ag1;
            ViewBag.yattipi = ag;
            return View();
        }
        [HttpPost]
        public ActionResult YachtIlan(Ships model)
        {
            yachtrep.Add(model);
            return RedirectToAction("FotoEkle",new { id=model.Id, tip = 0 });
        }
        public ActionResult FotoEkle(int id,int tip)
        {
            ViewBag.Tip = tip;
            ViewBag.productid = id;
            return View();
        }
        [admin]
        public ActionResult YachtRentList()
        {
            return View(rentrep.List());
        }
        public ActionResult UploadProductImage(int productId, HttpPostedFileBase productImage, string isMainStr,int tip)
        {
            List<SelectListItem> ag = new List<SelectListItem>()
            {
                new SelectListItem() {Text = "Yat",Value="0"},
            new SelectListItem() {Text = "Organizasyon",Value="1"},
            new SelectListItem() {Text = "Tur",Value="2"}
            };
            ViewBag.IlanEkle = ag;
            bool isMain = isMainStr == "on";
            Images pi = new Images();
            pi.IsMain = isMain;

            pi.Tip = tip;
            pi.Product_Id = productId;
            imagerep.Add(pi);

            

            imagerep.Save();
            
            string fullPath = @"C:\Users\AG\source\repos\Voyatur\Voyatur\images\" + productId + "_" + pi.Id + ".jpg";
            productImage.SaveAs(fullPath);
            return RedirectToAction("FotoEkle", new { id = productId, tip = pi.Tip });
        }
    }
}