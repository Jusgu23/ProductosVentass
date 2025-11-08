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
    class ProductoConfig : IEntityTypeConfiguration<Producto> 
    {
        public void Configure(EntityTypeBuilder<Producto> builder)
        {
            builder.ToTable("tblProductos");
            builder.HasKey(p => p.productoId);

            builder
                .HasMany(Producto => Producto.DetalleVentas)
                .WithOne(DetalleVenta => DetalleVenta.Producto);


        }
    }
}
