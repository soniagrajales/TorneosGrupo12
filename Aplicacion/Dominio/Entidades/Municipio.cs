// Espacio para importaciones
using System;
using System.Collections.Generic;

namespace Dominio
{
    public class Municipio
    {
        public int Id {get;set;}
        public string Nombre {get;set;}
        public string Capital {get;set;}
        //propiedad navigacional para la relaciòn con Torneo
        public List<Torneo> Torneos {get;set;}
    }
}
