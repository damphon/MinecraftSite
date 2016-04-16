using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using MinecraftSite.Models;

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
                    catch (SqlException)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public List<GalleryModel> GetGalleryImage()
        {
            var ListOfStrings = new List<GalleryModel>();
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MCDBConnection"].ToString()))
            {
                connection.Open();
                string query = "SELECT * FROM Gallery";
                using (var command = new SqlCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var GalleryString = new GalleryModel();
                            GalleryString.FileNameQuery = reader.GetString(reader.GetOrdinal("FileName"));
                            GalleryString.UserNameQuery = reader.GetString(reader.GetOrdinal("UserName"));
                            GalleryString.DescriptionQuery = reader.GetString(reader.GetOrdinal("Description"));

                            ListOfStrings.Add(GalleryString);
                        }
                    }
                }
            }
            return ListOfStrings;
        } 
    }    
}