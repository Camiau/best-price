using System;
using System.Collections.Generic;
using MejorPrecio.Common;
using MejorPrecio.Persistence;

namespace MejorPrecio.Api
{
    public class PricesApi
    {
        public List<Price> FindBestPrice(Product prod)
        {
            var data = new PriceRepository();
            return data.GetBestPrice(prod);
        }
        public bool LoadNewPrice(Price newPrice)
        {
                var data = new PriceRepository();
                return data.RegisterPrice(newPrice);
        }
        public bool DeletePrice(Price priceToDelete)
        {
                var data = new PriceRepository();
                return data.DeletePrice(priceToDelete);
        }


    }
}