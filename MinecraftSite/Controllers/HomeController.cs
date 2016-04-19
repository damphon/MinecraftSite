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
            ViewBag.Gallery = GalleryModel.GalleryHTML();
            return View();
        }

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase file)
        {
            Gallery galleryHelper = new Gallery();
            string UserName = Request.Form["UserName"];
            string Description = Request.Form["Description"];
            ViewBag.Message = galleryHelper.ImageUpload(file, UserName, Description);
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

        [HttpGet]
        public PartialViewResult Comments()
        {
            var CommentString = CommentModel.CommentHTML();
            return PartialView();
        }

        [HttpPost]
        public PartialViewResult Comments(string Page, string UserName, string Comment)
        {
            Comments commentHelper = new Comments();
            commentHelper.LeaveComment(Page, UserName, Comment);
            return PartialView();
        }
    }
}