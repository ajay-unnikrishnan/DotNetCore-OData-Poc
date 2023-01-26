using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.DataAccess.Interfaces
{
    public interface ISupplierStore
    {
        Task<IEnumerable<Supplier>> GetAsync();
        Task<Supplier> CreateAsync(Supplier supplier);
        IQueryable<Supplier> GetSuppliers();
    }
}
