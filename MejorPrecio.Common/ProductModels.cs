﻿using System;


namespace MejorPrecio.Common
{
    public class Product
    {
        public Guid IdProduct;
        public string BarCode;
        public string Description;
        public string imgSrc;
    }
    public class ProductRegister
    {
        public string BarCode;
        public string Description;

        public decimal Price;

        public double Latitude;

        public double Longitude;
        public Guid IdUser;

        public ProductRegister(string barCode,string description)
        {
            this.BarCode=barCode;
            this.Description=description;
        }
        public ProductRegister()
        {
           
        }
    }
}
