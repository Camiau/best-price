using System;
using System.Collections.Generic;
using MejorPrecio.Common;
using System.Data.SqlClient;

namespace MejorPrecio.Persistence
{
    public class PersistenceData
    {
        public static List<ApplicationUser> usersdb = new List<ApplicationUser>();

        public List<Product> ReadAllProducts()
        {
            var prod = new Product();
            List<Product> productList = new List<Product>();
            productList.Add(prod);
            productList.Add(prod);
            productList.Add(prod);
            productList.Add(prod);
            productList.Add(prod);
            productList.Add(prod);
            productList.Add(prod);
            //var conectionString = "user:";
            using (SqlConnection conn = new SqlConnection(@"Server=DESKTOP-3MV52PP\SQLEXPRESS;Database=mejorprecio6;Trusted_Connection=True"))
            {
                conn.Open();
                SqlDataReader myReader = null;
                SqlCommand myCommand = new SqlCommand("SELECT * FROM users",conn);
                myReader = myCommand.ExecuteReader();
                // using the code here...

            }
            return productList;
        }
        public static ApplicationUser UserExist(string email, string dni)
        {
            var userexist = PersistenceData.usersdb.Find(u => u.Email == email && u.Dni == dni);
            return userexist;
        }
        public static bool RegisterUser(ApplicationUser user)
        {
            usersdb.Add(user);
            return true;
        }

        public Product GetProductByCodeBar(string codeBar)
        {
            var ret = new Product();
            return ret;
        }
        public List<Price> GetBestPrice(Product prd)
        {
            List<Price> productList = new List<Price>();
            var today = new DateTimeOffset();


            for (int i = 0; i < 10; i++)
            {
                var prod = new Price();
                prod.Lattitude = -66.6666;
                prod.Longittude = -66.6666;
                prod.Date = today.Date;
                prod.PriceEffective = i + 50;
                prod.Id = i + 10;
                prod.IdUser = i;
                productList.Add(prod);
            }
            return productList;
        }
        public bool RegisterPrice(Price priceEspecific)
        {
            return true;
        }
    }
}
