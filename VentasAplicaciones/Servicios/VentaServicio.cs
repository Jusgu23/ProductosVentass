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
    public class VentaServicio : IServicioVenta<Ventas, Guid>
    {

        IRepositorioVentas<Ventas, Guid> repoVenta;
        IRepositorioBase<Producto, Guid> repoProducto;
        IRepositorioDetalleVenta<DetalleVenta, Guid> repoDetalleVenta;
    
        public VentaServicio(
            IRepositorioVentas<Ventas, Guid> _repoVenta,
            IRepositorioBase<Producto, Guid> _repoProducto,
            IRepositorioDetalleVenta<DetalleVenta, Guid> _repoDetalleVenta)
        {
            repoVenta = _repoVenta;
            repoProducto = _repoProducto;
            repoDetalleVenta = _repoDetalleVenta;
        }

        public Ventas Agregar(Ventas entidad)
        {
            if (entidad == null)
                throw new ArgumentNullException("La venta no puede ser nula");

            var ventaAgregada = repoVenta.Agregar(entidad);

            entidad.DetalleVentas.ForEach(DetalleVenta => {
                var ProductoSeleccionado = repoProducto.SelectId(DetalleVenta.productoId);
                if (ProductoSeleccionado == null)
                    throw new ArgumentNullException("El producto no existe");

                var detalleVentaNuevo = new DetalleVenta
                {
                    Id = Guid.NewGuid(),
                    ventaId = ventaAgregada.ventaId,
                    productoId = DetalleVenta.productoId,
                    cantidadVendida = DetalleVenta.cantidadVendida,
                    precioUnitario = DetalleVenta.precioUnitario,
                    subtotal = DetalleVenta.precioUnitario * DetalleVenta.cantidadVendida,
                    total = DetalleVenta.precioUnitario * DetalleVenta.cantidadVendida,
                    Producto = ProductoSeleccionado,
                    Ventas = ventaAgregada
                };

                repoDetalleVenta.Agregar(detalleVentaNuevo);
                
                ProductoSeleccionado.cantidadStock -= DetalleVenta.cantidadVendida;
                repoProducto.Editar(ProductoSeleccionado);

                entidad.subtotal += detalleVentaNuevo.subtotal;
                entidad.total += detalleVentaNuevo.total;
            });

            repoVenta.GuardarCambios();
            return entidad;
        }

        public void Anular(Guid entidadId)
        {
            repoVenta.Anular(entidadId);
            repoVenta.GuardarCambios();
        }

        public List<Ventas> Listar()
        {
           return repoVenta.Listar();
        }

        public Ventas SelectId(Guid entidadId)
        {
            return repoVenta.SelectId(entidadId);
        }
    }
}
