using System;
using System.Diagnostics.CodeAnalysis;

namespace MS.Products.Application
{
    [ExcludeFromCodeCoverage]
    public class Product
    {
        public int id { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public string producer { get; set; }
        public string category { get; set; }
        public string description { get; set; }
        public decimal price { get; set; }
        public DateTime register_date { get; set; }
        public string model { get; set; }
        public bool is_active { get; set; }
    }
}
