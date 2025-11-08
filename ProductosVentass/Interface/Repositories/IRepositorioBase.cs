using ProductosVentass.Interface;

namespace ProductosVentass.Interface.Repositories
{
    public interface IRepositorioBase <TEntidad, TEntidadId>
        : IAgregar<TEntidad>,
          IEditar<TEntidad>,
          IEliminar<TEntidadId>,
          IListar<TEntidad, TEntidadId>,
          ITransaccion
    {
        
    }
}
