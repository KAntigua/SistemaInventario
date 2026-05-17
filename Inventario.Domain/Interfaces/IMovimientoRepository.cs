using Inventario.Domain.Entities;

namespace Inventario.Domain.Interfaces
{
    public interface IMovimientoRepository : IGenericRepository<Movimiento>
    {
        Task<IEnumerable<Movimiento>> GetByProductoIdAsync(int productoId);

        Task<IEnumerable<Movimiento>> GetByUsuarioIdAsync(int usuarioId);

        Task<IEnumerable<Movimiento>> GetAllWithDetailsAsync();

        Task<Movimiento?> GetByIdWithDetailsAsync(int id);
    }
}
