using System.Collections.Generic;
using Dominio;

namespace Persistencia
{
    public interface IRTorneoEquipo
    {
        IEnumerable<TorneoEquipo> ListarTorneoEquipos();
        IEnumerable<TorneoEquipo> ListarTorneoEquipos(int torneoid);
        bool CrearTorneoEquipo(TorneoEquipo obj);
        TorneoEquipo BuscarTorneoEquipo(TorneoEquipo obj);
        //TorneoEquipo BuscarTorneoEquipo(int torneoid, int equipoid);        
        bool EliminarTorneoEquipo(TorneoEquipo obj);
        /*bool ActualizarTorneo(Torneo obj);
        bool EliminarTorneo(int id);
        Torneo BuscarTorneo(int id);*/
    }
}