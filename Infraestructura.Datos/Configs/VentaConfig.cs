using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VentaDominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructura.Datos.Configs
{
     class VentaConfig : IEntityTypeConfiguration<Ventas>
    {
        public void Configure(EntityTypeBuilder<Ventas> builder)
        {
            builder.ToTable("tblVentas");
            builder.HasKey(v => v.ventaId);


            builder
                .HasMany(Ventas => Ventas.DetalleVentas)
                .WithOne(DetalleVenta => DetalleVenta.Ventas);
        }
    }
}
