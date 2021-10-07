// Espacio para importaciones
using System;
using System.Collections.Generic;

namespace Dominio
{
    public class Equipo
    {
        public int Id {get;set;}
        public string Nombre {get;set;}
        public string Disciplina {get;set;}
        //llave foranea para la relacion con Patrocinador
        public int PatrocinadorId{get;set;}
        //propiedad navigacional para la relaciòn Deportita
        public List<Deportista> Deportistas{get;set;}
        //propiedad navigacional con la clase Entrenador (1 a 1)
        public Entrenador Entrenador{get;set;}
        // crear la propiedad navigacional hacia la tabla intermedia
        public List<TorneoEquipo> TorneoEquipos {get;set;}
    }
}
