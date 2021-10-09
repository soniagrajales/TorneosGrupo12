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
    public class EditModel : PageModel
    {
        private readonly IREscenario _repoesc;
        private readonly IRTorneo _repotor;
        public EditModel(IREscenario repoesc, IRTorneo repotor)
        {
            this._repoesc= repoesc;
            this._repotor= repotor;
        }
        [BindProperty]
        public Escenario Escenario{get;set;}
        public IEnumerable<Torneo> Torneos{get;set;}
        public Torneo Torneo{get;set;}

        public ActionResult OnGet(int id)
        {
            Escenario=_repoesc.BuscarEscenario(id);
            if(Escenario!=null)
            {
                Torneos=_repotor.ListarTorneos();
                return Page();
            }
            else
            {
                return RedirectToPage("./Index");
            }
        }

        public ActionResult OnPost()
        {
            bool funciono=_repoesc.ActualizarEscenario(Escenario);
            if(funciono)
            {
                return RedirectToPage("./Index");
            }
            else
            {
                ViewData["Error"]="El patrocinador ya existe";
                return Page();
            }
        }
    }
}
