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
    public class DetailsModel : PageModel
    {
        private readonly IREquipo _repoeq;
        //objeto para acceder al repositorio de patrocinadores
        private readonly IRPatrocinador _repopat;

        public DetailsModel(IREquipo repoeq, IRPatrocinador repopat)
        {
            this._repoeq = repoeq;
            this._repopat = repopat;
        }

        [BindProperty]
        public Equipo Equipo{get;set;}
        public Patrocinador Patrocinador{get;set;}

        public ActionResult OnGet(int id)
        {
            Equipo = _repoeq.BuscarEquipo(id);
            Patrocinador = _repopat.BuscarPatrocinador(Equipo.PatrocinadorId);
            if(Equipo!=null)
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
