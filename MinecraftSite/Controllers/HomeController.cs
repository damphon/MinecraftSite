using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MinecraftSite.Models;
using MinecraftSite.Helpers;

namespace MinecraftSite.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.Gallery = GalleryModel.GalleryHTML().Take(4).ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase file)
        {
            Gallery galleryHelper = new Gallery();
            string UserName = Request.Form["UserName"];
            string Description = Request.Form["Description"];
            ViewBag.Message = galleryHelper.ImageUpload(file, UserName, Description);

            if (ViewBag.Message == "Good") { return Redirect("Home"); }
            else { return View(); }
        }

        public ActionResult Gallery()
        {
            ViewBag.FullGallery = GalleryModel.GalleryHTML();
            return View();
        }

        public ActionResult Map()
        {
            return View();
        }

        public ActionResult Connect()
        {
            return View();
        }

        public ActionResult External()
        {
            return View();
        }

        public ActionResult Portals()
        {
            return View();
        }

        public ActionResult Server()
        {
            return View();
        }

        [HttpGet]
        public PartialViewResult Comments()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult Comments(string Page, string UserName, string Comment)
        {
            Comments commentHelper = new Comments();
            commentHelper.LeaveComment(Page, UserName, Comment);
            return Redirect(Page);
        }

        public ActionResult UserHistory()
        {
            ViewBag.FullGallery = GalleryModel.GalleryHTML();
            return View();
        }

        public ActionResult Image()
        {
            ViewBag.FullGallery = GalleryModel.GalleryHTML();
            return View();
        }
    }
}