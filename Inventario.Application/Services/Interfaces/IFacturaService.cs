using Inventario.Application.DTOs.Factura;
using Inventario.Domain.Enums;

namespace Inventario.Application.Services.Interfaces
{
    public interface IFacturaService
    {
        Task<IEnumerable<FacturaDTO>> GetAllAsync();
        Task<FacturaDTO> GetByIdAsync(int id);
        Task<FacturaDTO> CreateAsync(CrearFacturaDTO dto);
        Task<FacturaDTO> UpdateAsync(int id, ActualizarFacturaDTO dto);
        Task DeleteAsync(int id);

        Task<IEnumerable<FacturaDTO>> GetByUsuarioIdAsync(int id);
        Task<IEnumerable<FacturaDTO>> GetByEstadoAsync(EstadoFactura estado);
       
    }
}
