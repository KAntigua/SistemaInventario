using Inventario.Application.DTOs.Usuario;
using Inventario.Application.Services.Interfaces;
using Inventario.Domain.Entities;
using Inventario.Domain.Interfaces;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Inventario.Domain.Enums;

namespace Inventario.Application.Services.Implementations
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UsuarioService(
        IUsuarioRepository usuarioRepository,
        IHttpContextAccessor httpContextAccessor)
        {
            _usuarioRepository = usuarioRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IEnumerable<UsuarioDTO>> GetAllAsync()
        {

            var usuarios = await _usuarioRepository.GetAllAsync();

            var usuariosDto = usuarios.Select(usuario => new UsuarioDTO
            {


                Id = usuario.Id,
                Nombre = usuario.Nombre,
               Correo = usuario.Correo,
               Rol = usuario.Rol

            });

            return usuariosDto;
        }

        public async Task<UsuarioDTO?> GetByIdAsync(int id)
        {

            var usuario = await _usuarioRepository.GetByIdAsync(id);
            if (usuario == null) return null;

            return new UsuarioDTO
            {
                Id = usuario.Id,
                Nombre = usuario.Nombre,
                Correo = usuario.Correo,
                Rol = usuario.Rol
            };

        }

        public async Task<UsuarioDTO> CreateAsync(CrearUsuarioDTO dto)
        {
            var rolUsuarioLogueado = _httpContextAccessor.HttpContext?
                .User
                .FindFirst(ClaimTypes.Role)?
                .Value;

            if (rolUsuarioLogueado == "Admin")
            {
                if (dto.Rol == TipoRol.Admin ||
                    dto.Rol == TipoRol.SuperAdmin)
                {
                    throw new Exception(
                        "Un Admin no puede crear Admins o SuperAdmins");
                }
            }

            var usuario = new Usuario
            {
                Nombre = dto.Nombre,
                Correo = dto.Correo,
                Rol = dto.Rol,
                ContrasenaHash = BCrypt.Net.BCrypt.HashPassword(dto.Contrasena),
            };

            var creado = await _usuarioRepository.CreateAsync(usuario);

            return new UsuarioDTO
            {
                Nombre = creado.Nombre,
                Correo = creado.Correo,
                Rol = creado.Rol
            };
        }

        public async Task<UsuarioDTO> UpdateAsync(int id, ActualizarUsuarioDTO dto)
        {
            var usuario = await _usuarioRepository.GetByIdAsync(id);

            if (usuario == null)
            {
                return null;
            }

            var rolUsuarioLogueado = _httpContextAccessor.HttpContext?
                .User
                .FindFirst(ClaimTypes.Role)?
                .Value;

            if (rolUsuarioLogueado == "Admin")
            {
                if (dto.Rol == TipoRol.Admin ||
                    dto.Rol == TipoRol.SuperAdmin)
                {
                    throw new Exception(
                        "Un Admin no puede asignar roles Admin o SuperAdmin");
                }
            }

            usuario.Nombre = dto.Nombre;
            usuario.Correo = dto.Correo;
            usuario.Rol = dto.Rol;

            await _usuarioRepository.UpdateAsync(usuario);

            return new UsuarioDTO
            {
                Nombre = usuario.Nombre,
                Correo = usuario.Correo,
                Rol = usuario.Rol
            };
        }

        public async Task DeleteAsync(int id)
        {
            var usuario = await _usuarioRepository.GetByIdAsync(id);
            if (usuario == null) return;

            await _usuarioRepository.DeleteAsync(id);
        }

        public async Task<UsuarioDTO?> GetByCorreoAsync(string correo)
        {
            var usuario = await _usuarioRepository.GetByCorreoAsync(correo);
            if (usuario == null) return null;

            return new UsuarioDTO
            {
                Nombre = usuario.Nombre,
                Correo = usuario.Correo,
                Rol = usuario.Rol

            };



        }



    }
}
