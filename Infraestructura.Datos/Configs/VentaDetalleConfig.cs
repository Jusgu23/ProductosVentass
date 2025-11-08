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
     class VentaDetalleConfig : IEntityTypeConfiguration<DetalleVenta>
    {
        public void Configure(EntityTypeBuilder<DetalleVenta> builder)
        {
            builder.ToTable("tblDetalleVenta");
            builder.HasKey(vd => new {vd.productoId, vd.ventaId });

            builder
                .HasOne(DetalleVenta => DetalleVenta.Producto)
                .WithMany(Producto => Producto.DetalleVentas);

            builder
                .HasOne(DetalleVenta => DetalleVenta.Ventas)
                .WithMany(Ventas => Ventas.DetalleVentas);
        }
    }
}
