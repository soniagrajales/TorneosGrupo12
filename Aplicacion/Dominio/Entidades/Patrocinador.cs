// Espacio para importaciones
using System;
using System.Collections.Generic;

namespace Dominio
{
    public class Patrocinador
    {
        public int Id {get;set;}
        public string Identificacion {get;set;}
        public string Nombre {get;set;}
        public string TipoPersona {get;set;}
        public string Direccion {get;set;}
        public string Celular {get;set;}
        //propiedad navigacional para la relacion con Equipo
        public List<Equipo>Equipos {get;set;}
       
    }
}
