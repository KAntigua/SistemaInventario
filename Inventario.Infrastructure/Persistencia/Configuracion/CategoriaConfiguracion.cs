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
    public class CategoriaConfiguracion : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {

            builder.Property(x => x.Nombre).IsRequired().HasMaxLength(40);
            builder.Property(x => x.Descripcion).IsRequired().HasMaxLength(100);

        }


    }
}
