using System.Collections.Generic;
using Dominio;
using System.Linq;

namespace Persistencia
{
    public class RDeportista:IRDeportista
    {
        // Atributos de clase
        private readonly AppContext _appContext;

        //Metodos de clase
        //Constructor
        public RDeportista(AppContext appContext)
        {
            _appContext=appContext;
        }
        public bool CrearDeportista(Deportista obj)
        {
            bool adicionado= false;
            bool valido= ValidarNombre(obj);
            if(valido)
            {
                try
                {
                    _appContext.Deportistas.Add(obj);
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
        public bool EliminarDeportista(int id)
        {
            bool eliminado=false;
            var tor=_appContext.Deportistas.Find(id);
            if(tor!=null)
            {
                try
                {
                     _appContext.Deportistas.Remove(tor);
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
        public Deportista BuscarDeportista(int id)
        {
            Deportista obj = _appContext.Deportistas.Find(id);
            return obj;
        }
        public bool ActualizarDeportista(Deportista obj)
        {
            bool actualizado= false;
            //bool valido= ValidarIdentificacion(obj);
            //if(valido)
           // {
                var tor= _appContext.Deportistas.Find(obj.Id);
                if(tor!=null)
                {
                    try
                    {
                        tor.Documento=obj.Documento;
                        tor.Nombres=obj.Nombres;
                        tor.Apellidos=obj.Apellidos;
                        tor.Direccion=obj.Direccion;
                        tor.Celular=obj.Celular;
                        tor.Genero=obj.Genero;
                        tor.Rh=obj.Rh;
                        tor.EPS=obj.EPS;
                        tor.Disciplina=obj.Disciplina;
                        tor.NumeroEmergencia=obj.NumeroEmergencia;
                        tor.FechaNacimiento=obj.FechaNacimiento;
                        tor.EquipoId=obj.EquipoId;
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
        public IEnumerable<Deportista> ListarDeportistas()
        {
            return _appContext.Deportistas;
        }
        bool ValidarNombre(Deportista obj)
        {
            bool valido= true;
            var tor = _appContext.Deportistas.FirstOrDefault(t=>t.Nombres==obj.Nombres);
            if(tor!=null)
            {
                valido=false;
            }
            return valido;

        }

        List<Deportista> IRDeportista.ListarDeportistas1()
        {
            return _appContext.Deportistas.ToList();
        }

        

    }
    
}