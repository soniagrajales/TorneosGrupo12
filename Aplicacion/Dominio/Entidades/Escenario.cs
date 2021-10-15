using System;
using System.Collections.Generic;
// importar los paquetes relacionados con las aplicaciones
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio
{
    public class Escenario
    {
        public int Id{get;set;}

        [Required(ErrorMessage="El campo {0}, es Obligatorio")]
        [MaxLength(35, ErrorMessage="No puede superar los 35 caracteres")]
        [MinLength(5, ErrorMessage="Escriba al menos 5 caracteres")]
        public string Nombre{get;set;}

        
        public string Direcion{get;set;}

        [Required(ErrorMessage="El campo {0}, es Obligatorio")]
        public string Telefono{get;set;}

        // llave foranea para la relaciòn con Torneo
        [Required(ErrorMessage="El campo {0}, es Obligatorio")]
        public int TorneoId{get;set;}

        // propiedad navigacional con Cancha
        public List<Cancha> Canchas {get;set;}
    }
}