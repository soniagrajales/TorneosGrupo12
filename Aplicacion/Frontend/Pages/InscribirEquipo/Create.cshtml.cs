using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dominio;
using Persistencia;

namespace Frontend.Pages.CInscribirEquipo
{
    public class CreateModel : PageModel
    {
        private readonly IRTorneoEquipo _repotorequ;
        private readonly IRTorneo _repotor;
        private readonly IREquipo _repoequ;

        public CreateModel(IRTorneoEquipo repotorequ, IRTorneo repotor, IREquipo repoequ)
        {
            this._repoequ= repoequ;
            this._repotor= repotor;
            this._repotorequ= repotorequ;
        }

        [BindProperty]
        public TorneoEquipo TorneoEquipo{get;set;}
        public IEnumerable<Torneo> Torneos{get;set;}
        public IEnumerable<Equipo> Equipos {get;set;}
        public ActionResult OnGet()
        {
            Torneos=_repotor.ListarTorneos();
            Equipos=_repoequ.ListarEquipos();
            return Page();
        }

        public ActionResult OnPost()
        {
            bool funciono= _repotorequ.CrearTorneoEquipo(TorneoEquipo);
            if(funciono)
            {
                return RedirectToPage("./Index");
            }
            else
            {
                Torneos=_repotor.ListarTorneos();
                Equipos=_repoequ.ListarEquipos();
                ViewData["Error"]="El equipo ya se encuentra registrado en el torneo";
                return Page();
            }
        }
    }
}
