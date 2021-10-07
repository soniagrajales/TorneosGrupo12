using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dominio;
using Persistencia;

namespace Frontend.Pages.CEquipo
{
    public class CreateModel : PageModel
    {
        private readonly IREquipo _repoeq;
        //objeto para acceder al repositorio de patrocinadores
        private readonly IRPatrocinador _repopat;

        public CreateModel(IREquipo repoeq, IRPatrocinador repopat)
        {
            this._repoeq = repoeq;
            this._repopat = repopat;
        }

        [BindProperty]
        public Equipo Equipo{get;set;}
        public IEnumerable<Patrocinador> Patrocinadores{get;set;}
        
        public ActionResult OnGet()
        {
            Patrocinadores=_repopat.ListarPatrocinadores();
            return Page();
        }

        public ActionResult OnPost()
        {
            bool funciono=_repoeq.CrearEquipo(Equipo);
            if(funciono)
            {
                return RedirectToPage("./Index");
            }
            else
            {
                Patrocinadores=_repopat.ListarPatrocinadores();
                ViewData["Error"]="el equipo ya se encuentra registrado";
                return Page();
            }
        }
    }
}
