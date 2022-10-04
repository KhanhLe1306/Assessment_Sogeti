using System;
namespace Assessment_Sogeti.Models
{
    public class Order
    {
        public Order()
        {
        }

        public int OrderId { get; set; }

        public List<Product> products { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}

