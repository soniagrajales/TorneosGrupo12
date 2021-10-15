// Espacio para importaciones
using System;
using System.Collections.Generic;
// importar los paquetes relacionados con las aplicaciones
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio
{
    public class Municipio
    {
        // [Key]
        public int Id {get;set;}

        [Required(ErrorMessage="El campo {0}, es Obligatorio")]
        [MaxLength(25, ErrorMessage="No puede superar los 25 caracteres")]
        [MinLength(5, ErrorMessage="Escriba al menos 5 caracteres")]
        [RegularExpression("[A-Za-z ]*", ErrorMessage="Solo se permiten Letras")]
        public string Nombre {get;set;}

        public string Capital {get;set;}
        //propiedad navigacional para la relaciòn con Torneo
        public List<Torneo> Torneos {get;set;}
    }
}
