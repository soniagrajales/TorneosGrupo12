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
    public class DeleteModel : PageModel
    {
        private readonly IREntrenador _repoent;
        private readonly IREquipo _repoeq;

        public DeleteModel(IREntrenador repoent, IREquipo repoeq)
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
                ViewData["Confirmar"]="Esta seguro de eliminar este registro?";
                return Page();
            }
            else
            {
                return RedirectToPage("./Index");
            }
        }

        public ActionResult OnPost()
        {
            bool funciono=_repoent.EliminarEntrenador(Entrenador.Id);
            if(funciono)
            {
                return RedirectToPage("./Index");
            }
            else
            {
                ViewData["Error"]="No se puede eliminar el entrenador";
                return Page();
            }
        }
    }
}
