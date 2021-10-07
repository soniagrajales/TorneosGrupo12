// Espacio para importaciones
using System;
using System.Collections.Generic;

namespace Dominio
{
    public class Entrenador
    {
        public int Id {get;set;}
        public string Documento {get;set;}
        public string Nombres {get;set;}
        public string Apellidos {get;set;}
        public string Genero {get;set;}
        //llave foranea con la clase Equipo
        public int EquipoId{get;set;}
       
    }
}
