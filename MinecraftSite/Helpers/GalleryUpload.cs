using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Security;
using System.Net.Sockets;
using System.Text;
using System.Web;

namespace MinecraftSite.Helpers
{
    public class Gallery
    {
        public string ResultText = "ResultText";

        public string ImageUpload(HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
                try
                {
                    string path = Path.Combine(HttpContext.Current.Server.MapPath("~/Content/GalleryImages"), Path.GetFileName(file.FileName));
                    file.SaveAs(path);
                    ResultText = "Image has been uploaded";

                }
                catch (Exception ex)
                {
                    ResultText = "Error: " + ex.Message.ToString();
                }
            else
            {
                ResultText = "Need File to upload";
            }

            return ResultText;
        }
    }
}