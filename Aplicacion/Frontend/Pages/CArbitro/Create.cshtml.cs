using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dominio;
using Persistencia;
//comentariouno

namespace Frontend.Pages.CArbitro
{
    public class CreateModel : PageModel
    {
        private readonly IRArbitro _repoarb;
        //objeto para acceder al repositorio de equipos
        private readonly IRTorneo _repotor;
        private readonly IRColegioArbitro _repocol;

        //Crear
        public CreateModel(IRArbitro repoarb, IRTorneo repotor, IRColegioArbitro repocol)
        {
            this._repoarb=repoarb;
            this._repotor= repotor;
            this._repocol=repocol;
        }

        [BindProperty]
        public Arbitro Arbitro{get;set;}
        public IEnumerable<Torneo> Torneos{get;set;}
        public IEnumerable<ColegioArbitro> ColegioArbitros{get;set;}
        
        public ActionResult OnGet()
        {
            Torneos=_repotor.ListarTorneos();
            ColegioArbitros=_repocol.ListarColegioArbitros();
            return Page();
        }

        public ActionResult OnPost()
        {
            bool funciono=_repoarb.CrearArbitro(Arbitro);
            if(funciono)
            {
                return RedirectToPage("./Index");
            }
            else
            {
                Torneos=_repotor.ListarTorneos();
                ColegioArbitros=_repocol.ListarColegioArbitros();
                ViewData["Error"]="El árbitro ya se encuentra registrado";
                return Page();
            }
        }
    }
}
