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
    public class CreateModel : PageModel
    {
        private readonly IREntrenador _repoent;
        private readonly IREquipo _repoeq;

        public CreateModel(IREntrenador repoent, IREquipo repoeq)
        {
            this._repoent = repoent;
            this._repoeq = repoeq;
        }

        [BindProperty]
        public Entrenador Entrenador{get;set;}
        public IEnumerable<Equipo> Equipos{get;set;}
        
        public ActionResult OnGet()
        {
            Equipos=_repoeq.ListarEquipos();
            return Page();
        }

        public ActionResult OnPost()
        {
            bool funciono=_repoent.CrearEntrenador(Entrenador);
            if(funciono)
            {
                return RedirectToPage("./Index");
            }
            else
            {
                Equipos=_repoeq.ListarEquipos();
                ViewData["Error"]="el equipo ya se encuentra registrado";
                return Page();
            }
        }
    }
}
