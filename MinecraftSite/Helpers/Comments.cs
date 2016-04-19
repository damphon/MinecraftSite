using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MinecraftSite.Models;
using System.Text;

namespace MinecraftSite.Helpers
{
    public class Comments
    {
        MCDB dbhelp = new MCDB();

        public void LeaveComment(string Page, string UserName, string Comment)
        {
            if (WhiteList(UserName))
            {
                dbhelp.NewComment(Page, UserName, Comment);
            }
                return;
        }

        private bool WhiteList(string UserName)
        {
            string[] whitelist = new string[] { "damphon", "clouddesu", "garangatang", "sterlingwing", "teepek", "talerdyn", "biscuitdesucre", "majesticbrother", "covolt100" };
            if (whitelist.Any(UserName.ToLower().Contains)) return true;
            else return false;
        }

        public string ArrayBuilder(string CurrentURL)
        {
            var CommentString = CommentModel.CommentHTML();
            string tempstring = "";

            foreach (var comment in CommentString)
            {
                if (comment.PageQuery == CurrentURL)
                {
                    StringBuilder sb = new StringBuilder(tempstring);
                    sb.Append("<li class='comment'><div class='commentHeader'><cite><img src = 'https://minotar.net/helm/");
                    sb.Append(comment.UserNameQuery);
                    sb.Append("/150.png' width='30' Height='30'/><span class= 'commentUser'>");
                    sb.Append(comment.UserNameQuery);
                    sb.Append("</span><span class='commentTime'>");
                    sb.Append(comment.CommentDateQuery);
                    sb.Append("</span></cite ></div ><div class='commentBody'><div class='commentMessage'><p>");
                    sb.Append(comment.CommentQuery);
                    sb.Append("</p></div></div></li>");
                    tempstring = sb.ToString();
                }
            }
            return tempstring;
        }
    }
}