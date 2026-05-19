using Inventario.Domain.Enums;

namespace Inventario.Application.DTOs.Movimiento
{
    public class CrearMovimientoDTO
    {
        public DateTime Fecha { get; set; }

        public TipoMovimiento Tipo { get; set; }

        public string Motivo { get; set; }

        public int UsuarioId { get; set; }
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
    }
}
