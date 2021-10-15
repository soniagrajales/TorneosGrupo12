using System.Collections.Generic;
using Dominio;
using System.Linq;

namespace Persistencia
{
    public class RepositorioMunicipio:IRepositorioMunicipio
    {
        // Atributos de clase
        private readonly AppContext _appContext;

        //Metodos de clase
        //Constructor
        public RepositorioMunicipio(AppContext appContext)
        {
            _appContext=appContext;
        }
        bool IRepositorioMunicipio.CrearMunicipio(Municipio municipio)
        {
            bool adicionado= false;
            bool valido= ValidarNombre(municipio);
            if(valido)
            {
                try
                {
                    _appContext.Municipios.Add(municipio);
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
        bool IRepositorioMunicipio.EliminarMunicipio(int idMunicipio)
        {
            bool eliminado=false;
            var municipio=_appContext.Municipios.Find(idMunicipio);
            if(municipio!=null)
            {
                var torneo = _appContext.Torneos.FirstOrDefault(t=>t.MunicipioId==municipio.Id);
                if(torneo==null)
                {
                    try
                    {
                        _appContext.Municipios.Remove(municipio);
                        _appContext.SaveChanges();
                        eliminado=true;
                    }
                    catch (System.Exception)
                    {
                    
                        return eliminado;
                    }
                }
            }
            return eliminado;
        }
        Municipio IRepositorioMunicipio.BuscarMunicipio(int idMunicipio)
        {
            Municipio municipio = _appContext.Municipios.Find(idMunicipio);
            return municipio;
        }
        bool IRepositorioMunicipio.ActualizarMunicipio(Municipio municipio)
        {
            bool actualizado= false;
            var mun= _appContext.Municipios.Find(municipio.Id);
            if(mun!=null)
            {
                try
                {
                     mun.Nombre=municipio.Nombre;
                     _appContext.SaveChanges();
                     actualizado=true;
                }
                catch (System.Exception)
                {
                    
                    return actualizado;
                }
            }
            return actualizado;
        }
        IEnumerable<Municipio> IRepositorioMunicipio.ListarMunicipios()
        {
            return _appContext.Municipios;
        }
        List<Municipio> IRepositorioMunicipio.ListarMunicipios1()
        {
            return _appContext.Municipios.ToList();
        }
        bool ValidarNombre(Municipio muni)
        {
            bool valido= true;
            var mun = _appContext.Municipios.FirstOrDefault(m=>m.Nombre==muni.Nombre);
            if(mun!=null)
            {
                valido=false;
            }
            return valido;

        }

    }
    
}