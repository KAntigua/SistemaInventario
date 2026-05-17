using Inventario.Application.DTOs.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.Application.Services.Interfaces
{
    public interface IUsuarioService
    {
        Task<IEnumerable<UsuarioDTO>> GetAllAsync();
        Task<UsuarioDTO> GetByIdAsync(int id);
        Task<UsuarioDTO> CreateAsync(CrearUsuarioDTO dto);
        Task<UsuarioDTO> UpdateAsync(int id, ActualizarUsuarioDTO dto);
        Task DeleteAsync(int id);

        Task<UsuarioDTO> GetByCorreoAsync(string correoId);
    }
}
