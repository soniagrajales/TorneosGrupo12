using System.Collections.Generic;
using Dominio;

namespace Persistencia
{
    public interface IRPatrocinador
    {
        IEnumerable<Patrocinador> ListarPatrocinadores();
        List<Patrocinador> ListarPatrocinadores1();
        bool CrearPatrocinador(Patrocinador obj);
        bool ActualizarPatrocinador(Patrocinador obj);
        bool EliminarPatrocinador(int id);
        Patrocinador BuscarPatrocinador(int id);
    }
}