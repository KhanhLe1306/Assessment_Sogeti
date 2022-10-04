using Assessment_Sogeti.Entities;
using Assessment_Sogeti.Models;

namespace Assessment_Sogeti.Interfaces
{
    public interface IOrderRepository
    {
        Task<List<Order>> GetAllOrders();
        Task<OrderRequest> GetOrderById(int id);
        Task<string> AddOrder(List<Product> products);
        Task<string> UpdateOrder(int orderId, List<Product> products);
        Task<string> CancelOrder(int orderId);
    }
}
