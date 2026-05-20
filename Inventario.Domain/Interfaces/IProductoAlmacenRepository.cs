using Inventario.Domain.Entities;

namespace Inventario.Domain.Interfaces
{
    public interface IProductoAlmacenRepository : IGenericRepository<ProductoAlmacen>
    {
        Task<IEnumerable<ProductoAlmacen>> GetByAlmacenIdAsync(int AlmacenId);

        Task<ProductoAlmacen?> GetByProductoYAlmacenAsync(int productoId, int almacenId);
        Task<ProductoAlmacen?> GetByIdWithDetailsAsync(int id);

        Task<IEnumerable<ProductoAlmacen>> GetAllWithDetailsAsync();
    }
}
