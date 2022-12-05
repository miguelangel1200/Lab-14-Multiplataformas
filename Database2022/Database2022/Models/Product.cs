using System;
using System.Collections.Generic;
using System.Text;

namespace Database2022.Models
{
    public class Product
    {
        public int ProductId { get; set;}
        public string ProductName { get; set;}
        public string ProductDetail { get; set;}
        public double ProductPrice { get; set;}
        public int ProductInStock { get; set;}
    }
}
