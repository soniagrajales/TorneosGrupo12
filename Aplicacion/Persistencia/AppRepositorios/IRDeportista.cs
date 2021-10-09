using System.Collections.Generic;
using Dominio;

namespace Persistencia
{
    public interface IRDeportista
    {
        IEnumerable<Deportista> ListarDeportistas();
        List<Deportista> ListarDeportistas1();
        bool CrearDeportista(Deportista obj);
        bool ActualizarDeportista(Deportista obj);
        bool EliminarDeportista(int id);
        Deportista BuscarDeportista(int id);
    }
}