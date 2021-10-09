using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dominio;
using Persistencia;

namespace Frontend.Pages.CDeportista
{
    public class DetailsModel : PageModel
    {
        private IRDeportista _repodep;
        private IREquipo _repoequ;
        public DetailsModel(IRDeportista repodep, IREquipo repoequ)
        {
            this._repodep = repodep;
            this._repoequ= repoequ;
        }
        [BindProperty]
        public Deportista Deportista{get;set;}
        public Equipo Equipo{get;set;}

        public ActionResult OnGet(int id)
        {
            Deportista= _repodep.BuscarDeportista(id);
            Equipo= _repoequ.BuscarEquipo(Deportista.EquipoId);
            if(Deportista!=null)
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
