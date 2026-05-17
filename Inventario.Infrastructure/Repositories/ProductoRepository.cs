using Inventario.Domain.Entities;
using Inventario.Domain.Interfaces;
using Inventario.Infrastructure.Persistencia;
using Microsoft.EntityFrameworkCore;

namespace Inventario.Infrastructure.Repositories
{
    public class ProductoRepository : GenericRepository<Producto>, IProductoRepository
    {

       public ProductoRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Producto>> GetProductosBajoStockAsync()
        {
            return await _context.Set<Producto>()
           .Where(p => p.Stock <= p.StockMinimo)
           .ToListAsync();
        }

        public async Task<IEnumerable<Producto>> GetAllWithDetailsAsync()
        {
            return await _context.Set<Producto>()
           .Include(p => p.Categoria)
           .Include(p => p.Proveedor)
           .ToListAsync();


        }

        public async Task<Producto?> GetByIdWithDetailsAsync(int id)
        {
            return await _context.Set<Producto>()
                .Include(p => p.Categoria)
                .Include(p => p.Proveedor)
                .FirstOrDefaultAsync(p => p.Id == id);
        }


    }
}
