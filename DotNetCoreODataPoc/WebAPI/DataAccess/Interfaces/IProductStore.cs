using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.DataAccess.Interfaces
{
    public interface IProductStore
    {
        Task<IEnumerable<Product>> GetAsync();
        Task<Product> CreateAsync(Product _product);
    }
}
