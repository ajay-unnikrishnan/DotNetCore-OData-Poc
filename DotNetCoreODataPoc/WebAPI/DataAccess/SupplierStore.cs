using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.DataAccess.Interfaces;
using WebAPI.Models;

namespace WebAPI.DataAccess
{
    public class SupplierStore : ISupplierStore
    {
        private readonly AppDbContext _context;
        public SupplierStore(AppDbContext dbContext)
        {
            _context = dbContext;
        }
        public async Task<Supplier> CreateAsync(Supplier supplier)
        {
            _context.Suppliers.Add(supplier);
            await _context.SaveChangesAsync();
            return supplier;
        }

        public async Task<IEnumerable<Supplier>> GetAsync()
        {
            return await _context.Suppliers.ToListAsync();
        }
    }
}
