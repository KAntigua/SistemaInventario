using Inventario.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inventario.Infrastructure.Persistencia.Configuracion
{
    public class AlmacenConfiguration : IEntityTypeConfiguration<Almacen>
    {
        public void Configure(EntityTypeBuilder<Almacen> builder)
        {

            builder.Property(x => x.Nombre).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Empresa).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Direccion).IsRequired().HasMaxLength(100);

        }


    }
}
