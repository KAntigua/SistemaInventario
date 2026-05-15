using Inventario.Domain.Enums;

namespace Inventario.Application.DTOs.Factura
{
    public class FacturaDTO
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }

        public decimal Total { get; set; }

        public string UsuarioNombre { get; set; }

        public EstadoFactura Estado { get; set; }
    }
}
