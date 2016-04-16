using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MinecraftSite.Helpers;

namespace MinecraftSite.Models
{
    public class GalleryModel
    {
        public string FileNameQuery { get; set; }
        public string UserNameQuery { get; set; }
        public string DescriptionQuery { get; set; }

        public static List<GalleryModel> GalleryHTML()
        {
            MCDB dbhelp = new MCDB();
            return dbhelp.GetGalleryImage();
        }
    }
}