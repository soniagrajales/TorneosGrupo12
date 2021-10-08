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
    public class EditModel : PageModel
    {
        private readonly IREntrenador _repoent;
        private readonly IREquipo _repoeq;

        public EditModel(IREntrenador repoent, IREquipo repoeq)
        {
            this._repoent = repoent;
            this._repoeq = repoeq;
        }

        [BindProperty]
        public Entrenador Entrenador{get;set;}
        public IEnumerable<Equipo> Equipos{get;set;}

        public ActionResult OnGet(int id)
        {
            Entrenador=_repoent.BuscarEntrenador(id);
            Equipos=_repoeq.ListarEquipos();
            if(Entrenador!=null)
            {
                return Page();
            }
            else
            {
                return RedirectToPage("./Index");
            }
        }
        public ActionResult OnPost()
        {
            bool funciono=_repoent.ActualizarEntrenador(Entrenador);
            if(funciono)
            {
                return RedirectToPage("./Index");
            }
            else
            {
                Equipos=_repoeq.ListarEquipos();
                ViewData["Error"]="El entrenador ya existe";
                return Page();
            }
        }
    }
}