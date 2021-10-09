using System.Collections.Generic;
using Dominio;

namespace Persistencia
{
    public interface IRCancha
    {
        IEnumerable<Cancha> ListarCanchas();
        List<Cancha> ListarCanchas1();
        bool CrearCancha(Cancha obj);
        bool ActualizarCancha(Cancha obj);
        bool EliminarCancha(int id);
        Cancha BuscarCancha(int id);
    }
}