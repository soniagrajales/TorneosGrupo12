using System;
using System.Collections.Generic;

namespace Dominio
{
    public class ColegioArbitro
    {
        public int Id {get;set;}
        public string Nit {get;set;}
        public string Resolucion {get;set;}
        public string Direccion {get;set;}
        public string Telefono {get;set;}
        public string Correo {get;set;}
        public List<Arbitro> Arbitros {get;set;}
    }
}