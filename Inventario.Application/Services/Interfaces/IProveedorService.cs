using Inventario.Application.DTOs.Proveedor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.Application.Services.Interfaces
{
    public interface IProveedorService
    {
        Task<IEnumerable<ProveedorDTO>> GetAllAsync();
        Task<ProveedorDTO> GetByIdAsync(int id);
        Task<ProveedorDTO> CreateAsync(CrearProveedorDTO dto);
        Task<ProveedorDTO> UpdateAsync(int id, ActualizarProveedorDTO dto);
        Task DeleteAsync(int id);

    }
}
