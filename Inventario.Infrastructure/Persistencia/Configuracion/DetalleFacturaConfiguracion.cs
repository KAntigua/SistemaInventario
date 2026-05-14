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
    public class DetalleFacturaConfiguracion : IEntityTypeConfiguration<DetalleFactura>
    {
        public void Configure(EntityTypeBuilder<DetalleFactura> builder)
        {

            builder.Property(x => x.Cantidad).IsRequired();
            builder.Property(x => x.PrecioUnitario).IsRequired().HasPrecision(18, 2);

            builder.HasOne(x => x.Factura)
             .WithMany(x => x.DetalleFacturas)
             .HasForeignKey(x => x.FacturaId);

            builder.HasOne(x => x.Producto)
            .WithMany(x => x.DetalleFacturas)
            .HasForeignKey(x => x.ProductoId);

        }
    }
} 
