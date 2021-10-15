// Espacio para importaciones
using System;
using System.Collections.Generic;
// importar los paquetes relacionados con las aplicaciones
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio
{
    public class Equipo
    {
        public int Id {get;set;}


        [Required(ErrorMessage="El campo Nombre es Obligatorio")]
        [MaxLength(15, ErrorMessage="El campo {0}, no puede superar {1}, caracteres")]
        [MinLength(5, ErrorMessage="El campo {0}, debe superar los {1}, caracteres")]
        public string Nombre {get;set;}

        [Required(ErrorMessage="El campo Nombre es Obligatorio")]
        [MaxLength(15, ErrorMessage="El campo {0}, no puede superar {1}, caracteres")]
        [MinLength(5, ErrorMessage="El campo {0}, debe superar los {1}, caracteres")]
        public string Disciplina {get;set;}

        //llave foranea para la relacion con Patrocinador
        [Required(ErrorMessage="El campo Nombre es Obligatorio")]
        public int PatrocinadorId{get;set;}

        //propiedad navigacional para la relaciòn Deportita
        public List<Deportista> Deportistas{get;set;}
        //propiedad navigacional con la clase Entrenador (1 a 1)
        public Entrenador Entrenador{get;set;}
        // crear la propiedad navigacional hacia la tabla intermedia
        public List<TorneoEquipo> TorneoEquipos {get;set;}
    }
}
