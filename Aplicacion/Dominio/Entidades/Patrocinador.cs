// Espacio para importaciones
using System;
using System.Collections.Generic;
// importar los paquetes relacionados con las aplicaciones
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio
{
    public class Patrocinador
    {
        public int Id {get;set;}


        [Required(ErrorMessage="El campo {0}, es Obligatorio")]
        [MaxLength(15, ErrorMessage="No puede superar los 15 caracteres")]
        [MinLength(7, ErrorMessage="Escriba al menos 7 caracteres")]
        [RegularExpression("[0-9]*", ErrorMessage="Solo se permiten Números")]
        public string Identificacion {get;set;}


        [Required(ErrorMessage="El campo {0}, es Obligatorio")]
        [MaxLength(30, ErrorMessage="El campo {0}, no puede superar {1}, caracteres")]
        [MinLength(5, ErrorMessage="El campo {0}, debe superar los {1}, caracteres")]
        [RegularExpression("[A-Za-z ]*", ErrorMessage="Solo se permiten Letras")]
        public string Nombre {get;set;}

        [Required(ErrorMessage="El campo {0}, es Obligatorio")]
        // [MaxLength(10, ErrorMessage="El campo {0}, no puede superar {1}, caracteres")]
        // [MinLength(5, ErrorMessage="El campo {0}, debe superar los {1}, caracteres")]
        public string TipoPersona {get;set;}

        public string Direccion {get;set;}

        [Required(ErrorMessage="El campo {0}, es Obligatorio")]
        [Range(3000000000, 3219999999, ErrorMessage="Ingrese un numero de celular Valido")]
        public string Celular {get;set;}
        //propiedad navigacional para la relacion con Equipo
        public List<Equipo>Equipos {get;set;}
       
    }
}
