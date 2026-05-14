using Inventario.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.Infrastructure.Persistencia.Configuracion
{
    public class ProveedorConfiguracion : IEntityTypeConfiguration<Proveedor>
    {
        public void Configure(EntityTypeBuilder<Proveedor> builder) 
        {
            builder.Property(x => x.RNC).IsRequired().HasMaxLength(15);
            builder.Property(x => x.Telefono).IsRequired().HasMaxLength(15);
            builder.Property(x => x.Direccion).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Correo).IsRequired().HasMaxLength(100);

        }
    }
}
