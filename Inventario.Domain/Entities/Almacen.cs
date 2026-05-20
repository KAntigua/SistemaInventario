namespace Inventario.Domain.Entities
{
    public class Almacen : BaseEntity
    {
        public string Nombre { get; set; }
        public string Empresa { get; set; }
        public string Direccion { get; set; }

        public ICollection<ProductoAlmacen> ProductoAlmacenes { get; set; }
        public ICollection<Movimiento> Movimientos { get; set; }
    }
}
