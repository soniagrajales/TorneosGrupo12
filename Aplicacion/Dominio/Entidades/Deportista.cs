// Espacio para importaciones
using System;
using System.Collections.Generic;

namespace Dominio
{
    public class Deportista
    {
        public int Id {get;set;}
        public string Documento {get;set;}
        public string Nombres {get;set;}
        public string Apellidos {get;set;}
        public string Direccion {get;set;}
        public string Celular {get;set;}
        public string Genero {get;set;}
        public string Rh {get;set;}
        public string EPS {get;set;}
        public string Disciplina {get;set;}
        public string NumeroEmergencia {get;set;}
        public DateTime FechaNacimiento {get;set;}
        //llave foranea para la relaciòn con Equipo
        public int EquipoId{get;set;}
    }
}
