using Inventario.Domain.Entities;
using Inventario.Domain.Interfaces;
using Inventario.Infrastructure.Persistencia;
using Microsoft.EntityFrameworkCore;


namespace Inventario.Infrastructure.Repositories
{
    public class UsuarioRepository : GenericRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(AppDbContext dbContext) : base(dbContext) { 
        
        }

        public async Task<Usuario?> GetByCorreoAsync(string correoId)
        {
            return await _context.Set<Usuario>()
            .FirstOrDefaultAsync(u => u.Correo == correoId);

        }

    }
}
