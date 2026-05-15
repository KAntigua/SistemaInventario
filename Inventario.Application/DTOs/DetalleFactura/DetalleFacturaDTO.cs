namespace Inventario.Application.DTOs.DetalleFactura
{
    public class DetalleFacturaDTO
    {
        public int Id { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }

        public string ProductoNombre { get; set; }
    }
}
