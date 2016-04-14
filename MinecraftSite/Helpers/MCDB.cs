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
                string connStr = ConfigurationManager.ConnectionStrings["MCDBConnection"].ConnectionString;
                SqlConnection myConnection = new SqlConnection(connStr);
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

        public string test()
        {
            try
            {
                string connStr = ConfigurationManager.ConnectionStrings["MCDBConnection"].ConnectionString;
                SqlConnection myConnection = new SqlConnection(connStr);
                myConnection.Open();
                myConnection.Close();
            }
            catch (Exception e)
            {
                return e.ToString();
            }
            return "Connected to DB";
        }
    }
}