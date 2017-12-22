using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MejorPrecio.Common;
using System.Data.SqlClient;
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
                conectionStringLocalDB = @"Data Source=172.17.0.2,1433;Initial Catalog=mejorprecio6;User ID=sa;Password=<Clave_Segura1234>";
                break;
            case "camilaf_lu":
                conectionStringLocalDB = @"Server=DESKTOP-TBLA16F\SQLEXPRESS;Database=mejorprecio6;Trusted_Connection=True;";
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
        Product ret = null;
        using (SqlConnection conn = new SqlConnection(conectionStringLocalDB))
        {
            conn.Open();
            SqlDataReader myReader = null;
            var query="SELECT * FROM products WHERE codeBar='" + codeBar + "' AND active=1";
            SqlCommand myCommand = new SqlCommand(query, conn);
            myReader = myCommand.ExecuteReader();
            // using the code here...
            while (myReader.Read())
            {
                ret = new Product();
                ret.IdProduct = int.Parse(myReader["idProduct"].ToString());
                ret.CodeBar = myReader["codeBar"].ToString();
                ret.Description = myReader["descriptionProuct"].ToString();
            }
        }
        return ret;
    }
    public bool RegisterProduct(ProductRegister productNew)
    {
        using (SqlConnection conn = new SqlConnection(conectionStringLocalDB))
        {
            conn.Open();
            SqlCommand myCommand = new SqlCommand(@"INSERT INTO products (codeBar,descriptionProuct) VALUES ('" + productNew.CodeBar + "','" + productNew.Description + "')", conn);
            myCommand.ExecuteNonQuery();
        }
        return true;
    }
    public bool DeleteProduct(Product prdToDelete)
    {
        using (SqlConnection conn = new SqlConnection(conectionStringLocalDB))
        {
            conn.Open();
            // query exsample:
            //UPDATE products SET active=0 WHERE idProduct=6
            SqlCommand myCommand = new SqlCommand(@"UPDATE products SET active=0 WHERE idProduct="+prdToDelete.IdProduct, conn);
            myCommand.ExecuteNonQuery();
        }
        return true;
    }
}