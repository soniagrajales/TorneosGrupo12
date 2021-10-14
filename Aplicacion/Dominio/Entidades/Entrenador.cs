// Espacio para importaciones
using System;
using System.Collections.Generic;
// importar los paquetes relacionados con las aplicaciones
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio
{
    public class Entrenador
    {
        public int Id {get;set;}


        [Required(ErrorMessage="El campo {0}, es Obligatorio")]
        [MaxLength(15, ErrorMessage="No puede superar los 15 caracteres")]
        [MinLength(7, ErrorMessage="Escriba al menos 7 caracteres")]
        [RegularExpression("[0-9]*", ErrorMessage="Solo se permiten Números")]
        public string Documento {get;set;}

        [Required(ErrorMessage="El campo {0}, es Obligatorio")]
        [MaxLength(30, ErrorMessage="El campo {0}, no puede superar {1}, caracteres")]
        [MinLength(5, ErrorMessage="El campo {0}, debe superar los {1}, caracteres")]
        [RegularExpression("[A-Za-z ]*", ErrorMessage="Solo se permiten Letras")]
        public string Nombres {get;set;}

        [Required(ErrorMessage="El campo {0}, es Obligatorio")]
        [MaxLength(30, ErrorMessage="El campo {0}, no puede superar {1}, caracteres")]
        [MinLength(5, ErrorMessage="El campo {0}, debe superar los {1}, caracteres")]
        [RegularExpression("[A-Za-z ]*", ErrorMessage="Solo se permiten Letras")]
        public string Apellidos {get;set;}

        [Required(ErrorMessage="El campo {0}, es Obligatorio")]
        // [MaxLength(10, ErrorMessage="El campo {0}, no puede superar {1}, caracteres")]
        // [MinLength(8, ErrorMessage="El campo {0}, debe superar los {1}, caracteres")]
        // [RegularExpression("[A-Za-z ]*", ErrorMessage="Solo se permiten Letras")]
        public string Genero {get;set;}

        //llave foranea con la clase Equipo
        [Required(ErrorMessage="El campo {0}, es Obligatorio")]
        public int EquipoId{get;set;}
       
    }
}
