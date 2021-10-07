using System.Collections.Generic;
using Dominio;
using System.Linq;

namespace Persistencia
{
    public class RColegioArbitro:IRColegioArbitro
    {
        // Atributos de clase
        private readonly AppContext _appContext;

        //Metodos de clase
        //Constructor
        public RColegioArbitro(AppContext appContext)
        {
            _appContext=appContext;
        }
        public bool CrearColegioArbitro(ColegioArbitro obj)
        {
            bool adicionado= false;
            bool valido= ValidarNit(obj);
            if(valido)
            {
                try
                {
                    _appContext.ColegioArbitros.Add(obj);
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
        public bool EliminarColegioArbitro(int id)
        {
            bool eliminado=false;
            var col=_appContext.ColegioArbitros.Find(id);
            if(col!=null)
            {
                try
                {
                     _appContext.ColegioArbitros.Remove(col);
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
        public ColegioArbitro BuscarColegioArbitro(int id)
        {
            ColegioArbitro obj = _appContext.ColegioArbitros.Find(id);
            return obj;
        }
        public bool ActualizarColegioArbitro(ColegioArbitro obj)
        {
            bool actualizado= false;
            /*
            bool valido= ValidarNit(obj);
            if(valido)
            {
                */
                var col= _appContext.ColegioArbitros.Find(obj.Id);
                if(col!=null)
                {
                    try
                    {
                        col.Nit=obj.Nit;
                        col.Resolucion=obj.Resolucion;
                        col.Direccion=obj.Direccion;
                        col.Telefono=obj.Telefono;
                        col.Correo=obj.Correo;
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
        public IEnumerable<ColegioArbitro> ListarColegioArbitros()
        {
            return _appContext.ColegioArbitros;
        }
        
        bool ValidarNit(ColegioArbitro obj)
        {
            bool valido= true;
            var col = _appContext.ColegioArbitros.FirstOrDefault(p=>p.Nit==obj.Nit);
            if(col!=null)
            {
                valido=false;
            }
            return valido;

        }
        
    }
    
}