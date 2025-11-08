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
    public class ProductoRepositorio : IRepositorioBase<Producto, Guid>
    {
        private  VentaContext db;
        //se crea el contructor
        public ProductoRepositorio(VentaContext _db)
        {
            db = _db;
        }

        //funcionalidades del crud
        public Producto Agregar(Producto entidad)
        {
           entidad.productoId = Guid.NewGuid();
            db.Productos.Add(entidad);
            return entidad;
        }

        public void Editar(Producto entidad)
        {
            var productoSeleccionado = db.Productos.Where(p => p.productoId == entidad.productoId).FirstOrDefault();
            if (productoSeleccionado != null)
            {
                productoSeleccionado.nombre = entidad.nombre;
                productoSeleccionado.precio = entidad.precio;
                productoSeleccionado.cantidadStock = entidad.cantidadStock;
                productoSeleccionado.descripcion = entidad.descripcion;
                
                db.Entry(productoSeleccionado).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
        }

        public void Eliminar(Guid entidadId)
        {
            var productoSeleccionado = db.Productos.Where(p => p.productoId == entidadId).FirstOrDefault();
            if (productoSeleccionado != null)
            {
            db.Productos.Remove(productoSeleccionado);
            }
        }

        public void GuardarCambios()
        {
            db.SaveChanges();
        }

        public List<Producto> Listar()
        {
            return db.Productos.ToList();   
        }

        public Producto SelectId(Guid entidadId)
        {
            var productoSeleccionado = db.Productos.Where(p => p.productoId == entidadId).FirstOrDefault();
            if (productoSeleccionado == null)
            {
                throw new Exception("Producto no encontrado");
            }   
            return productoSeleccionado;
        }
    }
}
