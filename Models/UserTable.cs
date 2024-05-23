﻿using Azure.Identity;
using Microsoft.AspNetCore.Mvc;

using System.Data.SqlClient;


namespace WebApplicationLesson1.Models
{

  
    
    public class UserTable
    {


        public static string con_string = "Server=tcp:deslynnsqlserver.database.windows.net,1433;Initial Catalog=deslynn-SQL-Database;Persist Security Info=False;User ID=deslynn;Password=Aresto10107#;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";

        public static SqlConnection con = new SqlConnection(con_string);

		public string username { get; set; }
		public string firstname { get; set; }
        public string surname { get; set; }
        public string userEmail { get; set; }
        public string userPassword { get; set; }


        private const string adminUsernname = "admin";
        private const string adminPassword = "khumalo123";


        public int insert_User(UserTable user)
        {

            try
            {
                string sql = "INSERT INTO UserTable (username, firstname, surname, userEmail, userPassword) VALUES (@username, @firstname, @surname,  @userEmail, @userPassword)";
                SqlCommand cmd = new SqlCommand(sql, con);
				cmd.Parameters.AddWithValue("@username", user.username);
                cmd.Parameters.AddWithValue("@firstname", user.firstname);
                cmd.Parameters.AddWithValue("@surname", user.surname);
                cmd.Parameters.AddWithValue("@userEmail", user.userEmail);
                cmd.Parameters.AddWithValue("@userPassword", user.userPassword);
                con.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                con.Close();
                return rowsAffected;
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                // For now, rethrow the exception
                throw ex;
            }

        }

       /* public int GetUserID(string username, string userPassword)
        {
            try
            {
                con.Open();
                string sql = "SELECT userID FROM UserTable WHERE username = @username AND userPassword = @userPassword";
                SqlCommand cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@userPassword", userPassword);
               
                int result = cmd.ExecuteScalar();

                con.Close();

                if (result != null)
                {
                    return Convert.ToInt32(result);
                }
                else
                {
                    return -1;
                }
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                // For now, return -1 to indicate login failure
                return -1;
            }
        }*/

        public bool Login(string username, string userPassword)
        {
            try
            {
                string sql = "SELECT COUNT(*) FROM UserTable WHERE username = @username AND userPassword = @userPassword";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue ("@username", username);
                cmd.Parameters.AddWithValue("@userPassword", userPassword);
                con.Open();

                int result = (int)cmd.ExecuteScalar();

                con.Close();

                return result == 1;

            }
            catch (Exception ex)
            {
                return false;
            }
        }




        public string GetUserType(string  username, string userPassword)
        {
            if(username == adminUsernname && userPassword == adminPassword)
            {
                return "admin";
            }
            else
            {
                return "customer";
            }
        }

        public int SelectUser(string username, string userPassword)
        {
            int userID = -1; // Default value if user is not found
            using (SqlConnection con = new SqlConnection(con_string))
            {
                string sql = "SELECT userID FROM UserTable WHERE username = @username AND userPassword = @userPassword";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@userPassword", userPassword);
                try
                {
                    con.Open();
                    object result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        userID = Convert.ToInt32(result);
                    }
                }
                catch (Exception ex)
                {
                    // Log the exception or handle it appropriately
                    // For now, rethrow the exception
                    throw ex;
                }
            }
            return userID;
        }


    }
}