using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MinecraftSite.Helpers;

namespace MinecraftSite.Models
{
    public class CommentModel
    {
        public string CommentDateQuery { get; set; }
        public string PageQuery { get; set; }
        public string UserNameQuery { get; set; }
        public string CommentQuery { get; set; }

        public static List<GalleryModel> GalleryHTML()
        {
            MCDB dbhelp = new MCDB();
            return dbhelp.GetGalleryImage();
        }
    }
}