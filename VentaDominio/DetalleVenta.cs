namespace VentaDominio
{
    public class DetalleVenta
    {
        public  required Guid Id { get; set; }
        public required Guid ventaId { get; set; }
        public required Guid productoId { get; set; }
        public required decimal cantidadVendida { get; set; }
        public required decimal precioUnitario { get; set; }
        public required  decimal subtotal { get; set; }
        public required decimal total { get; set; }

        public required  Producto Producto { get; set; }
        public required Ventas Ventas { get; set; }
    }
}
