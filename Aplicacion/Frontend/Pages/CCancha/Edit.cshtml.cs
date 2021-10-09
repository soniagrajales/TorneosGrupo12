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
    public class EditModel : PageModel
    {
        private readonly IRCancha _repocan;
        private readonly IREscenario _repoesc;
        public EditModel(IRCancha repocan, IREscenario repoesc)
        {
            this._repocan= repocan;
            this._repoesc= repoesc;
        }
        [BindProperty]
        public Cancha Cancha{get;set;}
        public IEnumerable<Escenario> Escenarios{get;set;}
        public Escenario Escenario{get;set;}

        public ActionResult OnGet(int id)
        {
            Cancha=_repocan.BuscarCancha(id);
            if(Cancha!=null)
            {
                Escenarios=_repoesc.ListarEscenarios();
                return Page();
            }
            else
            {
                return RedirectToPage("./Index");
            }
        }

        public ActionResult OnPost()
        {
            bool funciono=_repocan.ActualizarCancha(Cancha);
            if(funciono)
            {
                return RedirectToPage("./Index");
            }
            else
            {
                ViewData["Error"]="La cancha ya existe";
                return Page();
            }
        }
    }
}
