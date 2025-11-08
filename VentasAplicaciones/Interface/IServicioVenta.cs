using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VentaDominio.Interface;

namespace VentasAplicaciones.Interface
{
  public interface IServicioVenta<TEntidad, TEntidadId>
        : IAgregar <TEntidad>, IListar <TEntidad, TEntidadId>
    {
        void Anular(TEntidadId entidadId);
    }
}
