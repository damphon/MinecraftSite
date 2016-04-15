using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace MinecraftSite.Helpers
{
    public class MCDB
    {
        public bool NewGalleryImage(string filename, string username, string description)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MCDBConnection"].ToString()))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = "INSERT INTO Gallery (FileName, UserName, Description) VALUES (@FileName, @UserName, @Description)";
                    command.Parameters.AddWithValue("@FileName", filename);
                    command.Parameters.AddWithValue("@UserName", username);
                    command.Parameters.AddWithValue("@Description", description);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                    catch (SqlException e)
                    {
                        return false;
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
            return true;
        }
    }    
}