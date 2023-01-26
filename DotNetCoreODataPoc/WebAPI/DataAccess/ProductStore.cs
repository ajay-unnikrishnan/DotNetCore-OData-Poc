using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.DataAccess.Interfaces;
using WebAPI.Models;

namespace WebAPI.DataAccess
{
    public class ProductStore: IProductStore
    {
        private readonly AppDbContext _context;
        public ProductStore(AppDbContext dbContext)
        {
            _context = dbContext;
        }        
        public async Task<IEnumerable<Product>> GetAsync()
        {
            return await _context.Products.ToListAsync();
        }        
        public async Task<Product> CreateAsync(Product _product)
        {
            _context.Products.Add(_product);
            await _context.SaveChangesAsync();
            return _product;
        }
        public IQueryable<Product> GetProducts()
        {
            return _context.Products;
        }
    }
}
