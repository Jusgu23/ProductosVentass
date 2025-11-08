using ProductosVentass.Interface;
    
namespace ProductosVentass.Interface.Repositories
{
    public interface IRepositorioDetalleVenta<TEntidad, TMovimientoId>
        : IAgregar<TEntidad>, ITransaccion
    {

    }
}
