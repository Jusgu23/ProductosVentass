using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VentaDominio.Interface;
using ProductosVentass.Interface.Repositories;
using VentasAplicaciones.Interface;
using VentaDominio;

namespace VentasAplicaciones.Servicios
{
    public class ProductoServicio : IServicioBase<Producto, Guid>
    {
        private readonly IRepositorioBase<Producto, Guid> repoProduccto;
        public ProductoServicio(IRepositorioBase<Producto, Guid> _repoProduccto)
        {
            repoProduccto = _repoProduccto;
        }
        public Producto Agregar(Producto entidad)
        {
           if(entidad == null)
            {
                throw new ArgumentNullException("El producto no puede ser nulo");
            }
            if(string.IsNullOrWhiteSpace(entidad.nombre))
            {
                throw new ArgumentException("El nombre del producto es obligatorio");
            }
            if(entidad.precio < 0)
            {
                throw new ArgumentException("El precio del producto no puede ser negativo");
            }
            return repoProduccto.Agregar(entidad);

            var resultado = repoProduccto.Agregar(entidad);
            repoProduccto.GuardarCambios();
            return resultado;
        }

        public void Editar(Producto entidad)
        {
            if(entidad == null)
            {
                throw new ArgumentNullException("El producto no puede ser nulo");
            }

            repoProduccto.Editar(entidad);
            repoProduccto.GuardarCambios();
        }

        public void Eliminar(Guid entidadId)
        {
           repoProduccto.Eliminar(entidadId);
            repoProduccto.GuardarCambios();
        }

        public List<Producto> Listar()
        {
            return repoProduccto.Listar();
        }

        public Producto SelectId(Guid entidadId)
        {
            return repoProduccto.SelectId(entidadId);
        }
    }
}
