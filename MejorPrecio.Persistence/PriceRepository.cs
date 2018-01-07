using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MejorPrecio.Common;
using System.Data.SqlClient;
using System.Data;

public class PriceRepository
{
    private static string conectionStringLocalDB = Environment.GetEnvironmentVariable("conectionStringLocalDB");
    public List<Price> GetBestPrice(Product prod)
    {
        List<Price> priceList = new List<Price>();
        using (SqlConnection conn = new SqlConnection(conectionStringLocalDB))
        {
            conn.Open();
            using (var command = conn.CreateCommand())
            {
                command.CommandType = CommandType.Text;//Excecute scalar devele el 1er valor de la primera fila que devolveria
                command.CommandText = @"SELECT TOP 15 * FROM prices WHERE idProduct=@idProd AND active=1 ORDER BY price ASC";
                command.Parameters.AddWithValue("@idProd", prod.IdProduct);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var price = new Price();
                        price.Lattitude = double.Parse(reader["latitude"].ToString());
                        price.Longittude = double.Parse(reader["longitude"].ToString());
                        price.Date = DateTimeOffset.Parse(reader["dateOfUpload"].ToString());
                        price.PriceEffective = decimal.Parse(reader["price"].ToString());
                        price.idProduct = int.Parse(reader["idProduct"].ToString());
                        price.IdUser = int.Parse(reader["idUser"].ToString());
                        priceList.Add(price);
                    }
                }
            }
            /* SqlDataReader myReader = null;
            SqlCommand myCommand = new SqlCommand("SELECT TOP 15 * FROM prices WHERE idProduct=" + prd.IdProduct + "AND active=1 ORDER BY price ASC", conn);
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
            } */
        }
        return priceList;
    }
    public bool RegisterPrice(Price priceEspecific)
    {
        var today = DateTimeOffset.Now;
        using (SqlConnection conn = new SqlConnection(conectionStringLocalDB))
        {
            conn.Open();
            using (var command = conn.CreateCommand())
            {
                command.CommandType = CommandType.Text;//Excecute scalar devele el 1er valor de la primera fila que devolveria
                command.CommandText = @"INSERT INTO prices (price,latitude,longitude,idProduct,idUser,dateOfUpload) VALUES (@priceEsp ,@lat ,@long ,@idProd ,@idUs ,@date)";

                command.Parameters.AddWithValue("@priceEsp", priceEspecific.PriceEffective);
                command.Parameters.AddWithValue("@lat", priceEspecific.Lattitude);
                command.Parameters.AddWithValue("@long", priceEspecific.Longittude);
                command.Parameters.AddWithValue("@idProd", priceEspecific.idProduct);
                command.Parameters.AddWithValue("@idUs", priceEspecific.IdUser);
                command.Parameters.AddWithValue("@date", today);

                using (var reader = command.ExecuteReader())
                {

                }
            }
        }
        return true;
    }
    public bool DeletePrice(Price priceEspecific)
    {
        using (SqlConnection conn = new SqlConnection(conectionStringLocalDB))
        {
            conn.Open();
            using (var command = conn.CreateCommand())
            {
                command.CommandType = CommandType.Text;//Excecute scalar devele el 1er valor de la primera fila que devolveria
                command.CommandText = @"UPDATE prices SET active=0 WHERE idPrice=@idPri";

                command.Parameters.AddWithValue("@idPri", priceEspecific.Id);
                using (var reader = command.ExecuteReader())
                {
                }
            }
            /*  SqlCommand myCommand = new SqlCommand(@"UPDATE prices SET active=0 WHERE idPrice=" + priceEspecific.Id, conn);
             myCommand.ExecuteNonQuery(); */
        }
        return true;
    }

    public Price ObtainPrice(Price priceToSearch)
    {
        Price price = null;

        using (SqlConnection conn = new SqlConnection(conectionStringLocalDB))
        {
            conn.Open();
            using (var command = conn.CreateCommand())
            {
                command.CommandType = CommandType.Text;//Excecute scalar devele el 1er valor de la primera fila que devolveria
                command.CommandText = @"SELECT * FROM prices WHERE idPrice=@idPri";
                command.Parameters.AddWithValue("@idPri", priceToSearch.Id);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        price.Lattitude = double.Parse(reader["latitude"].ToString());
                        price.Longittude = double.Parse(reader["longitude"].ToString());
                        price.Date = DateTimeOffset.Parse(reader["dateOfUpload"].ToString());
                        price.PriceEffective = decimal.Parse(reader["price"].ToString());
                        price.idProduct = int.Parse(reader["idProduct"].ToString());
                        price.IdUser = int.Parse(reader["idUser"].ToString());
                    }
                }
            }

            /* SqlDataReader myReader = null;
            SqlCommand myCommand = new SqlCommand("SELECT * FROM prices WHERE idPrice=" + priceToSearch.Id + " AND active=1", conn);
            myReader = myCommand.ExecuteReader();
            // using the code here..

            while (myReader.Read())
            {
                price.Lattitude = double.Parse(myReader["latitude"].ToString());
                price.Longittude = double.Parse(myReader["longitude"].ToString());
                price.Date = DateTimeOffset.Parse(myReader["dateOfUpload"].ToString());
                price.PriceEffective = decimal.Parse(myReader["price"].ToString());
                price.Id = int.Parse(myReader["idProduct"].ToString());
                price.IdUser = int.Parse(myReader["idUser"].ToString());
            } */
        }
        return price;
    }
}