using System.Collections.Generic;
using Dominio;

namespace Persistencia
{
    public interface IREntrenador
    {
        IEnumerable<Entrenador> ListarEntrenadores();
        bool CrearEntrenador(Entrenador obj);
        bool ActualizarEntrenador(Entrenador obj);
        bool EliminarEntrenador(int id);
        Entrenador BuscarEntrenador(int id);
    }
}