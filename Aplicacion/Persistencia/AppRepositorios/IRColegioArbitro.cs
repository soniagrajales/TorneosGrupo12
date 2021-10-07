using System.Collections.Generic;
using Dominio;

namespace Persistencia
{
    public interface IRColegioArbitro
    {
        IEnumerable<ColegioArbitro> ListarColegioArbitros();
        bool CrearColegioArbitro(ColegioArbitro obj);
        bool ActualizarColegioArbitro(ColegioArbitro obj);
        bool EliminarColegioArbitro(int id);
        ColegioArbitro BuscarColegioArbitro(int id);
    }
}