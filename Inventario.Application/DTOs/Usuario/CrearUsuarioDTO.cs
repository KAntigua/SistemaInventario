using Inventario.Domain.Enums;


namespace Inventario.Application.DTOs.Usuario
{
    public class CrearUsuarioDTO
    {
        public string Nombre { get; set; }

        public string Correo { get; set; }

        public string Contrasena { get; set; }

        public TipoRol Rol { get; set; }
    }
}
