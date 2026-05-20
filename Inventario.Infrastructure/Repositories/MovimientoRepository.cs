using Inventario.Domain.Entities;
using Inventario.Domain.Interfaces;
using Inventario.Infrastructure.Persistencia;
using Microsoft.EntityFrameworkCore;

namespace Inventario.Infrastructure.Repositories
{
    public class MovimientoRepository : GenericRepository<Movimiento>, IMovimientoRepository
    {

        public MovimientoRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<Movimiento>> GetByProductoIdAsync(int id)
        {
            return await _context.Set<Movimiento>()
              .Include(m => m.Usuario)
              .Include(m => m.Producto)
              .Include(m => m.Almacen)
              .Where(m => m.ProductoId == id)
              .ToListAsync();

        }

        public async Task<IEnumerable<Movimiento>> GetByUsuarioIdAsync(int id)
        {
            return await _context.Set<Movimiento>()
                .Include(m => m.Usuario)
                .Include(m => m.Producto)
                .Include(m => m.Almacen)
                .Where(m => m.UsuarioId == id)
                .ToListAsync();
        }

        public async Task<IEnumerable<Movimiento>> GetAllWithDetailsAsync()
        {
            return await _context.Set<Movimiento>()
           .Include(p => p.Usuario)
           .Include(p => p.Producto)
           .Include(m => m.Almacen) 
           .ToListAsync();


        }

        public async Task<Movimiento?> GetByIdWithDetailsAsync(int id)
        {
            return await _context.Set<Movimiento>()
                .Include(p => p.Usuario)
                .Include(p => p.Producto)
                .Include(m => m.Almacen) 
                .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
