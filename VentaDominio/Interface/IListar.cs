namespace VentaDominio.Interface
{
    public interface IListar<TEntidad,TEntidadId>
    {
        List<TEntidad> Listar();

        TEntidad SelectId(TEntidadId entidadId);
    }
}
