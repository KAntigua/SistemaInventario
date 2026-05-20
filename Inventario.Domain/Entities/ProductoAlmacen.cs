namespace Inventario.Domain.Entities
{
    public class ProductoAlmacen : BaseEntity
    {
        public int ProductoId { get; set; }
        public Producto Producto { get; set; }

        public int AlmacenId { get; set; }
        public Almacen Almacen { get; set; }

        public int Stock { get; set; }

        public int StockMinimo { get; set; }

    }
}
