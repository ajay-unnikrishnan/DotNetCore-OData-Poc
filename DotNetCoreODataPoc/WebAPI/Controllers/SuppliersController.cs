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
    public class SuppliersController : ControllerBase
    {
        private readonly ISupplierStore _store;
        public SuppliersController(ISupplierStore supplierStore)
        {
            _store = supplierStore;
        }
        [HttpGet]
        [EnableQuery]
        public async Task<IActionResult> GetAsync()
        {
            var store = await _store.GetAsync();
            return Ok(store);
        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync(Supplier supplier)
        {
            var result = await _store.CreateAsync(supplier);
            return Ok(result);
        }
    }
}

