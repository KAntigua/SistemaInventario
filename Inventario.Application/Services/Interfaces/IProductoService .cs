using Inventario.Application.DTOs.Producto;

namespace Inventario.Application.Services.Interfaces
{
    public interface IProductoService
    {

        Task<IEnumerable<ProductoDTO>> GetAllAsync();
        Task<ProductoDTO> GetByIdAsync(int id);
        Task<ProductoDTO> CreateAsync(CrearProductoDTO dto);
        Task<ProductoDTO> UpdateAsync(int id,ActualizarProductoDTO dto);
        Task DeleteAsync(int id);

        Task<IEnumerable<ProductoDTO>> GetProductosBajoStockAsync();

    }
}
