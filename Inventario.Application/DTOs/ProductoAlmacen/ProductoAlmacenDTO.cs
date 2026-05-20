namespace Inventario.Application.DTOs.ProductoAlmacen
{
    public class ProductoAlmacenDTO
    {
        public int Id { get; set; }
        public string NombreProducto { get; set; }
        public string NombreAlmacen { get; set; }
        public int Stock { get; set; }

        public int StockMinimo { get; set; }
    }
}
