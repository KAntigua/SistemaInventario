using Inventario.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Inventario.Infrastructure.Persistencia.Configuracion
{
    public class FacturaConfiguracion : IEntityTypeConfiguration<Factura>
    {
        public void Configure(EntityTypeBuilder<Factura> builder)
        { 
            builder.Property(x => x.Fecha).IsRequired();
            builder.Property(x => x.Total).IsRequired().HasPrecision(18, 2);

            builder.HasMany(x => x.DetalleFacturas)
             .WithOne(x => x.Factura)
             .HasForeignKey(x => x.FacturaId);

            builder.HasOne(x => x.Usuario)
             .WithMany(x => x.Facturas)
             .HasForeignKey(x => x.UsuarioId);
        }

    }
}
