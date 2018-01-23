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
                        price.Id = (Guid)reader["idPrice"];
                        price.Latitude = double.Parse(reader["latitude"].ToString());
                        price.Longitude = double.Parse(reader["longitude"].ToString());
                        price.Date = DateTimeOffset.Parse(reader["dateOfUpload"].ToString());
                        price.PriceEffective = decimal.Parse(reader["price"].ToString());
                        price.IdProduct = (Guid)reader["idProduct"];
                        price.IdUser = (Guid)reader["idUser"];
                        priceList.Add(price);
                    }
                }
            }
        }
        return priceList;
    }
    public bool RegisterPrice(RegisterPriceModel priceEspecific)
    {
        using (SqlConnection conn = new SqlConnection(conectionStringLocalDB))
        {
            conn.Open();
            using (var command = conn.CreateCommand())
            {
                command.CommandType = CommandType.Text;//Excecute scalar devele el 1er valor de la primera fila que devolveria
                command.CommandText = @"INSERT INTO prices (price,latitude,longitude,idProduct,idUser,dateOfUpload) VALUES (@priceEsp ,@lat ,@long ,@idProd ,@idUser ,@date)";

                command.Parameters.AddWithValue("@priceEsp", priceEspecific.PriceEffective);
                command.Parameters.AddWithValue("@lat", priceEspecific.Latitude);
                command.Parameters.AddWithValue("@long", priceEspecific.Longitude);
                command.Parameters.AddWithValue("@idProd", priceEspecific.IdProduct);
                command.Parameters.AddWithValue("@idUser", priceEspecific.IdUser);
                command.Parameters.AddWithValue("@date", priceEspecific.Date);

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
        }
        return true;
    }

    public Price ObtainPrice(Price priceToSearch)
    {
        var price = new Price();

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
                    if (reader.Read())
                    {
                        price.Id = (Guid)reader["idPrice"];
                        price.Latitude = double.Parse(reader["latitude"].ToString());
                        price.Longitude = double.Parse(reader["longitude"].ToString());
                        price.Date = DateTimeOffset.Parse(reader["dateOfUpload"].ToString());
                        price.PriceEffective = decimal.Parse(reader["price"].ToString());
                        price.IdProduct = (Guid)reader["idProduct"];
                        price.IdUser = (Guid)reader["idUser"];
                    }
                    else
                    {
                        price = null;
                    }
                }
            }
        }
        return price;
    }
}