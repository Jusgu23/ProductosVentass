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
    public class VentaRepositorio : IRepositorioVentas<Ventas, Guid>
    {
        private  VentaContext db;
        // se arma el construtor
        public VentaRepositorio(VentaContext _db)
        {
            db = _db;
        }

        //funcionalidades de crud
        public Ventas Agregar(Ventas entidad)
        {
           entidad.ventaId = Guid.NewGuid();
            db.Ventas.Add(entidad);
            return entidad; 
        }

        public void Anular(Guid entidadId)
        {
            var ventaSeleccionada = db.Ventas.Where(v => v.ventaId == entidadId).FirstOrDefault();
            if (ventaSeleccionada == null)
            {
                throw new NullReferenceException("Venta no encontrada");
            }

            ventaSeleccionada.anulado = true;
            db.Entry(ventaSeleccionada).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public void GuardarCambios()
        {
            db.SaveChanges();
        }

        public List<Ventas> Listar()
        {
            return db.Ventas.ToList();
        }

        public Ventas SelectId(Guid entidadId)
        {
           var ventaseleccionada = db.Ventas.Where(v => v.ventaId == entidadId).FirstOrDefault();
            if (ventaseleccionada == null)
            {
                throw new NullReferenceException("Venta no encontrada");
            }
            return ventaseleccionada;
        }
    }
}
