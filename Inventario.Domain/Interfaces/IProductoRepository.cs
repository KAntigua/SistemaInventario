using Inventario.Domain.Entities;

namespace Inventario.Domain.Interfaces
{
    public interface IProductoRepository : IGenericRepository<Producto>
    {
        Task<IEnumerable<Producto>> GetProductosBajoStockAsync();

        Task<IEnumerable<Producto>> GetAllWithDetailsAsync();
        Task<Producto?> GetByIdWithDetailsAsync(int id);
    }
}
