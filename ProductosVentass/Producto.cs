using Microsoft.Extensions.Primitives;

namespace ProductosVentass
{
    public class Producto
    {
        public required Guid productoId { get; set; }

        public required string nombre { get; set; }

        public required  string descripcion { get; set; }

        public required  decimal precio  { get; set; }

        public required decimal cantidadStock { get; set; }

        public required List<DetalleVenta> DetalleVentas { get; set; }
    }
}
