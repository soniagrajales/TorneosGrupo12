using System.Collections.Generic;
using Dominio;
using System.Linq;

namespace Persistencia
{
    public class RArbitro:IRArbitro
    {
        // Atributos de clase
        private readonly AppContext _appContext;

        //Metodos de clase
        //Constructor
        public RArbitro(AppContext appContext)
        {
            _appContext=appContext;
        }
        public bool CrearArbitro(Arbitro obj)
        {
            bool adicionado= false;
            bool valido= ValidarNombre(obj);
            if(valido)
            {
                try
                {
                    _appContext.Arbitros.Add(obj);
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
        public bool EliminarArbitro(int id)
        {
            bool eliminado=false;
            var tor=_appContext.Arbitros.Find(id);
            if(tor!=null)
            {
                try
                {
                     _appContext.Arbitros.Remove(tor);
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
        public Arbitro BuscarArbitro(int id)
        {
            Arbitro obj = _appContext.Arbitros.Find(id);
            return obj;
        }
        public bool ActualizarArbitro(Arbitro obj)
        {
            bool actualizado= false;
            //bool valido= ValidarIdentificacion(obj);
            //if(valido)
           // {
                var tor= _appContext.Arbitros.Find(obj.Id);
                if(tor!=null)
                {
                    try
                    {
                        tor.Documento=obj.Documento;
                        tor.Nombres=obj.Nombres;
                        tor.Apellidos=obj.Apellidos;
                        tor.Celular=obj.Celular;
                        tor.Genero=obj.Genero;
                        tor.Disciplina=obj.Disciplina;
                        tor.TorneoId=obj.TorneoId;
                        tor.ColegioArbitroId=obj.ColegioArbitroId;
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
        public IEnumerable<Arbitro> ListarArbitros()
        {
            return _appContext.Arbitros;
        }
        bool ValidarNombre(Arbitro obj)
        {
            bool valido= true;
            var tor = _appContext.Arbitros.FirstOrDefault(t=>t.Nombres==obj.Nombres);
            if(tor!=null)
            {
                valido=false;
            }
            return valido;

        }

        List<Arbitro> IRArbitro.ListarArbitros1()
        {
            return _appContext.Arbitros.ToList();
        }

        

    }
    
}