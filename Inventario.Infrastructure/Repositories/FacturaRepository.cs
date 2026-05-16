using Inventario.Domain.Entities;
using Inventario.Domain.Enums;
using Inventario.Domain.Interfaces;
using Inventario.Infrastructure.Persistencia;
using Microsoft.EntityFrameworkCore;

namespace Inventario.Infrastructure.Repositories
{
    public class FacturaRepository : GenericRepository<Factura>, IFacturaRepository
    {
        public FacturaRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<Factura>> GetByUsuarioIdAsync(int id)
        {
            return await _context.Set<Factura>()
              .Where(m => m.UsuarioId == id)
              .ToListAsync();

        }

        public async Task<IEnumerable<Factura>> GetByEstadoAsync(EstadoFactura estado)
        {
            return await _context.Set<Factura>()
              .Where(m => m.Estado == estado)
              .ToListAsync();

        }
    }
}
