// Espacio para importaciones
using System;
using System.Collections.Generic;
// importar los paquetes relacionados con las aplicaciones
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Dominio
{
    public class Deportista
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


        public string Direccion {get;set;}


        [Required(ErrorMessage="El campo {0}, es Obligatorio")]
        [Range(3000000000, 3219999999, ErrorMessage="Ingrese un numero de celular Valido")]
        public string Celular {get;set;}

        [Required(ErrorMessage="El campo {0}, es Obligatorio")]
        // [MaxLength(10, ErrorMessage="El campo {0}, no puede superar {1}, caracteres")]
        // [MinLength(8, ErrorMessage="El campo {0}, debe superar los {1}, caracteres")]
        [RegularExpression("[A-Za-z ]*", ErrorMessage="Solo se permiten Letras")]
        public string Genero {get;set;}

        [Required(ErrorMessage="El campo {0}, es Obligatorio")]
        [MaxLength(5, ErrorMessage="El campo {0}, no puede superar {1}, caracteres")]
        [MinLength(2, ErrorMessage="El campo {0}, debe superar los {1}, caracteres")]
        // [RegularExpression("[A-Za-z ]*", ErrorMessage="Solo se permiten Letras")]
        public string Rh {get;set;}

        [Required(ErrorMessage="El campo {0}, es Obligatorio")]
        [MaxLength(30, ErrorMessage="El campo {0}, no puede superar {1}, caracteres")]
        [MinLength(8, ErrorMessage="El campo {0}, debe superar los {1}, caracteres")]
        [RegularExpression("[A-Za-z ]*", ErrorMessage="Solo se permiten Letras")]
        public string EPS {get;set;}

        [Required(ErrorMessage="El campo {0}, es Obligatorio")]
        [MaxLength(30, ErrorMessage="El campo {0}, no puede superar {1}, caracteres")]
        [MinLength(8, ErrorMessage="El campo {0}, debe superar los {1}, caracteres")]
        [RegularExpression("[A-Za-z ]*", ErrorMessage="Solo se permiten Letras")]
        public string Disciplina {get;set;}

        [Required(ErrorMessage="El campo {0}, es Obligatorio")]
        [Range(3000000000, 3219999999, ErrorMessage="Ingrese un numero de celular Valido")]
        public string NumeroEmergencia {get;set;}

        [Required(ErrorMessage="El campo {0}, es Obligatorio")]
        [DataType(DataType.Date)]
        public DateTime FechaNacimiento {get;set;}

        //llave foranea para la relaciòn con Equipo
        [Required(ErrorMessage="El campo {0}, es Obligatorio")]
        public int EquipoId{get;set;}
    }
}
