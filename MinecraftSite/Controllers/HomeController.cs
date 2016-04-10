using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MinecraftSite.Helpers;

namespace MinecraftSite.Controllers
{
    public class HomeController : Controller
    {
        Gallery help = new Gallery();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase file)
        {
            ViewBag.Message = help.ImageUpload(file);
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
    }
}