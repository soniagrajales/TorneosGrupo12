using System.Collections.Generic;
using Dominio;
using System.Linq;

namespace Persistencia
{
    public class RTorneoEquipo:IRTorneoEquipo
    {
        // Atributos de clase
        private readonly AppContext _appContext;

        //Metodos de clase
        //Constructor
        public RTorneoEquipo(AppContext appContext)
        {
            _appContext=appContext;
        }
        public bool CrearTorneoEquipo(TorneoEquipo obj)
        {
            bool adicionado= false;
            bool valido= ValidarNombre(obj);
            if(valido)
            {
                try
                {
                    _appContext.TorneoEquipos.Add(obj);
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

        public IEnumerable<TorneoEquipo> ListarTorneoEquipos()
        {
            return _appContext.TorneoEquipos;
        }

        bool ValidarNombre(TorneoEquipo obj)
        {
            bool valido= true;
            var torequ = _appContext.TorneoEquipos.FirstOrDefault(t=>t.EquipoId==obj.EquipoId
                                                                 && t.TorneoId==obj.TorneoId);
            if(torequ!=null)
            {
                valido=false;
            }
            return valido;

        }

        public bool EliminarTorneoEquipo(TorneoEquipo obj)
        {
            bool eliminado=false;
            var torequ = _appContext.TorneoEquipos.FirstOrDefault(t=>t.EquipoId==obj.EquipoId
                                                                 && t.TorneoId==obj.TorneoId);
            if(torequ!=null)
            {
                try
                {
                     _appContext.TorneoEquipos.Remove(torequ);
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

        public TorneoEquipo BuscarTorneoEquipo(TorneoEquipo obj1)
        {
            TorneoEquipo obj = _appContext.TorneoEquipos.FirstOrDefault(t=>t.EquipoId==obj1.EquipoId
                                                                 && t.TorneoId==obj1.TorneoId);
            return obj;
        }

        public IEnumerable<TorneoEquipo> ListarTorneoEquipos(int torneoid)
        {
            return _appContext.TorneoEquipos.Where(te => te.TorneoId==torneoid);
        }

/*  
      public TorneoEquipo BuscarTorneoEquipo(int TorneoId, int EquipoId)
        {
            TorneoEquipo obj = _appContext.TorneoEquipos.FirstOrDefault(t=>t.EquipoId==EquipoId
                                                                 && t.TorneoId==TorneoId);
            return obj;
        }*/
        
    }
    
}