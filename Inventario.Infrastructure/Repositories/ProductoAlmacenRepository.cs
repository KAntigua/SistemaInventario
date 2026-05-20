using Inventario.Domain.Entities;
using Inventario.Domain.Interfaces;
using Inventario.Infrastructure.Persistencia;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.Infrastructure.Repositories
{
    public class ProductoAlmacenRepository : GenericRepository<ProductoAlmacen>, IProductoAlmacenRepository
    {
        public ProductoAlmacenRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<ProductoAlmacen>> GetByAlmacenIdAsync(int almacenId)
        {
            return await _context.Set<ProductoAlmacen>()
                .Include(p => p.Producto)
                .Include(p => p.Almacen)
                .Where(p => p.AlmacenId == almacenId)
                .ToListAsync();
        }

        public async Task<ProductoAlmacen?> GetByProductoYAlmacenAsync(int productoId, int almacenId)
        {
            return await _context.Set<ProductoAlmacen>()
                .Include(p => p.Producto)
                .Include(p => p.Almacen)
                .FirstOrDefaultAsync(p => p.ProductoId == productoId && p.AlmacenId == almacenId);
        }

        public async Task<ProductoAlmacen?> GetByIdWithDetailsAsync(int id)
        {
            return await _context.Set<ProductoAlmacen>()
                .Include(p => p.Producto)
                .Include(p => p.Almacen)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<ProductoAlmacen>> GetAllWithDetailsAsync()
        {
            return await _context.Set<ProductoAlmacen>()
               .Include(p => p.Producto)
                .Include(p => p.Almacen)
                .ToListAsync();
        }
    }
}
