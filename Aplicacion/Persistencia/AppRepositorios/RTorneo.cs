using System.Collections.Generic;
using Dominio;
using System.Linq;

namespace Persistencia
{
    public class RTorneo:IRTorneo
    {
        // Atributos de clase
        private readonly AppContext _appContext;

        //Metodos de clase
        //Constructor
        public RTorneo(AppContext appContext)
        {
            _appContext=appContext;
        }
        public bool CrearTorneo(Torneo obj)
        {
            bool adicionado= false;
            bool valido= ValidarNombre(obj);
            if(valido)
            {
                try
                {
                    _appContext.Torneos.Add(obj);
                    _appContext.SaveChanges();
                    adicionado=true;
                }
                catch (System.Exception)
                {
                    return adicionado;
                   
                }
            }
            return adicionado;
        }
        public bool EliminarTorneo(int id)
        {
            bool eliminado=false;
            var tor=_appContext.Torneos.Find(id);
            if(tor!=null)
            {
                try
                {
                     _appContext.Torneos.Remove(tor);
                     _appContext.SaveChanges();
                     eliminado=true;
                }
                catch (System.Exception)
                {                    
                   return eliminado;
                }
            }
            return eliminado;
        }
        public Torneo BuscarTorneo(int id)
        {
            Torneo obj = _appContext.Torneos.Find(id);
            return obj;
        }
        public bool ActualizarTorneo(Torneo obj)
        {
            bool actualizado= false;
            //bool valido= ValidarIdentificacion(obj);
            //if(valido)
           // {
                var tor= _appContext.Torneos.Find(obj.Id);
                if(tor!=null)
                {
                    try
                    {
                        tor.Nombre=obj.Nombre;
                        tor.Categoria=obj.Categoria;
                        tor.FechaInicial=obj.FechaFinal;
                        tor.FechaFinal=obj.FechaFinal;
                        tor.Horario=obj.Horario;
                        tor.MunicipioId=obj.MunicipioId;
                        _appContext.SaveChanges();
                        actualizado=true;
                    }
                    catch (System.Exception)
                    {                        
                        return actualizado;
                    }
                }

            //}
            
            return actualizado;
        }
        public IEnumerable<Torneo> ListarTorneos()
        {
            return _appContext.Torneos;
        }
        bool ValidarNombre(Torneo obj)
        {
            bool valido= true;
            var tor = _appContext.Torneos.FirstOrDefault(t=>t.Nombre==obj.Nombre);
            if(tor!=null)
            {
                valido=false;
            }
            return valido;

        }

    }
    
}