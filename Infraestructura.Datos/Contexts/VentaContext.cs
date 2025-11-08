using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using VentaDominio;
using Infraestructura.Datos.Configs;
namespace Infraestructura.Datos.Contexts
{
    public class VentaContext : DbContext
    {

        public DbSet<Producto> Productos { get; set; }

        public DbSet<Ventas> Ventas { get; set; }
        public DbSet<DetalleVenta> DetalleVentas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=ssindigodev.database.windows.net;Database=prueba_indigo;User Id=dbaIndigo;Password=%FY!4%k4p;");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new ProductoConfig());
            builder.ApplyConfiguration(new VentaConfig());
            builder.ApplyConfiguration(new VentaDetalleConfig()); 
        }
    }
}
