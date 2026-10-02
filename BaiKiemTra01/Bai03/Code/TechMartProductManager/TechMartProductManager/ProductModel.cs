using System;

namespace TechMartProductManager
{
    public class ProductModel
    {
        public string ProductId { get; set; }

        public string ProductName { get; set; }

        public string CategoryId { get; set; }

        public string CategoryName { get; set; }

        public decimal UnitPrice { get; set; }

        public int Quantity { get; set; }

        public string AvatarPath { get; set; }
    }
}