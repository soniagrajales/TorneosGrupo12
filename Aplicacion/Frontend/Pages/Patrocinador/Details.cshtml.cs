using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dominio;
using Persistencia;

namespace Frontend.Pages.CPatrocinador
{
    public class DetailsModel : PageModel
    {
       private IRPatrocinador _repopat;
        public DetailsModel(IRPatrocinador repopat)
        {
            this._repopat= repopat;
        }
        [BindProperty]
        public Patrocinador Patrocinador{get;set;}

        public ActionResult OnGet(int id)
        {
            Patrocinador= _repopat.BuscarPatrocinador(id);
            if(Patrocinador!=null)
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
