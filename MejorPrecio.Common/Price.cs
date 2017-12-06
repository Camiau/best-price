using System;

namespace MejorPrecio.Common
{
    public class Price
    {
        int Id;
        string CodeBar;//foreign key from a specific product
        double PriceEffective;
        DateTimeOffset Date;
        long Lattitude;
        long Longittude;
        ApplicationUser User;
    }
}
