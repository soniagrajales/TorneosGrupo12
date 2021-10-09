using System.Collections.Generic;
using Dominio;

namespace Persistencia
{
    public interface IRArbitro
    {
        IEnumerable<Arbitro> ListarArbitros();
        List<Arbitro> ListarArbitros1();
        bool CrearArbitro(Arbitro obj);
        bool ActualizarArbitro(Arbitro obj);
        bool EliminarArbitro(int id);
        Arbitro BuscarArbitro(int id);
    }
}