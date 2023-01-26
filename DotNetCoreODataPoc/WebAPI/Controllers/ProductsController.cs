using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebAPI.DataAccess.Interfaces;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductStore _productStore;
        public ProductsController(IProductStore productStore)
        {
            _productStore = productStore;
        }
        [HttpGet]
        [EnableQuery]
        public async Task<IActionResult> GetAsync()
        {
            var store = await _productStore.GetAsync();
            return Ok(store);
        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync(Product product)
        {
            var result = await _productStore.CreateAsync(product);
            return Ok(result);
        }
        [HttpGet("GetProducts"), EnableQuery]        
        public IActionResult GetProductsQueryable()
        {
            var result =  _productStore.GetProducts();
            return Ok(result);
        }
    }
}
