using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Linq;  
using VentaDominio;
using Infraestructura.Datos.Contexts;
using ProductosVentass.Interface.Repositories;

namespace Infraestructura.Datos.Repositorios
{
    public class DetalleVentaRepositorio : IRepositorioDetalleVenta<DetalleVenta, Guid>
    {
        private VentaContext db;
        //contructor
        public DetalleVentaRepositorio(VentaContext _db)
        {
            db = _db;
        }
        //funiconalidad del crud 
        public DetalleVenta Agregar(DetalleVenta entidad)
        {
           db.DetalleVentas.Add(entidad);
            return entidad;
        }

        public void GuardarCambios()
        {
            db.SaveChanges();
        }
    }
}
