using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MejorPrecio.Common;
using System.Data.SqlClient;
using System.Data;
public class ProductRepository
{
    private static string conectionStringLocalDB = Environment.GetEnvironmentVariable("conectionStringLocalDB");
    public List<Product> ReadAllProducts()
    {
        List<Product> productList = new List<Product>();
        using (SqlConnection conn = new SqlConnection(conectionStringLocalDB))
        {
            conn.Open();
            using (var command = conn.CreateCommand())
            {
                command.CommandType = CommandType.Text;
                command.CommandText = @"SELECT * FROM products WHERE active=1";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var prod = new Product();
                        prod.IdProduct = (Guid)reader["idProduct"];
                        prod.BarCode = reader["codeBar"].ToString();
                        prod.Description = reader["descriptionProduct"].ToString();
                        productList.Add(prod);

                    }
                }
            }
        }
        return productList;
    }
    public Product GetProductByBarCode(string barCode)
    {
        Product ret = null;
        using (SqlConnection conn = new SqlConnection(conectionStringLocalDB))
        {
            conn.Open();
            using (var command = conn.CreateCommand())
            {
                command.CommandType = CommandType.Text;
                command.CommandText = @"SELECT * FROM products WHERE codeBar = @barCode AND active=1";
                command.Parameters.AddWithValue("@barCode", barCode);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ret = new Product();
                        ret.IdProduct = (Guid)reader["idProduct"];
                        ret.BarCode = reader["codeBar"].ToString();
                        ret.Description = reader["descriptionProduct"].ToString();
                    }
                }

            }
        }
        return ret;
    }
    public void RegisterProduct(Product product)
    {
        using (SqlConnection conn = new SqlConnection(conectionStringLocalDB))
        {
            conn.Open();
            using (var command = conn.CreateCommand())
            {
                command.CommandType = CommandType.Text;
                command.CommandText = @"INSERT INTO products (codeBar, descriptionProduct) VALUES (@barCode, @description)";
                command.Parameters.AddWithValue("@barCode", product.BarCode);
                command.Parameters.AddWithValue("@description", product.Description);
                command.ExecuteNonQuery();
            }
        }
    }
    public void DeleteProduct(Guid id)
    {
        using (SqlConnection conn = new SqlConnection(conectionStringLocalDB))
        {
            conn.Open();
            using (var command = conn.CreateCommand())
            {
                command.CommandType = CommandType.Text;
                command.CommandText = @"UPDATE products SET active = 0 WHERE idProduct=@idProd";
                command.Parameters.AddWithValue("@idProd", id);
                command.ExecuteNonQuery();
            }

        }
    }
}