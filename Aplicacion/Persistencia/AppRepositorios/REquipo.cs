using System.Collections.Generic;
using Dominio;
using System.Linq;

namespace Persistencia
{
    public class REquipo:IREquipo
    {
        // Atributos de clase
        private readonly AppContext _appContext;

        //Metodos de clase
        //Constructor
        public REquipo(AppContext appContext)
        {
            _appContext=appContext;
        }
        public bool CrearEquipo(Equipo obj)
        {
            bool adicionado= false;
            bool valido= ValidarNombre(obj);
            if(valido)
            {
                try
                {
                    _appContext.Equipos.Add(obj);
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
        public bool EliminarEquipo(int id)
        {
            bool eliminado=false;
            var equi=_appContext.Equipos.Find(id);
            if(equi!=null)
            {
                try
                {
                     _appContext.Equipos.Remove(equi);
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
        public Equipo BuscarEquipo(int id)
        {
            Equipo obj = _appContext.Equipos.Find(id);
            return obj;
        }
        public bool ActualizarEquipo(Equipo obj)
        {
            bool actualizado= false;
            //bool valido= ValidarIdentificacion(obj);
            //if(valido)
           // {
                var equi= _appContext.Equipos.Find(obj.Id);
                if(equi!=null)
                {
                    try
                    {
                        equi.Nombre=obj.Nombre;
                        equi.Disciplina=obj.Disciplina;
                        equi.PatrocinadorId=obj.PatrocinadorId;
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
        public IEnumerable<Equipo> ListarEquipos()
        {
            return _appContext.Equipos;
        }
        public List<Equipo> ListarEquipos1()
        {
            return _appContext.Equipos.ToList();
        }
        bool ValidarNombre(Equipo obj)
        {
            bool valido= true;
            var equi = _appContext.Equipos.FirstOrDefault(t=>t.Nombre==obj.Nombre);
            if(equi!=null)
            {
                valido=false;
            }
            return valido;
        }
    }
}