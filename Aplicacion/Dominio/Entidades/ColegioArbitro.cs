using System;
using System.Collections.Generic;
// importar los paquetes relacionados con las aplicaciones
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Dominio
{
    public class ColegioArbitro
    {
        public int Id {get;set;}

        [Required(ErrorMessage="El campo {0}, es Obligatorio")]
        [MaxLength(15, ErrorMessage="No puede superar los 15 caracteres")]
        [MinLength(9, ErrorMessage="Escriba al menos 7 caracteres")]
        // [RegularExpression("[0-9]*", ErrorMessage="Solo se permiten Números")]
        public string Nit {get;set;}

        [Required(ErrorMessage="El campo {0}, es Obligatorio")]
        // [MaxLength(10, ErrorMessage="El campo {0}, no puede superar {1}, caracteres")]
        // [MinLength(5, ErrorMessage="El campo {0}, debe superar los {1}, caracteres")]
        public string Resolucion {get;set;}

        public string Direccion {get;set;}

        [Required(ErrorMessage="El campo {0}, es Obligatorio")]
        public string Telefono {get;set;}

        [EmailAddress(ErrorMessage="Ingrese un Email Valido")]
        public string Correo {get;set;}

        public List<Arbitro> Arbitros {get;set;}
    }
}