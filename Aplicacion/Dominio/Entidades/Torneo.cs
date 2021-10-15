// Espacio para importaciones
using System;
using System.Collections.Generic;
// importar los paquetes relacionados con las aplicaciones
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio
{
    public class Torneo
    {
        public int Id {get;set;}

        [Required(ErrorMessage="El campo {0}, es Obligatorio")]
        [MaxLength(20, ErrorMessage="El campo {0}, no puede superar {1}, caracteres")]
        [MinLength(5, ErrorMessage="El campo {0}, debe superar los {1}, caracteres")]
        public string Nombre {get;set;}

        [Required(ErrorMessage="El campo {0}, es Obligatorio")]
        [MaxLength(15, ErrorMessage="El campo {0}, no puede superar {1}, caracteres")]
        [MinLength(5, ErrorMessage="El campo {0}, debe superar los {1}, caracteres")]
        public string Categoria{get;set;}

        [Required(ErrorMessage="El campo {0}, es Obligatorio")]
        [DataType(DataType.Date)]
        public DateTime FechaInicial{get;set;}

        [Required(ErrorMessage="El campo {0}, es Obligatorio")]
        [DataType(DataType.Date)]
        public DateTime FechaFinal{get;set;}


        public string Horario {get;set;}


        //llave foranea para la relaciòn con Municipio
        [Required(ErrorMessage="El campo {0}, es Obligatorio")]
        public int MunicipioId{get;set;}

         // crear la propiedad navigacional hacia la tabla intermedia
        public List<TorneoEquipo> TorneoEquipos {get;set;}
        //propiedad navigacional para la relacion con Escenario
        public List<Escenario> Escenarios{get;set;}
        // propiedad navigacional para la relaciòn con Arbitro
        public List<Arbitro> Arbitros {get;set;}
    }
}
