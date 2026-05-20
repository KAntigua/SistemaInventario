using Inventario.Application.DTOs.Almacen;

namespace Inventario.Application.Services.Interfaces
{
    public interface IAlmacenService
    {
        Task<IEnumerable<AlmacenDTO>> GetAllAsync();
        Task<AlmacenDTO> GetByIdAsync(int id);
        Task<AlmacenDTO> CreateAsync(CrearAlmacenDTO dto);
        Task<AlmacenDTO> UpdateAsync(int id, ActualizarAlmacenDTO dto);
        Task DeleteAsync(int id);


    }
}
