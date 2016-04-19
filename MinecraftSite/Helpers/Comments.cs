using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
    }
}