using System.Collections.Generic;
using Dominio;
using System.Linq;

namespace Persistencia
{
    public class REscenario:IREscenario
    {
        // Atributos de clase
        private readonly AppContext _appContext;

        //Metodos de clase
        //Constructor
        public REscenario(AppContext appContext)
        {
            _appContext=appContext;
        }
        public bool CrearEscenario(Escenario obj)
        {
            bool adicionado= false;
            bool valido= ValidarNombre(obj);
            if(valido)
            {
                try
                {
                    _appContext.Escenarios.Add(obj);
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
        public bool EliminarEscenario(int id)
        {
            bool eliminado=false;
            var esc=_appContext.Escenarios.Find(id);
            if(esc!=null)
            {
                try
                {
                     _appContext.Escenarios.Remove(esc);
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
        public Escenario BuscarEscenario(int id)
        {
            Escenario obj = _appContext.Escenarios.Find(id);
            return obj;
        }
        public bool ActualizarEscenario(Escenario obj)
        {
            bool actualizado= false;
            //bool valido= ValidarIdentificacion(obj);
            //if(valido)
           // {
                var esc= _appContext.Escenarios.Find(obj.Id);
                if(esc!=null)
                {
                    try
                    {
                        esc.Nombre=obj.Nombre;
                        esc.Direcion=obj.Direcion;
                        esc.Telefono=obj.Telefono;
                        esc.TorneoId=obj.TorneoId;
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
        public IEnumerable<Escenario> ListarEscenarios()
        {
            return _appContext.Escenarios;
        }
        bool ValidarNombre(Escenario obj)
        {
            bool valido= true;
            var esc = _appContext.Escenarios.FirstOrDefault(e=>e.Nombre==obj.Nombre);
            if(esc!=null)
            {
                valido=false;
            }
            return valido;

        }

        List<Escenario> IREscenario.ListarEscenarios1(){
            return _appContext.Escenarios.ToList();
        }

    }
    
}