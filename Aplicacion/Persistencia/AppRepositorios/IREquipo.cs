using System.Collections.Generic;
using Dominio;

namespace Persistencia
{
    public interface IREquipo
    {
        IEnumerable<Equipo> ListarEquipos();
        List<Equipo> ListarEquipos1();
        bool CrearEquipo(Equipo obj);
        bool ActualizarEquipo(Equipo obj);
        bool EliminarEquipo(int id);
        Equipo BuscarEquipo(int id);
    }
}