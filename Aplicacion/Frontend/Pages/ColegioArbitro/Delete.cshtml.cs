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
    public class DeleteModel : PageModel
    {
        //Objeto para hacer uso del repositorio
        private readonly IRColegioArbitro _repocol;

        //Constructor por defecto
        public DeleteModel(IRColegioArbitro repocol)
        {
            this._repocol=repocol;
        }

        //propiedad transportable al cshtml
        [BindProperty]
        public ColegioArbitro ColegioArbitro{get;set;}

        public ActionResult OnGet(int id)
        {
            ColegioArbitro=_repocol.BuscarColegioArbitro(id);
            if(ColegioArbitro!=null)
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
            bool funci=_repocol.EliminarColegioArbitro(ColegioArbitro.Id);
            if(funci)
            {
                return RedirectToPage("./Index");
            }
            else
            {
                return Page();
            }
           
        }
    }
}