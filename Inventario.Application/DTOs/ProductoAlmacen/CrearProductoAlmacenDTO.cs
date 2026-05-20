namespace Inventario.Application.DTOs.ProductoAlmacen
{
    public class CrearProductoAlmacenDTO
    {
        public int ProductoId { get; set; }
        public int AlmacenId { get; set; }
        public int Stock { get; set; }

        public int StockMinimo { get; set; }
    }
}
