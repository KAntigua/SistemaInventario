using Inventario.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.Infrastructure.Persistencia.Configuracion
{
    public class ProductoConfiguracion : IEntityTypeConfiguration<Producto>
    {
        public void Configure(EntityTypeBuilder<Producto> builder)
        { 
            //Requeridos
            builder.Property(x => x.Codigo).IsRequired();
            builder.Property(x => x.Nombre).IsRequired().HasMaxLength(40);
            builder.Property(x => x.Descripcion).IsRequired().HasMaxLength(150);
            builder.Property(x => x.PrecioCompra).IsRequired().HasPrecision(18, 2);
            builder.Property(x => x.PrecioVenta).IsRequired().HasPrecision(18, 2);
            builder.Property(x => x.Unidad).IsRequired();
            builder.Property(x => x.Stock).IsRequired();
            builder.Property(x => x.StockMinimo).IsRequired();

            //Relaciones

            builder.HasOne(x => x.Proveedor)
                .WithMany(x => x.Productos)
                .HasForeignKey(x => x.ProveedorId);

            builder.HasOne(x => x.Categoria)
               .WithMany(x => x.Productos)
               .HasForeignKey(x => x.CategoriaId);
        }
    }
}
