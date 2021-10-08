using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dominio;
using Persistencia;

namespace Frontend.Pages.CEntrenador
{
    public class DetailsModel : PageModel
    {
        private readonly IREntrenador _repoent;
        private readonly IREquipo _repoeq;

        public DetailsModel(IREntrenador repoent, IREquipo repoeq)
        {
            this._repoent = repoent;
            this._repoeq = repoeq;
        }

        [BindProperty]
        public Entrenador Entrenador{get;set;}
        public Equipo Equipo{get;set;}

        public ActionResult OnGet(int id)
        {
            Entrenador=_repoent.BuscarEntrenador(id);
            Equipo = _repoeq.BuscarEquipo(Entrenador.EquipoId);
            if(Entrenador!=null)
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
