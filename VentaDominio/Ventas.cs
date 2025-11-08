namespace VentaDominio
{
    public class Ventas
    {
        public required Guid ventaId { get; set; }
        public required  long numeroVenta { get; set; }
        public  DateTime DateTime { get; set; }
        public required string concepto { get; set; }
        public  required decimal  subtotal { get; set; }
        public required  decimal  total { get; set; }

        public required List<DetalleVenta> DetalleVentas { get; set; }
        public Boolean anulado { get; set; } = false;
    }
}
