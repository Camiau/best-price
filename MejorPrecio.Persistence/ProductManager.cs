using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MejorPrecio.Common;
using System.Data.SqlClient;
using System.Configuration;
public class ProductManager
{
    private static string conectionStringLocalDB;
    public ProductManager()
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
            SqlCommand myCommand = new SqlCommand("SELECT * FROM products WHERE active=1", conn);
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
    public Product GetProductByCodeBar(string codeBar)
    {
        var ret = new Product();
        using (SqlConnection conn = new SqlConnection(conectionStringLocalDB))
        {
            conn.Open();
            SqlDataReader myReader = null;
            SqlCommand myCommand = new SqlCommand("SELECT * FROM products WHERE codeBar=" + codeBar + "AND actve=1", conn);
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
}