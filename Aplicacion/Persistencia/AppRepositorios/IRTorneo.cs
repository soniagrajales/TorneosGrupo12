using System.Collections.Generic;
using Dominio;

namespace Persistencia
{
    public interface IRTorneo
    {
        IEnumerable<Torneo> ListarTorneos();
        List<Torneo> ListarTorneos1();
        bool CrearTorneo(Torneo obj);
        bool ActualizarTorneo(Torneo obj);
        bool EliminarTorneo(int id);
        Torneo BuscarTorneo(int id);
    }
}