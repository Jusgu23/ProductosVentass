using VentaDominio.Interface;

namespace ProductosVentass.Interface.Repositories
{
    public interface IRepositorioVentas<TEntidad, TEntidadId>
        :IAgregar<TEntidad>, IListar<TEntidad, TEntidadId>, ITransaccion
    {
        void Anular(TEntidad entidadId);
    }
}
