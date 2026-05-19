using Inventario.Domain.Entities;
using Inventario.Domain.Interfaces;
using Inventario.Infrastructure.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.Infrastructure.Repositories
{
    public class DetalleFacturaRepository : GenericRepository<DetalleFactura>, IDetalleFacturaRepository
    {
        public DetalleFacturaRepository(AppDbContext context) : base(context)
        {
        }

    }
}
