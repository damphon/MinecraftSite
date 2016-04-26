using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MinecraftSite.Helpers;

namespace MinecraftSite.Models
{
    public class GalleryModel
    {
        public string CommentDateQuery { get; set; }
        public string FileNameQuery { get; set; }
        public string UserNameQuery { get; set; }
        public string DescriptionQuery { get; set; }

        public static List<GalleryModel> GalleryHTML()
        {
            MCDB dbhelp = new MCDB();
            List<GalleryModel> ShuffledList = dbhelp.GetGalleryImage();
            ShuffledList.Shuffle();
            return ShuffledList;
        }
    }

    public static class ListHelper
    {
        private static Random rng = new Random();

        public static void Shuffle<T>(this System.Collections.Generic.IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}