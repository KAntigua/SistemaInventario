using Inventario.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.Domain.Entities
{
    public class Factura : BaseEntity
    {

        public DateTime Fecha { get; set; }
   
        public decimal Total { get; set; }

        public EstadoFactura  Estado { get; set; }
        //Relaciones

        public ICollection <DetalleFactura> DetalleFacturas { get; set; }

        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

    }
}
