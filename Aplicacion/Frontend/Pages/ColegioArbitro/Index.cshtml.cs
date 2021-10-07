using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dominio;
using Persistencia;

namespace Frontend.Pages.CColegioArbitro
{
    public class IndexModel : PageModel
    {
        // propiedad u objeto para poder consumir los servicios del repositorio
        private readonly IRColegioArbitro _repocol;
        // declarar el tipo de modelo en el que se transporta informaciòn hacia el MIndex.cshtml
        public IEnumerable<ColegioArbitro> ColegioArbitros {get;set;}

        // crear el constructor de la clase
        public IndexModel(IRColegioArbitro repocol)
        {
            this._repocol=repocol;
        }

        public void OnGet()
        {
            ColegioArbitros=_repocol.ListarColegioArbitros();
        }
    }
}