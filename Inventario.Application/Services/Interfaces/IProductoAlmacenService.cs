using Inventario.Application.DTOs.ProductoAlmacen;

namespace Inventario.Application.Services.Interfaces
{
    public interface IProductoAlmacenService
    {
        Task<IEnumerable<ProductoAlmacenDTO>> GetAllAsync();
        Task<ProductoAlmacenDTO> GetByIdAsync(int id);
        Task<ProductoAlmacenDTO> CreateAsync(CrearProductoAlmacenDTO dto);
        Task<ProductoAlmacenDTO> UpdateAsync(int id, ActualizarProductoAlmacenDTO dto);
        Task DeleteAsync(int id);

        Task<IEnumerable<ProductoAlmacenDTO>> GetByAlmacenIdAsync(int almacenId);
        Task<ProductoAlmacenDTO?> GetByProductoYAlmacenAsync(int productoId, int almacenId);
    }
}
