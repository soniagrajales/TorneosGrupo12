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
    public class DetailsModel : PageModel
    {
        private IRArbitro _repoarb;
        private IRTorneo _repotor;
        private IRColegioArbitro _repocol;
        public DetailsModel(IRArbitro repoarb, IRTorneo repotor, IRColegioArbitro repocol)
        {
            this._repoarb = repoarb;
            this._repotor= repotor;
            this._repocol=repocol;
        }
        [BindProperty]
        public Arbitro Arbitro{get;set;}
        public Torneo Torneo{get;set;}
        public ColegioArbitro ColegioArbitro{get;set;}

        public ActionResult OnGet(int id)
        {
            Arbitro= _repoarb.BuscarArbitro(id);
            Torneo= _repotor.BuscarTorneo(Arbitro.TorneoId);
            ColegioArbitro=_repocol.BuscarColegioArbitro(Arbitro.ColegioArbitroId);
            if(Arbitro!=null)
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
