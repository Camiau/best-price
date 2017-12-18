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
            var data = new PersistenceData();
            //Here will be all the init for the conecction to the DB
            return data.GetBestPrice(prod);
        }
        public bool LoadNewPrice(Price newPrice)
        {
            try
            {
                var data = new PersistenceData();
                //Here will be all the init for the conecction to the DB
                return data.RegisterPrice(newPrice); ;
            }
            catch (System.Exception)
            {
                return false;
                throw;
            }

        }
    }
}