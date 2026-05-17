using Inventario.Application.DTOs.Movimiento;

namespace Inventario.Application.Services.Interfaces
{
    public interface IMovimientoService
    {
        Task<IEnumerable<MovimientoDTO>> GetAllAsync();
        Task<MovimientoDTO> GetByIdAsync(int id);
        Task<MovimientoDTO> CreateAsync(CrearMovimientoDTO dto);
        Task DeleteAsync(int id);

        Task<IEnumerable<MovimientoDTO>> GetByProductoIdAsync(int id);
        Task<IEnumerable<MovimientoDTO>> GetByUsuarioIdAsync(int id);
        

    }
}
