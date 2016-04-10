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
            if ((file != null) && (file.ContentLength > 0) && (file.ContentLength <= 8000000))
                try{
                    string path = Path.Combine(HttpContext.Current.Server.MapPath("~/Content/GalleryImages"), Path.GetFileName(file.FileName));
                    string ext = Path.GetExtension(path);

                    if (FileTypeIsImage(ext))
                    {
                        //MakeThumb();
                    }else {
                        ResultText = "Please use a png, jpg, bmp, or tiff file";
                        return ResultText;
                    }
                    file.SaveAs(path);
                    ResultText = "Image has been uploaded";
                }catch (Exception ex){
                    ResultText = "Error: " + ex.Message.ToString();
                }else{
                ResultText = "Invalid Image Size";
            }

            return ResultText;
        }

        private void MakeThumb()
        {
            throw new NotImplementedException();
        }

        private bool FileTypeIsImage(string ext)
        {
            string type = ext.ToLower();
            if ((type == ".png") || (type == ".jpeg") || (type == ".jpg") || (type == ".bmp") || (type == ".gif") || (type == ".tif") || (type == ".tiff")){
                return true;
            } else {
                return false;
            }
            
        }
    }
}