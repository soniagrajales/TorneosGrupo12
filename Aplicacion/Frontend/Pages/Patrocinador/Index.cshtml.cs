using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dominio;
using Persistencia;

namespace Frontend.Pages.CPatrocinador
{
    public class IndexModel : PageModel
    {
        // propiedad u objeto para poder consumir los servicios del repositorio
        private readonly IRPatrocinador _repopat;
        // declarar el tipo de modelo en el que se transporta informaciòn hacia el MIndex.cshtml
        public IEnumerable<Patrocinador> Patrocinadores {get;set;}

        // crear el constructor de la clase
        public  IndexModel(IRPatrocinador repopat)
        {
            this._repopat=repopat;
        }

        public void OnGet()
        {
            Patrocinadores=_repopat.ListarPatrocinadores();
        }
    }
}
