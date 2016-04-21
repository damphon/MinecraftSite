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
            string SortedString = "";
            List<CommentModel> TempList = new List<CommentModel>();
            List<CommentModel> SortedList = new List<CommentModel>();

            foreach (var comment in CommentString)
            {
                if (comment.PageQuery == CurrentURL)
                {
                    TempList.Add(comment);
                }
            }

            SortedList = TempList.OrderBy(o => o.CommentDateQuery).ToList();

            foreach (var comment in SortedList)
            {
                StringBuilder sb = new StringBuilder(SortedString);
                sb.Append("<li class='comment'><div class='commentHeader'><cite><img src = 'https://minotar.net/helm/");
                sb.Append(comment.UserNameQuery);
                sb.Append("/150.png' width='30' Height='30'/><span class= 'commentUser'><a href='/Home/UserHistory/");
                sb.Append(comment.UserNameQuery);
                sb.Append("'>");
                sb.Append(comment.UserNameQuery);
                sb.Append("</a></span><span class='commentTime'>");
                sb.Append(comment.CommentDateQuery);
                sb.Append("</span></cite ></div ><div class='commentBody'><div class='commentMessage'><p>");
                sb.Append(comment.CommentQuery);
                sb.Append("</p></div></div></li>");
                SortedString = sb.ToString();
            }
            return SortedString;
        }

        public string CommentHistory(string UserName)
        {
            var CommentString = CommentModel.CommentHTML();
            string SortedString = "";
            List<CommentModel> TempList = new List<CommentModel>();
            List<CommentModel> SortedList = new List<CommentModel>();

            foreach (var comment in CommentString)
            {
                if (comment.UserNameQuery == UserName)
                {
                    TempList.Add(comment);
                }
            }

            SortedList = TempList.OrderBy(o => o.CommentDateQuery).ToList();

            foreach (var comment in SortedList)
            {
                StringBuilder sb = new StringBuilder(SortedString);
                sb.Append("<li class='comment'><div class='commentHeader'><cite><img src = 'https://minotar.net/helm/");
                sb.Append(comment.UserNameQuery);
                sb.Append("/150.png' width='30' Height='30'/><span class= 'commentUser'><a href='/Home/UserHistory/");
                sb.Append(comment.UserNameQuery);
                sb.Append("'>");
                sb.Append(comment.UserNameQuery);
                sb.Append("</a></span><span class='commentTime'>");
                sb.Append(comment.CommentDateQuery);
                sb.Append("</span></cite ></div ><div class='commentBody'><div class='commentMessage'><p>");
                sb.Append(comment.CommentQuery);
                sb.Append("</p></div></div></li>");
                SortedString = sb.ToString();
            }
            return SortedString;
        }
    }
}