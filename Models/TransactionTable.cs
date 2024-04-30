using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace WebApplicationLesson1.Models

{
    public class TransactionTable
    {
        public static string con_string = "Server=tcp:deslynnsqlserver.database.windows.net,1433;Initial Catalog=deslynn-SQL-Database;Persist Security Info=False;User ID=deslynn;Password=Aresto10107#;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";

        public static SqlConnection con = new SqlConnection(con_string);

        public string userID { get; set; }
        public string productID { get; set; }

        public int PlaceOrder( int userID, int productID)
        {
            try
            {
                    string sql = "INSERT INTO transactionTable (orderID, userID, productID) VALUES (@orderID, @UserID, @productID)";


                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        
                        cmd.Parameters.AddWithValue("@UserID", userID);
                        cmd.Parameters.AddWithValue("@productID", productID);
                        con.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();
                        con.Close();

                        return rowsAffected;
                    }
                
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                // For now, return an error view or message
                throw ex;
            }
        }

    }
}
