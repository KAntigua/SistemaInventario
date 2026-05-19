using Inventario.Domain.Enums;

namespace Inventario.Application.DTOs.Movimiento
{
    public class MovimientoDTO
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }

        public TipoMovimiento Tipo { get; set; }

        public string Motivo { get; set; }

        public string? Advertencia { get; set; }

        public string UsuarioNombre { get; set; }
        public string ProductoNombre { get; set; }
    }
}
