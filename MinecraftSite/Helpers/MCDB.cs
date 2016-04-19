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
        /////////////////////////////////////////////////////////////DB querys for Gallery go here////////////////////////////////////////////////////////////////////
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
                            GalleryString.CommentDateQuery = Convert.ToDateTime(reader["CommentDate"]).ToString("MMMM dd, yyyy H:mm");
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
        /////////////////////////////////////////////////////////////DB querys for Comments go here////////////////////////////////////////////////////////////////////
        public bool NewComment(string page, string username, string comment)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MCDBConnection"].ToString()))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = "INSERT INTO Comments (Page, UserName, Comment) VALUES (@Page, @UserName, @Comment)";
                    command.Parameters.AddWithValue("@Page", page);
                    command.Parameters.AddWithValue("@UserName", username);
                    command.Parameters.AddWithValue("@Comment", comment);

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

        public List<CommentModel> GetComments()
        {
            var ListOfStrings = new List<CommentModel>();
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MCDBConnection"].ToString()))
            {
                connection.Open();
                string query = "SELECT * FROM Comments";
                using (var command = new SqlCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var CommentString = new CommentModel();
                            CommentString.CommentDateQuery = Convert.ToDateTime(reader["CommentDate"]).ToString("MMMM dd, yyyy H:mm");
                            CommentString.PageQuery = reader.GetString(reader.GetOrdinal("Page"));
                            CommentString.UserNameQuery = reader.GetString(reader.GetOrdinal("UserName"));
                            CommentString.CommentQuery = reader.GetString(reader.GetOrdinal("Comment"));

                            ListOfStrings.Add(CommentString);
                        }
                    }
                }
            }
            return ListOfStrings;
        }
    }    
}