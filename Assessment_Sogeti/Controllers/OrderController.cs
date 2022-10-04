using Assessment_Sogeti.Data;
using Assessment_Sogeti.Entities;
using Assessment_Sogeti.Interfaces;
using Assessment_Sogeti.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Assessment_Sogeti.Controllers
{
    [ApiController]
    [Route("[controller]/")]
    public class OrderController : Controller
    {
        private IOrderRepository _orderRepository;
        public OrderController(IOrderRepository orderRepository)
        {
            this._orderRepository = orderRepository;  
        }
        [HttpGet]
        public async Task<ActionResult<List<Order>>> GetAllOrders()
        {
            return await this._orderRepository.GetAllOrders();   
        }

        [HttpGet("{id}")]
        public async Task<OrderRequest> GetOrder(int id)
        { 
            return await this._orderRepository.GetOrderById(id);
        }

        [HttpPost]
        public async Task<string> AddOrder([FromBody] List<Product> products)
        {
            return await _orderRepository.AddOrder(products);
        }

        [HttpPut("{id}")]
        public async Task<string> UpdateOrder(int id, [FromBody] List<Product> products)
        {
            return await this._orderRepository.UpdateOrder(id, products);
        }

        [HttpDelete("{id}")]
        public async Task<string> CancelOrder(int id)
        {
            return await _orderRepository.CancelOrder(id);
        }

    }
}
