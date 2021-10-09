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
    public class DetailsModel : PageModel
    {
        private IREscenario _repoesc;
        private IRTorneo _repotor;
        public DetailsModel(IREscenario repoesc, IRTorneo repotor)
        {
            this._repoesc = repoesc;
            this._repotor= repotor;
        }
        [BindProperty]
        public Escenario Escenario{get;set;}
        public Torneo Torneo{get;set;}

        public ActionResult OnGet(int id)
        {
            Escenario= _repoesc.BuscarEscenario(id);
            Torneo= _repotor.BuscarTorneo(Escenario.TorneoId);
            if(Escenario!=null)
            {
                return Page();
            }
            else
            {
                return RedirectToPage("./Index");
            }
        }
    }
}
