using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dominio;
using Persistencia;

namespace Frontend.Pages
{
    public class MIndexModel : PageModel
    {
        // propiedad u objeto para poder consumir los servicios del repositorio
        private readonly IRepositorioMunicipio _repomunicipio;
        // declarar el tipo de modelo en el que se transporta informaciòn hacia el MIndex.cshtml
        public IEnumerable<Municipio> Municipios {get;set;}

        // crear el constructor de la clase
        public  MIndexModel(IRepositorioMunicipio repomunicipio)
        {
            this._repomunicipio=repomunicipio;
        }

        public void OnGet()
        {
            Municipios=_repomunicipio.ListarMunicipios();
        }
    }
}
