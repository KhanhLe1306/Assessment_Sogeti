using Assessment_Sogeti.Data;
using Assessment_Sogeti.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Assessment_Sogeti.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : Controller
    {
        private DataContext _dataContext;
        public ProductController(DataContext dataContext)
        {
            this._dataContext = dataContext;
        }
        [HttpGet]
        public async Task<ActionResult<List<Product>>> Get()
        {
            return await this._dataContext.Products.ToListAsync();
        }
        [HttpPost]
        public async Task<ActionResult<string>> AddProducts ([FromBody] List<Product> products)
        {
            try
            {
                await _dataContext.Products.AddRangeAsync(products);
                await _dataContext.SaveChangesAsync();
                return $"Products have been added";
            }catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return $"Error in adding products";
            }
          
        } 
    }
}
