using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.Domain.Entities
{
    public class Proveedor : BaseEntity
    {
        
        public string RNC { get; set; }
     
        public string Telefono { get; set; }
       
        public string Direccion { get; set; }
     
        public string Correo { get; set; }

       //Relaciones

        public ICollection <Producto> Productos { get; set; }
    }
}
