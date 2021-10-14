// Espacio para importaciones
using System;
using System.Collections.Generic;

namespace Dominio
{
    public class TorneoEquipo
    {
        public int EquipoId {get;set;}
        public int TorneoId {get;set;}
        public int Posicion {get;set;}
        // crear propiedad navigacional hacia la tabla Equipo
        public Equipo Equipo{get;set;}
         // crear propiedad navigacional hacia la tabla Torneo
        public Torneo Torneo{get;set;}
        
    }
}
