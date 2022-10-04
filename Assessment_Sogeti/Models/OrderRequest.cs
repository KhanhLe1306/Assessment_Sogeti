using Assessment_Sogeti.Entities;
using System;

namespace Assessment_Sogeti.Models
{
    public class OrderRequest
    {
        public OrderRequest() { }
        public int OrderId { get; set; }
        public List<Product> Products { get; set; }

    }
}
