using System;
using System.ComponentModel.DataAnnotations;

namespace Assessment_Sogeti.Entities
{
    public class Order
    {
        public Order() { }
        public Order(DateTime today)
        {
            OrderedOn = today;
        }

        [Key]
        public int OrderId { get; set; }
        public DateTime OrderedOn { get; set; }
    }
}

