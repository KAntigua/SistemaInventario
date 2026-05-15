
namespace Inventario.Application.DTOs.Factura
{
    public class CrearFacturaDTO
    {
        public DateTime Fecha { get; set; }

        public int UsuarioId { get; set; }

        public List<CrearDetalleFacturaDTO> Detalles { get; set; }

    }
}
