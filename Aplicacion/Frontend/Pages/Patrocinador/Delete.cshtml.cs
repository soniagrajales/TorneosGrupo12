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
    public class DeleteModel : PageModel
    {
        //Objeto para hacer uso del repositorio
        private readonly IRPatrocinador _repopat;

        //Constructor por defecto
        public DeleteModel(IRPatrocinador repopat)
        {
            this._repopat=repopat;
        }

        //propiedad transportable al cshtml
        [BindProperty]
        public Patrocinador Patrocinador{get;set;}

        public ActionResult OnGet(int id)
        {
            Patrocinador=_repopat.BuscarPatrocinador(id);
            if(Patrocinador!=null)
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
            bool funciono=_repopat.EliminarPatrocinador(Patrocinador.Id);
            if(funciono)
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
