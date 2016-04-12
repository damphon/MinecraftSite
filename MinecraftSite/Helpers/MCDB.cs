using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

namespace MinecraftSite.Helpers
{
    public class MCDB
    {
        public bool NewGalleryImage(string filename, string username, string description)
        {
            //Table is dbo.Gallery
            try
            {
                ConnectionStringSettings mySetting = ConfigurationManager.ConnectionStrings["test"];
                SqlConnection myConnection = new SqlConnection(mySetting.ConnectionString);
                myConnection.Open();
                SqlCommand myCommand = new SqlCommand("INSERT INTO Gallery (FileName, UserName, Description) VALUES ('" + filename + "','" + username + "','" + description + "');");
                myConnection.Close();
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}