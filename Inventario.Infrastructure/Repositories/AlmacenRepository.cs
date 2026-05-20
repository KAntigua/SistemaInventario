using Inventario.Domain.Entities;
using Inventario.Domain.Interfaces;
using Inventario.Infrastructure.Persistencia;

namespace Inventario.Infrastructure.Repositories
{
    public class AlmacenRepository : GenericRepository<Almacen>, IAlmacenRepository
    {
        public AlmacenRepository(AppDbContext context) : base(context) { }
    }


}
