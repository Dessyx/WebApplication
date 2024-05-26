using Microsoft.AspNetCore.Mvc;

using System.Data.SqlClient;


namespace WebApplicationLesson1.Models
{
    public class ProductTable
    {
        public static string con_string = "Server=tcp:deslynnsqlserver.database.windows.net,1433;Initial Catalog=deslynn-SQL-Database;Persist Security Info=False;User ID=deslynn;Password=Aresto10107#;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";

        public static SqlConnection con = new SqlConnection(con_string);

        public int productID { get; set; }
        public string productName { get; set; }

		public string productPrice { get; set; }

		public string productCategory { get; set; }

        public string productAvailability { get; set; }



        public int insert_product(ProductTable p)
        {
            

            try
            {
                string sql = "INSERT INTO ProductTable (productName, productPrice, productCategory, productAvailability) VALUES (@productName, @productPrice, @productCategory, @productAvailability)";
                SqlCommand cmd = new SqlCommand(sql, con);
				cmd.Parameters.AddWithValue("@productName", p.productName);
                cmd.Parameters.AddWithValue("@productPrice", p.productPrice);
                cmd.Parameters.AddWithValue("@productCategory", p.productCategory);
                cmd.Parameters.AddWithValue("@productAvailability", p.productAvailability);
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

    }
}
