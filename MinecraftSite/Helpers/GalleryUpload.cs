using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net.Security;
using System.Net.Sockets;
using System.Text;
using System.Web;
using MinecraftSite.Helpers;

namespace MinecraftSite.Helpers
{
    public class Gallery
    {
        public string ResultText = "ResultText";
        MCDB dbhelp = new MCDB();

        public string ImageUpload(HttpPostedFileBase file, string UserName, string Description)
        {
            if ((file != null) && (file.ContentLength > 0) && (file.ContentLength <= 8000000))
                try
                {
                    string path = Path.Combine(HttpContext.Current.Server.MapPath("~/Content/GalleryImages"), Path.GetFileName(file.FileName));
                    string ext = Path.GetExtension(path);

                    if (FileTypeIsImage(ext))
                    {
                        if (WhiteList(UserName)) {
                            if (dbhelp.NewGalleryImage(Path.GetFileName(file.FileName), UserName, Description))
                            {
                                if (MakeThumb(file))
                                {
                                    //have the gallery refresh
                                }
                                else //make Thumb false
                                {
                                    return ResultText;
                                }
                            }
                            else //Database Connection Failed
                            {
                                ResultText = "Failed to update database";
                                return ResultText;
                            }
                        }
                        else//Whitelist false
                        {
                            ResultText = "Permission Denied, Please contact server admin to be added to whitelist";
                            return ResultText;
                        }
                    }
                    else// FileTypeIsImage false
                    {
                        ResultText = "Please use a png, jpg, bmp, or tiff file";
                        return ResultText;
                    }
                    file.SaveAs(path);
                    ResultText = "Image has been uploaded";
                }
                catch (Exception ex){//Failed to save image
                    ResultText = "Error: " + ex.Message.ToString();
                }
            else //File not selected or an invalid size
            {
                ResultText = "Invalid Image Size";
            }

            return ResultText;
        }

        private bool WhiteList(string UserName)
        {
            string[] whitelist = new string[] { "damphon", "clouddesu", "garangatang", "sterlingwing", "teepek", "talerdyn", "biscuitdesucre", "majesticbrother", "covolt100"};
            if (whitelist.Any(UserName.ToLower().Contains)) return true;
            else return false;
        }

        private bool MakeThumb(HttpPostedFileBase file)
        {
            try
            {
                var filename = Path.GetFileName(file.FileName);
                string path = Path.Combine(HttpContext.Current.Server.MapPath("~/Content/GalleryImages/thumbs"), filename); //Get path to save image to
                Image sourceimage = Image.FromStream(file.InputStream);
                int newWidth = 122;
                int newHeight = 65;
                var bitmap = new Bitmap(newWidth, newHeight);
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    g.SmoothingMode = SmoothingMode.HighSpeed;
                    g.PixelOffsetMode = PixelOffsetMode.HighSpeed;
                    g.CompositingQuality = CompositingQuality.HighSpeed;
                    g.InterpolationMode = InterpolationMode.Bicubic;
                    g.DrawImage(sourceimage, new Rectangle(0, 0, newWidth, newHeight));
                }
                ImageCodecInfo jpgInfo = ImageCodecInfo.GetImageEncoders().Where(codecInfo => codecInfo.MimeType == "image/jpeg").First();
                using (EncoderParameters encParams = new EncoderParameters(1))
                {
                    encParams.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 80L);
                    bitmap.Save(path, jpgInfo, encParams);
                }
            }
            catch (Exception ex)
            {
                ResultText = "Failed to create thumbnail " + ex.Message.ToString();
                return false;
            }
            return true;
        }

        private bool FileTypeIsImage(string ext)
        {
            string type = ext.ToLower();
            if ((type == ".png") || (type == ".jpeg") || (type == ".jpg") || (type == ".bmp") || (type == ".gif") || (type == ".tif") || (type == ".tiff")){
                return true;
            }
            else
            {
                return false;
            }
            
        }
    }
}