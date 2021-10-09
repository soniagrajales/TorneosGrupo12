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
    public class DetailsModel : PageModel
    {
        private IRCancha _repocan;
        private IREscenario _repoesc;
        public DetailsModel(IRCancha repocan, IREscenario repoesc)
        {
            this._repocan = repocan;
            this._repoesc= repoesc;
        }
        [BindProperty]
        public Cancha Cancha{get;set;}
        public Escenario Escenario{get;set;}

        public ActionResult OnGet(int id)
        {
            Cancha= _repocan.BuscarCancha(id);
            Escenario= _repoesc.BuscarEscenario(Cancha.EscenarioId);
            if(Cancha!=null)
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
