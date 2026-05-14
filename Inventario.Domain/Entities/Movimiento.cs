using Inventario.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.Domain.Entities
{
    public class Movimiento : BaseEntity
    {

        public DateTime Fecha { get; set; }
        
        public TipoMovimiento Tipo { get; set; }
        
        public string Motivo { get; set; }


        //Relaciones
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        public int ProductoId { get; set; }
        public Producto Producto { get; set; }

    }
}
