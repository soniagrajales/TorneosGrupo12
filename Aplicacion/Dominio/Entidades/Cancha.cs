using System;
using System.Collections.Generic;
// importar los paquetes relacionados con las aplicaciones
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Dominio
{
    public class Cancha
    {
        public int Id {get;set;}

        [Required(ErrorMessage="El campo {0}, es Obligatorio")]
        [MaxLength(30, ErrorMessage="El campo {0}, no puede superar {1}, caracteres")]
        [MinLength(5, ErrorMessage="El campo {0}, debe superar los {1}, caracteres")]
        public string Nombre {get;set;}

        [Required(ErrorMessage="El campo {0}, es Obligatorio")]
        [MaxLength(30, ErrorMessage="El campo {0}, no puede superar {1}, caracteres")]
        [MinLength(5, ErrorMessage="El campo {0}, debe superar los {1}, caracteres")]
        // [RegularExpression("[A-Za-z ]*", ErrorMessage="Solo se permiten Letras")]
        public string Disciplina {get;set;}

        [Required(ErrorMessage="El campo {0}, es Obligatorio")]
        // [MaxLength(5, ErrorMessage="No puede superar los 5 caracteres")]
        // [MinLength(2, ErrorMessage="Escriba al menos 2 caracteres")]
        [RegularExpression("[0-9]*", ErrorMessage="Solo se permiten Números")]
        public int CapacidadEsp {get;set;}

        // llave foránea de la tabla Escenario
        [Required(ErrorMessage="El campo {0}, es Obligatorio")]
        public int EscenarioId {get;set;}
    }
}