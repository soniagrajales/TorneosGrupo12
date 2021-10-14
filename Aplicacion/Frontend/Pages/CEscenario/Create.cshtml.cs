using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dominio;
using Persistencia;

namespace Frontend.Pages.CEscenario
{
    public class CreateModel : PageModel
    {
        private readonly IREscenario _repoesc;
        //objeto para acceder al repositorio de municipios
        private readonly IRTorneo _repotor;

        public CreateModel(IREscenario repoesc, IRTorneo repotor)
        {
            this._repoesc=repoesc;
            this._repotor= repotor;
        }

        [BindProperty]
        public Escenario Escenario{get;set;}
        public IEnumerable<Torneo> Torneos{get;set;}
        
        public ActionResult OnGet()
        {
            Torneos=_repotor.ListarTorneos();
            return Page();
        }

        public ActionResult OnPost()
        {
            // validar los datos que llegan del formulario
            if(!ModelState.IsValid)
             {
                 return Page();
             }

            bool funciono=_repoesc.CrearEscenario(Escenario);
            if(funciono)
            {
                return RedirectToPage("./Index");
            }
            else
            {
                Torneos=_repotor.ListarTorneos();
                ViewData["Error"]="torneo ya se encuentra registrado";
                return Page();
            }
        }
    }
}
