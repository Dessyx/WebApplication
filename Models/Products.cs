
using System.Data.SqlClient;
using System.Runtime.Intrinsics.Arm;
using Microsoft.AspNetCore.Mvc;
using Humanizer;

namespace WebApplicationLesson1.Models
{
    public class Products
    {
        public static string con_string = "Server=tcp:deslynnsqlserver.database.windows.net,1433;Initial Catalog=deslynn-SQL-Database;Persist Security Info=False;User ID=deslynn;Password=Aresto10107#;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";
        public static SqlConnection con = new SqlConnection(con_string);
        SqlDataReader sdr;
        public List<Products> product = new List<Products>();

        public int productID { get; set; }
        public string productName { get; set; }

        public string productPrice { get; set; }

        public string productCategory { get; set; }

        public string productAvailability { get; set; }

        public void FetchData()
        {
            if (product.Count > 0) /*clears previous records so that theres no duplicates*/
            {
                product.Clear();
            }
            try
            {
                con.Open();
                string sql = "SELECT * FROM ProductTable";
                SqlCommand cmd = new SqlCommand(sql, con);
                sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    product.Add(new Products()
                    {
                        productID = Convert.ToInt32(sdr["productID"]),
                        productName = sdr["productName"].ToString(),
                        productPrice = sdr["productPrice"].ToString(),
                        productCategory = sdr["productCategory"].ToString(),
                        productAvailability = sdr["productAvailability"].ToString()
                    });
                }

                con.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error fetching products: " + ex.Message);
                throw ex;
            }

        }


        public List<string> PopulateDropDown()
        {
            List<string> productNames = new List<string>();
            try
            {
                con.Open();
                string sql = "SELECT productName FROM ProductTable ";
                SqlCommand cmd = new SqlCommand(sql, con);
                sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    productNames.Add(sdr["productName"].ToString());
                }
                con.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error fetching product names: " + ex.Message);
                throw ex;
            }
            return productNames;
        }

    }
}
