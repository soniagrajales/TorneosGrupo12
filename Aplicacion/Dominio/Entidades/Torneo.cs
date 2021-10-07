// Espacio para importaciones
using System;
using System.Collections.Generic;

namespace Dominio
{
    public class Torneo
    {
        public int Id {get;set;}
        public string Nombre {get;set;}
        public string Categoria{get;set;}
        public DateTime FechaInicial{get;set;}
        public DateTime FechaFinal{get;set;}
        public string Horario {get;set;}
        //llave forane para la relaciòn con Municipio
        public int MunicipioId{get;set;}
         // crear la propiedad navigacional hacia la tabla intermedia
        public List<TorneoEquipo> TorneoEquipos {get;set;}
        //propiedad navigacional para la relacion con Escenario
        public List<Escenario> Escenarios{get;set;}
        // propiedad navigacional para la relaciòn con Arbitro
        public List<Arbitro> Arbitros {get;set;}
    }
}
