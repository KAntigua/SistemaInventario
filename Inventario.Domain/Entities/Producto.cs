using Inventario.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.Domain.Entities
{
    public class Producto : BaseEntity
    {
        public string Codigo { get; set; }
        
        public string Nombre { get; set;}
       
        public string Descripcion { get; set;}
        
        public decimal PrecioCompra { get; set;}
       
        public decimal PrecioVenta { get; set;}
       
        public UnidadMedida Unidad { get; set; }
      
        public int Stock { get; set; }

        public int StockMinimo { get; set; }


        //Relaciones
        public int ProveedorId { get; set; }
        public Proveedor Proveedor { get; set; }

        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }


        public ICollection<Movimiento> Movimientos { get; set; }
        public ICollection<DetalleFactura> DetalleFacturas { get; set; }

    }
}
