using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dominio;
using Persistencia;

namespace Frontend.Pages.CColegioArbitro
{
    public class DetailsModel : PageModel
    {
        //objeto para utilizar el repositorio
        private readonly IRColegioArbitro _repocol;
        //Constructor
        public DetailsModel(IRColegioArbitro repocol)
        {
            this._repocol=repocol;
        }

        //propiedad transportable
        [BindProperty]
        public ColegioArbitro ColegioArbitro{get;set;}

        public ActionResult OnGet(int id)
        {
            ColegioArbitro=_repocol.BuscarColegioArbitro(id);
            if(ColegioArbitro!=null)
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
