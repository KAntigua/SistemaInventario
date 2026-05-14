using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.Domain.Entities
{
    public class Categoria : BaseEntity
    {

        public string Nombre { get; set; }
       
        public string Descripcion { get; set; }

        public ICollection <Producto> Productos { get; set; }

    }
}
