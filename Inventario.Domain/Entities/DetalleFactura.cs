using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.Domain.Entities
{
    public class DetalleFactura : BaseEntity
    {
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }

        //Relaciones
        public int FacturaId { get; set; }
        public Factura Factura { get; set; }

        public int ProductoId { get; set; }
        public Producto Producto { get; set; }


    }
}
