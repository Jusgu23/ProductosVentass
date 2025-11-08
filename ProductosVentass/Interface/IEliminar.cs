namespace ProductosVentass.Interface
{
    public interface IEliminar<TEntidadId>
    {
        void Eliminar(TEntidadId id);
    }
}
