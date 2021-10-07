using System;
using System.Collections.Generic;

namespace Dominio
{
    public class Cancha
    {
        public int Id {get;set;}
        public string Nombre {get;set;}
        public string Disciplina {get;set;}
        public int CapacidadEsp {get;set;}
        // llave foránea de la tabla Escenario
        public int EscenarioId {get;set;}
    }
}