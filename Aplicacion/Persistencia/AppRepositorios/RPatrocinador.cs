using System.Collections.Generic;
using Dominio;
using System.Linq;

namespace Persistencia
{
    public class RPatrocinador:IRPatrocinador
    {
        // Atributos de clase
        private readonly AppContext _appContext;

        //Metodos de clase
        //Constructor
        public RPatrocinador(AppContext appContext)
        {
            _appContext=appContext;
        }
        public bool CrearPatrocinador(Patrocinador obj)
        {
            bool adicionado= false;
            bool valido= ValidarIdentificacion(obj);
            if(valido)
            {
                try
                {
                    _appContext.Patrocinadores.Add(obj);
                    _appContext.SaveChanges();
                    adicionado=true;
                }
                catch (System.Exception)
                {
                    return adicionado;
                    //throw;
                }
            }
            return adicionado;
        }
        public bool EliminarPatrocinador(int id)
        {
            bool eliminado=false;
            var pat=_appContext.Patrocinadores.Find(id);
            if(pat!=null)
            {
                try
                {
                     _appContext.Patrocinadores.Remove(pat);
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
        public Patrocinador BuscarPatrocinador(int id)
        {
            Patrocinador obj = _appContext.Patrocinadores.Find(id);
            return obj;
        }
        public bool ActualizarPatrocinador(Patrocinador obj)
        {
            bool actualizado= false;
            //bool valido= ValidarIdentificacion(obj);
            bool valido = true;
            if(valido)
            {
                var pat= _appContext.Patrocinadores.Find(obj.Id);
                if(pat!=null)
                {
                    try
                    {
                        pat.Nombre=obj.Nombre;
                        pat.Identificacion=obj.Identificacion;
                        pat.TipoPersona=obj.TipoPersona;
                        pat.Direccion=obj.Direccion;
                        pat.Celular=obj.Celular;
                        _appContext.SaveChanges();
                        actualizado=true;
                    }
                    catch (System.Exception)
                    {
                        
                        return actualizado;
                    }
                }

            }
            
            return actualizado;
        }
        public IEnumerable<Patrocinador> ListarPatrocinadores()
        {
            return _appContext.Patrocinadores;
        }
        public List<Patrocinador> ListarPatrocinadores1()
        {
            return _appContext.Patrocinadores.ToList();
        }
        bool ValidarIdentificacion(Patrocinador obj)
        {
            bool valido= true;
            var pat = _appContext.Patrocinadores.FirstOrDefault(p=>p.Identificacion==obj.Identificacion);
            if(pat!=null)
            {
                valido=false;
            }
            return valido;

        }

    }
    
}