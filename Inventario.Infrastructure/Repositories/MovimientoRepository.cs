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
    public class MovimientoRepository : GenericRepository<Movimiento>, IMovimientoRepository
    {

        public MovimientoRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<Movimiento>> GetByProductoIdAsync(int id)
        {
            return await _context.Set<Movimiento>()
              .Where(m => m.ProductoId == id)
              .ToListAsync();

        }

        public async Task<IEnumerable<Movimiento>> GetByUsuarioIdAsync(int id)
        {
            return await _context.Set<Movimiento>()
              .Where(m => m.UsuarioId == id)
              .ToListAsync();

        }
    }
}
