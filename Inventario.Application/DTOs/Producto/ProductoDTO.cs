using Inventario.Domain.Enums;

namespace Inventario.Application.DTOs.Producto
{
    public class ProductoDTO
    {
        public int Id { get; set; }
        public string Codigo { get; set; }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public decimal PrecioVenta { get; set; }

        public UnidadMedida Unidad { get; set; }

        public int Stock { get; set; }
        public string CategoriaNombre { get; set; }
        public string ProveedorNombre { get; set; }

    }
}
