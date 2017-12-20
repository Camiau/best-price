using System;
using System.Collections.Generic;
using MejorPrecio.Common;
using System.Data.SqlClient;
using System.Configuration;

namespace MejorPrecio.Persistence
{
    public class PersistenceData
    {
        private static string conectionStringLocalDB;
        public PersistenceData()
        {
            var userLocal = Environment.UserName;
            switch (userLocal)
            {
                case "gastonh_lu":
                    conectionStringLocalDB = @"Server=DESKTOP-3MV52PP\SQLEXPRESS;Database=mejorprecio6;Trusted_Connection=True";
                    break;
                case "iskandar":
                    conectionStringLocalDB = @"Data Source=172.17.0.2,1433;Initial Catalog=mejorprecio6;User ID=sa;Password=<Clave_Segura1234";
                    break;
                case "camilaf_lu":
                    conectionStringLocalDB = @"Server=DESKTOP-3MV52PP\SQLEXPRESS;Database=mejorprecio6;Trusted_Connection=True";
                    break;
                default:
                    conectionStringLocalDB = @"Server=DESKTOP-3MV52PP\SQLEXPRESS;Database=mejorprecio6;Trusted_Connection=True";
                    break;
            }
        }
        public List<Product> ReadAllProducts()
        {
            List<Product> productList = new List<Product>();
            using (SqlConnection conn = new SqlConnection(conectionStringLocalDB))
            {
                conn.Open();
                SqlDataReader myReader = null;
                SqlCommand myCommand = new SqlCommand("SELECT * FROM products", conn);
                myReader = myCommand.ExecuteReader();
                //until this, is the db conection
                while (myReader.Read())
                {
                    var prod = new Product();
                    prod.IdProduct = int.Parse(myReader["idProduct"].ToString());
                    prod.CodeBar = myReader["codeBar"].ToString();
                    prod.Description = myReader["descriptionProuct"].ToString();
                    productList.Add(prod);
                }
            }
            return productList;
        }
        public ApplicationUser UserExist(string email, long dni)
        {
            ApplicationUser userexist = null;
            //SELECT example:
            //SELECT * FROM users WHERE users.mail='asdkddskds@adskjds.com' AND users.dni=39244338
            using (SqlConnection conn = new SqlConnection(conectionStringLocalDB))
            {
                conn.Open();
                SqlDataReader myReader = null;
                SqlCommand myCommand = new SqlCommand(@"SELECT * FROM users WHERE users.mail='" + email + "' AND users.dni=" + dni, conn);
                myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    userexist = new ApplicationUser();
                    userexist.IdUser = int.Parse(myReader["iduser"].ToString());
                    userexist.Name = myReader["nameUser"].ToString();
                    userexist.Surname = myReader["lastName"].ToString();
                    userexist.Dni = int.Parse(myReader["dni"].ToString());
                    userexist.Email = myReader["mail"].ToString();
                    userexist.ImagePath = myReader["imagePath"].ToString();
                    userexist.IdRol = int.Parse(myReader["idRol"].ToString());
                }
            }
            return userexist;
        }
        public static bool RegisterUser(ApplicationUser user)
        {
            using (SqlConnection conn = new SqlConnection(conectionStringLocalDB))
            {
                conn.Open();
                //MODEL OF QUERY
                //INSERT INTO users (nameUser,lastName,dni,mail,imagePath,idRol) VALUES('fer','G',38324779,'fer@123.com','',1) 
                SqlCommand myCommand = new SqlCommand("INSERT INTO users (nameUser,lastName,dni,mail,imagePath,idRol) VALUES('" + user.Name + "','" + user.Surname + "'," + user.Dni + ",'" + user.Email + "','" + user.ImagePath + "'," + user.IdRol + ")", conn);
                myCommand.ExecuteNonQuery();
                return true;
            }
        }

        public Product GetProductByCodeBar(string codeBar)
        {
            var ret = new Product();
            using (SqlConnection conn = new SqlConnection(@"Server=DESKTOP-3MV52PP\SQLEXPRESS;Database=mejorprecio6;Trusted_Connection=True"))
            {
                conn.Open();
                SqlDataReader myReader = null;
                SqlCommand myCommand = new SqlCommand("SELECT * FROM products WHERE codeBar=" + codeBar, conn);
                myReader = myCommand.ExecuteReader();
                // using the code here...
                while (myReader.Read())
                {
                    ret.IdProduct = int.Parse(myReader["idProduct"].ToString());
                    ret.CodeBar = myReader["codeBar"].ToString();
                    ret.Description = myReader["descriptionProuct"].ToString();
                }
            }
            return ret;
        }
        public List<Price> GetBestPrice(Product prd)
        {
            List<Price> productList = new List<Price>();
            using (SqlConnection conn = new SqlConnection(conectionStringLocalDB))
            {
                conn.Open();
                SqlDataReader myReader = null;
                SqlCommand myCommand = new SqlCommand("SELECT TOP 15 * FROM prices WHERE idProduct=" + prd.IdProduct + "ORDER BY price ASC", conn);
                myReader = myCommand.ExecuteReader();
                // using the code here...
                while (myReader.Read())
                {
                    var prod = new Price();
                    prod.Lattitude = double.Parse(myReader["latitude"].ToString());
                    prod.Longittude = double.Parse(myReader["longitude"].ToString());
                    prod.Date = DateTimeOffset.Parse(myReader["dateOfUpload"].ToString());
                    prod.PriceEffective = decimal.Parse(myReader["price"].ToString());
                    prod.Id = int.Parse(myReader["idProduct"].ToString());
                    prod.IdUser = int.Parse(myReader["idUser"].ToString());
                    productList.Add(prod);
                }
            }
            return productList;
        }
        public bool RegisterPrice(Price priceEspecific)
        {
            return true;
        }
    }
}
