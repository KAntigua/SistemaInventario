using Inventario.Domain.Enums;

namespace Inventario.Application.DTOs.Usuario
{
    public class UsuarioDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public string Correo { get; set; }  

        public TipoRol Rol { get; set; }
    }
}
