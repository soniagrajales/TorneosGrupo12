using System.Collections.Generic;
using Dominio;

namespace Persistencia
{
    public interface IRTorneo
    {
        IEnumerable<Torneo> ListarTorneos();
        bool CrearTorneo(Torneo obj);
        bool ActualizarTorneo(Torneo obj);
        bool EliminarTorneo(int id);
        Torneo BuscarTorneo(int id);
    }
}