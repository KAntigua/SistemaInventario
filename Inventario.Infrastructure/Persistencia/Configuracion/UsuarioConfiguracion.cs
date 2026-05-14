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
    public class UsuarioConfiguracion : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.Property(x => x.Nombre).IsRequired().HasMaxLength(40);
            builder.Property(x => x.Correo).IsRequired().HasMaxLength(100);
            builder.Property(x => x.ContrasenaHash).IsRequired().HasMaxLength(256);
            builder.Property(x => x.Rol).IsRequired();

        }
           
       



    }
}
