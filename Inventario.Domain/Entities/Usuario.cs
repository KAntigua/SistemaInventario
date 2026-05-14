using Inventario.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.Domain.Entities
{
    public class Usuario : BaseEntity
    {
        
        public string Nombre { get; set; }
   
        public string Correo { get; set; }
       
        public string ContrasenaHash { get; set; }
       

        public TipoRol Rol { get; set; }

        //Relaciones
        public ICollection <Factura>  Facturas { get; set; }
        public ICollection <Movimiento>  Movimientos { get; set; }

    }
}
