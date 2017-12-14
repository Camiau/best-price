using System;
using System.Collections.Generic;
using MejorPrecio.Common;
using System.Data.SqlClient;

namespace MejorPrecio.Persistence
{
    public class PersistenceData
    {
        private static string conectionStringLocalDB = @"Server=DESKTOP-3MV52PP\SQLEXPRESS;Database=mejorprecio6;Trusted_Connection=True";
        //public static List<ApplicationUser> usersdb = new List<ApplicationUser>();
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
            //var userexist = PersistenceData.usersdb.Find(u => u.Email == email && u.Dni == dni);
            ApplicationUser userexist = null;
            //select example:
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
                //SqlCommand myCommand = new SqlCommand("INSERT INTO users (nameUser,lastName,dni,mail,imagePath,idRol) "+"VALUES('fer','G',38324779,'fer@123.com','',1)" , conn);
                SqlCommand myCommand = new SqlCommand("INSERT INTO users (nameUser,lastName,dni,mail,imagePath,idRol) VALUES('"+user.Name+"','"+user.Surname+"',"+user.Dni+",'"+user.Email+"','"+user.ImagePath+"',"+user.IdRol+")", conn);
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
