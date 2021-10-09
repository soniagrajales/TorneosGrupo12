using System.Collections.Generic;
using Dominio;

namespace Persistencia
{
    public interface IREscenario
    {
        IEnumerable<Escenario> ListarEscenarios();
        List<Escenario> ListarEscenarios1();
        bool CrearEscenario(Escenario obj);
        bool ActualizarEscenario(Escenario obj);
        bool EliminarEscenario(int id);
        Escenario BuscarEscenario(int id);
    }
}