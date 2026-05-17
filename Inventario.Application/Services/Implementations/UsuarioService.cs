using Inventario.Application.DTOs.Usuario;
using Inventario.Application.Services.Interfaces;
using Inventario.Domain.Entities;
using Inventario.Domain.Interfaces;

namespace Inventario.Application.Services.Implementations
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
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
