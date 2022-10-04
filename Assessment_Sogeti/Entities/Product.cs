using System;
using System.ComponentModel.DataAnnotations;

namespace Assessment_Sogeti.Entities
{
    public class Product
    {
        public Product()
        {
        }

        [Key]
        public int ProductId { get; set; }

        public string ProductName { get; set; }
    }
}

