using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dominio;
using Persistencia;

namespace Frontend.Pages.CCancha
{
    public class CreateModel : PageModel
    {
        private readonly IRCancha _repocan;
        //objeto para acceder al repositorio de municipios
        private readonly IREscenario _repoesc;

        public CreateModel(IRCancha repocan, IREscenario repoesc)
        {
            this._repocan=repocan;
            this._repoesc= repoesc;
        }

        [BindProperty]
        public Cancha Cancha{get;set;}
        public IEnumerable<Escenario> Escenarios{get;set;}
        
        public ActionResult OnGet()
        {
            Escenarios=_repoesc.ListarEscenarios();
            return Page();
        }

        public ActionResult OnPost()
        {
            // validar los datos que llegan del formulario
            if(!ModelState.IsValid)
             {
                 return Page();
             }

            bool funciono=_repocan.CrearCancha(Cancha);
            if(funciono)
            {
                return RedirectToPage("./Index");
            }
            else
            {
                Escenarios=_repoesc.ListarEscenarios();
                ViewData["Error"]="Cancha ya se encuentra registrado";
                return Page();
            }
        }
    }
}
