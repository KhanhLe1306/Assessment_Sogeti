using System.ComponentModel.DataAnnotations;

namespace Assessment_Sogeti.Entities
{
    public class OrderProduct
    {
        public OrderProduct() { }
        public OrderProduct(int orderId, int productId)
        {
            OrderId = orderId;
            ProductId = productId;
        }

        [Key]
        public int OrderProductId { get; set; }
        public int ProductId { get; set; }
        public int OrderId { get; set; }
    }
}
