using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dominio;
using Persistencia;

namespace Frontend.Pages.CArbitro
{
    public class EditModel : PageModel
    {
        private readonly IRArbitro _repoarb;
        private readonly IRTorneo _repotor;
        private readonly IRColegioArbitro _repocol;
        public EditModel(IRArbitro repoarb, IRTorneo repotor, IRColegioArbitro repocol)
        {
            this._repoarb= repoarb;
            this._repotor= repotor;
            this._repocol= repocol;
        }
        [BindProperty]
        public Arbitro Arbitro{get;set;}
        public IEnumerable<Torneo> Torneos{get;set;}
        public IEnumerable<ColegioArbitro> ColegioArbitros{get;set;}
        public Torneo Torneo{get;set;}
        public ColegioArbitro ColegioArbitro{get;set;}

        public ActionResult OnGet(int id)
        {
            Arbitro=_repoarb.BuscarArbitro(id);
            if(Arbitro!=null)
            {
                Torneos=_repotor.ListarTorneos();
                ColegioArbitros=_repocol.ListarColegioArbitros();
                return Page();
            }
            else
            {
                return RedirectToPage("./Index");
            }
        }

        public ActionResult OnPost()
        {
            // validar los datos que llegan del formulario
            if(!ModelState.IsValid)
             {
                 return Page();
             }

            bool funciono=_repoarb.ActualizarArbitro(Arbitro);
            if(funciono)
            {
                return RedirectToPage("./Index");
            }
            else
            {
                ViewData["Error"]="El árbitro ya existe";
                return Page();
            }
        }
    }
}
