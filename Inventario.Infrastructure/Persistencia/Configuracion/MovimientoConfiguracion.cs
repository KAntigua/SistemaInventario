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
    public class MovimientoConfiguracion : IEntityTypeConfiguration<Movimiento>
    {
        public void Configure(EntityTypeBuilder<Movimiento> builder)
        {
            builder.Property(x => x.Fecha).IsRequired();
            builder.Property(x => x.Tipo).IsRequired();
            builder.Property(x => x.Motivo).IsRequired().HasMaxLength(500);

            builder.HasOne(x => x.Usuario)
              .WithMany(x => x.Movimientos)
              .HasForeignKey(x => x.UsuarioId);

            builder.HasOne(x => x.Producto)
              .WithMany(x => x.Movimientos)
              .HasForeignKey(x => x.ProductoId);

        }

    }
}
