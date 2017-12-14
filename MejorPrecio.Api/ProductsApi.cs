﻿using System;
using System.Collections.Generic;
using MejorPrecio.Common;
using MejorPrecio.Persistence;

namespace MejorPrecio.Api
{
    public class ProductsApi
    {
        public Product SearchByCodeBar(string codeBar)
        {
            //codeBar is a valid codeBar chechekd by a previous function
            var persistence = new PersistenceData();
            return persistence.GetProductByCodeBar(codeBar);
        }
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
