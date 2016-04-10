using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MinecraftSite.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
                try
                {
                    string path = Path.Combine(Server.MapPath("~/Content/GalleryImages"), Path.GetFileName(file.FileName));
                    file.SaveAs(path);
                    ViewBag.Message = "Success";

                }
                catch (Exception ex)
                {
                    ViewBag.Message = "Error: " + ex.Message.ToString();
                }
            else
            {
                ViewBag.Message = "Need File";
            }
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