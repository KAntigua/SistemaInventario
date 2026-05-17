using Inventario.Domain.Entities;
using Inventario.Domain.Enums;

namespace Inventario.Domain.Interfaces
{
    public interface IFacturaRepository : IGenericRepository<Factura>
    {
        Task<IEnumerable<Factura>> GetByUsuarioIdAsync(int usuarioId);
        Task<IEnumerable<Factura>> GetByEstadoAsync(EstadoFactura estado);

        Task<Factura?> GetByIdWithDetailsAsync(int id);

        Task<IEnumerable<Factura>> GetAllWithDetailsAsync();
    }
}
