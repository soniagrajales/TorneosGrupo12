using System.Collections.Generic;
using Dominio;
using System.Linq;

namespace Persistencia
{
    public class RCancha:IRCancha
    {
        // Atributos de clase
        private readonly AppContext _appContext;

        //Metodos de clase
        //Constructor
        public RCancha(AppContext appContext)
        {
            _appContext=appContext;
        }
        public bool CrearCancha(Cancha obj)
        {
            bool adicionado= false;
            bool valido= ValidarNombre(obj);
            if(valido)
            {
                try
                {
                    _appContext.Canchas.Add(obj);
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
        public bool EliminarCancha(int id)
        {
            bool eliminado=false;
            var esc=_appContext.Canchas.Find(id);
            if(esc!=null)
            {
                try
                {
                     _appContext.Canchas.Remove(esc);
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
        public Cancha BuscarCancha(int id)
        {
            Cancha obj = _appContext.Canchas.Find(id);
            return obj;
        }
        public bool ActualizarCancha(Cancha obj)
        {
            bool actualizado= false;
            //bool valido= ValidarIdentificacion(obj);
            //if(valido)
           // {
                var esc= _appContext.Canchas.Find(obj.Id);
                if(esc!=null)
                {
                    try
                    {
                        esc.Nombre=obj.Nombre;
                        esc.Disciplina=obj.Disciplina;
                        esc.CapacidadEsp=obj.CapacidadEsp;
                        esc.EscenarioId=obj.EscenarioId;
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
        public IEnumerable<Cancha> ListarCanchas()
        {
            return _appContext.Canchas;
        }
        bool ValidarNombre(Cancha obj)
        {
            bool valido= true;
            var esc = _appContext.Canchas.FirstOrDefault(e=>e.Nombre==obj.Nombre);
            if(esc!=null)
            {
                valido=false;
            }
            return valido;

        }

        List<Cancha> IRCancha.ListarCanchas1(){
            return _appContext.Canchas.ToList();
        }

    }
    
}