namespace VentaDominio.Interface
{
    public interface IEliminar<TEntidadId>
    {
        void Eliminar(TEntidadId id);
    }
}
