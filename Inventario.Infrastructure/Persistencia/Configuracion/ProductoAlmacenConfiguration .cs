using Inventario.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inventario.Infrastructure.Persistencia.Configuracion
{
    public class ProductoAlmacenConfiguration : IEntityTypeConfiguration<ProductoAlmacen>
    {
        public void Configure(EntityTypeBuilder<ProductoAlmacen> builder)
        {

            builder.Property(x => x.Stock).IsRequired();
            builder.Property(x => x.StockMinimo).IsRequired();

            builder.HasOne(x => x.Producto)
              .WithMany(x => x.ProductoAlmacenes)
              .HasForeignKey(x => x.ProductoId);

            builder.HasOne(x => x.Almacen)
             .WithMany(x => x.ProductoAlmacenes)
             .HasForeignKey(x => x.AlmacenId);

        }

    }
}
