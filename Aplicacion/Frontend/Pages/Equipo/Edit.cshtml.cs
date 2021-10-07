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
    public class EditModel : PageModel
    {
        private readonly IREquipo _repoeq;
        //objeto para acceder al repositorio de patrocinadores
        private readonly IRPatrocinador _repopat;

        public EditModel(IREquipo repoeq, IRPatrocinador repopat)
        {
            this._repoeq = repoeq;
            this._repopat = repopat;
        }

        [BindProperty]
        public Equipo Equipo{get;set;}
        public IEnumerable<Patrocinador> Patrocinadores{get;set;}

        public ActionResult OnGet(int id)
        {
            Equipo=_repoeq.BuscarEquipo(id);
            Patrocinadores=_repopat.ListarPatrocinadores();
            if(Equipo!=null)
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
            bool funciono=_repoeq.ActualizarEquipo(Equipo);
            if(funciono)
            {
                return RedirectToPage("./Index");
            }
            else
            {
                Patrocinadores=_repopat.ListarPatrocinadores();
                ViewData["Error"]="El torneo ya existe";
                return Page();
            }
        }
    }
}
