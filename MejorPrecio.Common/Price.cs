using System;

namespace MejorPrecio.Common
{
    public class Price
    {
        int id;
        string codeBar;//foreign key from a specific product
        double PriceEffective;
        DateTimeOffset date;
        long lattitude;
        long longittude;
        ApplicationUser user;
    }
}
