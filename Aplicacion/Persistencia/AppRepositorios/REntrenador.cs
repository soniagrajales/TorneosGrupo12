using System.Collections.Generic;
using Dominio;
using System.Linq;

namespace Persistencia
{
    public class REntrenador:IREntrenador
    {
        // Atributos de clase
        private readonly AppContext _appContext;

        //Metodos de clase
        //Constructor
        public REntrenador(AppContext appContext)
        {
            _appContext=appContext;
        }
        public bool CrearEntrenador(Entrenador obj)
        {
            bool adicionado= false;
            bool valido= ValidarDocumento(obj);
            if(valido)
            {
                try
                {
                    _appContext.Entrenadores.Add(obj);
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
        public bool EliminarEntrenador(int id)
        {
            bool eliminado=false;
            var ent=_appContext.Entrenadores.Find(id);
            if(ent!=null)
            {
                try
                {
                     _appContext.Entrenadores.Remove(ent);
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
        public Entrenador BuscarEntrenador(int id)
        {
            Entrenador obj = _appContext.Entrenadores.Find(id);
            return obj;
        }
        public bool ActualizarEntrenador(Entrenador obj)
        {
            bool actualizado= false;
            //bool valido= ValidarIdentificacion(obj);
            //if(valido)
           // {
                var ent= _appContext.Entrenadores.Find(obj.Id);
                if(ent!=null)
                {
                    try
                    {
                        ent.Documento=obj.Documento;
                        ent.Nombres=obj.Nombres;
                        ent.Apellidos=obj.Apellidos;
                        ent.Genero=obj.Genero;
                        ent.EquipoId=obj.EquipoId;
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
        public IEnumerable<Entrenador> ListarEntrenadores()
        {
            return _appContext.Entrenadores;
        }
        bool ValidarDocumento(Entrenador obj)
        {
            bool valido= true;
            var ent = _appContext.Entrenadores.FirstOrDefault(t=>t.Documento==obj.Documento);
            if(ent!=null)
            {
                valido=false;
            }
            return valido;
        }

    }
    
}