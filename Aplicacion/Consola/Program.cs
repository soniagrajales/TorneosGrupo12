using System;
using Dominio;
using Persistencia;
using System.Collections.Generic;

namespace Consola
{
    class Program
    {
        private static IRepositorioMunicipio _repomunicipio= new RepositorioMunicipio(new Persistencia.AppContext());
        static void Main(string[] args)
        {
            bool f= crearMunicipio();
            if(f)
            {
                Console.WriteLine("El municipio fue adicinado...");
            }
            else
            {
                Console.WriteLine("Ha ocurrido una falla en el proceso...");
            }
            
            /*bool f= eliminarMunicipio();
            if(f)
            {
                Console.WriteLine("El municipio fue aeliminado...");
            }
            else
            {
                Console.WriteLine("Ha ocurrido una falla en el proceso...");
            }
            Console.WriteLine("Lista actualizada");

            listarMunicipios();*/
            //buscarMunicipio();
            /*bool f= actualizarMunicipio();
            if(f)
            {
                Console.WriteLine("El municipio fue actualizado...");
            }
            else
            {
                Console.WriteLine("Ha ocurrido una falla en el proceso...");
            }*/

            Console.WriteLine("Lista actualizada");

            listarMunicipios();
        }

        private static bool crearMunicipio()
        {
            var municipio= new Municipio
            {               
                Nombre="Pasto"
            };
            bool funciono=_repomunicipio.CrearMunicipio(municipio);
            return funciono;
        }
        private static void listarMunicipios()
        {
            IEnumerable<Municipio> municipios= _repomunicipio.ListarMunicipios();
            foreach (var mun in municipios)
            {
                Console.WriteLine(mun.Id +" "+mun.Nombre);
            }
        }
        private static bool eliminarMunicipio()
        {
            bool funciono= _repomunicipio.EliminarMunicipio(1);
            return funciono;
        }
        private static void buscarMunicipio()
        {
            var municipio= _repomunicipio.BuscarMunicipio(3);
            if(municipio!=null)
            {
                Console.WriteLine(municipio.Id);
                Console.WriteLine(municipio.Nombre);
            }
            else
            {
                Console.WriteLine("Municipio no encontrado o no registrado..");
            }
        }

        private static bool actualizarMunicipio()
        {
            var muni = new Municipio
            {
                Id=2,
                Nombre="Pereira"
            };
            bool funciono= _repomunicipio.ActualizarMunicipio(muni);
            return funciono;
        }
    }

}
