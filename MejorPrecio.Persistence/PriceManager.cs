using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MejorPrecio.Common;
using System.Data.SqlClient;
public class PriceManager
{
    private static string conectionStringLocalDB = @"Server=DESKTOP-3MV52PP\SQLEXPRESS;Database=mejorprecio6;Trusted_Connection=True";
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
                prod.PriceEffective = double.Parse(myReader["price"].ToString());
                prod.Id = int.Parse(myReader["idProduct"].ToString());
                prod.IdUser = int.Parse(myReader["idUser"].ToString());
                productList.Add(prod);
            }
        }
        return productList;
    }
    public bool RegisterPrice(Price priceEspecific)
    {
        var today = new DateTimeOffset();
        using (SqlConnection conn = new SqlConnection(conectionStringLocalDB))
        {
            conn.Open();
            SqlCommand myCommand = new SqlCommand(@"INSERT INTO prices (price,latitude,longitude,idProduct,idUser,dateOfUpload) VALUES ("+priceEspecific.PriceEffective + "," + priceEspecific.Lattitude + "," + priceEspecific.Longittude + "," + priceEspecific.idProduct + "," + priceEspecific.IdUser + "," + today.Date + ")", conn);
            myCommand.ExecuteNonQuery();
        }
        return true;
    }
}