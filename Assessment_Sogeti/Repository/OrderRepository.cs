using Assessment_Sogeti.Data;
using Assessment_Sogeti.Entities;
using Assessment_Sogeti.Interfaces;
using Assessment_Sogeti.Models;
using Microsoft.EntityFrameworkCore;

namespace Assessment_Sogeti.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private DataContext _dataContext;
        public OrderRepository(DataContext dataContext)
        {
            this._dataContext = dataContext;
        }

        public async Task<List<Order>> GetAllOrders()
        {
            return await this._dataContext.Orders.ToListAsync();
        }

        public async Task<string> AddOrder(List<Product> products)
        {
            if (products.Count > 0)
            {
                DateTime today = DateTime.Now;
                var order = (await this._dataContext.Orders.AddAsync(new Order(today))).Entity;
                await this._dataContext.SaveChangesAsync();

                foreach (Product p in products)
                {
                    await this._dataContext.OrderProducts.AddAsync(new OrderProduct(order.OrderId, p.ProductId));
                    await this._dataContext.SaveChangesAsync();
                }
                return $"Order id {order.OrderId} has been added.";
            }
            else
            {
                return "Please add at least 1 product.";
            }
        }

        public async Task<string> CancelOrder(int id)
        {
            if (id != 0)
            {
                var res = await _dataContext.Orders.Where(x => x.OrderId == id).FirstOrDefaultAsync();
                if (res != null)
                {
                    // Remove in Order table 
                    _dataContext.Orders.Remove(res);

                    // Remove in OrderProducts table
                    var temp = _dataContext.OrderProducts.Where(x => x.OrderId == id).ToList();
                    _dataContext.RemoveRange(temp);

                    _dataContext.SaveChanges();

                    return $"Order {id} has been removed";
                }
                else
                {
                    return "Invalid id";
                }
            }
            else
            {
                return "Invalid id";
            }
        }

        public async Task<OrderRequest> GetOrderById(int id)
        {
            var order = await _dataContext.Orders.Where(o => o.OrderId == id).FirstOrDefaultAsync();
            if (order != null)
            {
                var products = (from op in _dataContext.OrderProducts
                                join p in _dataContext.Products on op.ProductId equals p.ProductId
                                where op.OrderId == order.OrderId
                                select p).ToList();
                return new OrderRequest
                {
                    OrderId = order.OrderId,
                    Products = products,
                };
            }
            else
            {
                return new OrderRequest();
            }
        }

        public async Task<string> UpdateOrder(int id, List<Product> products)
        {
            if (id != 0 && products != null)
            {
                var order = await _dataContext.Orders.Where(o => o.OrderId == id).FirstOrDefaultAsync();

                if (order != null)
                {
                    var temp = await _dataContext.OrderProducts.Where(x => x.OrderId == order.OrderId).ToListAsync();

                    _dataContext.OrderProducts.RemoveRange(temp);

                    foreach (Product p in products)
                    {
                        await this._dataContext.OrderProducts.AddAsync(new OrderProduct(order.OrderId, p.ProductId));
                    }

                    await _dataContext.SaveChangesAsync();

                    return $"Order id {id} has been updated!";
                }
                else
                {
                    return $"Order id {id} is invalid!";
                }
            }
            else
            {
                return $"Invalid parameters";
            }
        }
    }
}
