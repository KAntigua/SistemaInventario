using Inventario.Domain.Enums;


namespace Inventario.Application.DTOs.Producto
{
    public class CrearProductoDTO
    {

        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public decimal PrecioCompra { get; set; }

        public decimal PrecioVenta { get; set; }

        public UnidadMedida Unidad { get; set; }

        public int Stock { get; set; }

        public int StockMinimo { get; set; }

        public int ProveedorId { get; set; }
        public int CategoriaId { get; set; }

    }
}
