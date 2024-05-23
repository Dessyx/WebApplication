using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace WebApplicationLesson1.Models

{
    public class TransactionTable
    {
        public static string con_string = "Server=tcp:deslynnsqlserver.database.windows.net,1433;Initial Catalog=deslynn-SQL-Database;Persist Security Info=False;User ID=deslynn;Password=Aresto10107#;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";

        public static SqlConnection con = new SqlConnection(con_string);

        public string userID { get; set; }
        public string productID { get; set; }

        public int PlaceOrder(int userID, int productID)
        {
            try
            {
               // int? userID = _httpContextAccessor.HttpContext.Session.GetInt32("UserID");
                string sql = "INSERT INTO TransactionTable (userID, productID) VALUES (@userID, @productID)";


                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        
                        cmd.Parameters.AddWithValue("@userID", userID);
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




        public List<DataRow> GetTransactionDetails()
        {
            try
            {
                string sql = @"SELECT 
                            TransactionTable.orderID,
                            UserTable.firstname,
                            UserTable.surname,
                            UserTable.userEmail,
                            ProductTable.productName,
                            ProductTable.productPrice,
                            ProductTable.productCategory,
                            ProductTable.productAvailability
                        FROM 
                            TransactionTable
                        INNER JOIN 
                            UserTable ON TransactionTable.userID = UserTable.userID
                        INNER JOIN 
                            ProductTable ON TransactionTable.productID = ProductTable.productID";

                SqlCommand cmd = new SqlCommand(sql, con);
                DataTable dt = new DataTable();
                con.Open();
                dt.Load(cmd.ExecuteReader());
                con.Close();
                return dt.AsEnumerable().ToList();
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                // For now, rethrow the exception
                throw ex;
            }
        }

        public List<DataRow> GetPastOrders(string userID)
        {
            try
            {
                string sql = @"SELECT 
                            TransactionTable.orderID,
                            ProductTable.productName,
                            ProductTable.productPrice,
                            ProductTable.productCategory,
                            ProductTable.productAvailability
                        FROM 
                            TransactionTable
                        INNER JOIN 
                            UserTable ON TransactionTable.userID = UserTable.userID
                        INNER JOIN 
                            ProductTable ON TransactionTable.productID = ProductTable.productID
                        WHERE 
                        UserTable.userID = " + userID;

                SqlCommand cmd = new SqlCommand(sql, con);
                DataTable dt = new DataTable();
                con.Open();
                dt.Load(cmd.ExecuteReader());
                con.Close();
                return dt.AsEnumerable().ToList();
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                // For now, rethrow the exception
                throw ex;
            }
        }

    }









    /*    public int ChangeStatus()
        {




        }*/
}
