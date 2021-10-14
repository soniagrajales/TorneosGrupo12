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
    public class EditModel : PageModel
    {
        //objeto para hacer del repositorio
        private readonly IRPatrocinador _repopat;
        //Constructor
        public EditModel(IRPatrocinador repopat)
        {
            this._repopat=repopat;
        }
        //propiedad transportable
        [BindProperty]
        public Patrocinador Patrocinador{get;set;}
        public ActionResult OnGet(int id)
        {
            Patrocinador=_repopat.BuscarPatrocinador(id);
            if(Patrocinador!=null)
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
            // validar los datos que llegan del formulario
            if(!ModelState.IsValid)
             {
                 return Page();
             }
            bool funciono=_repopat.ActualizarPatrocinador(Patrocinador);
            if(funciono)
            {
                return RedirectToPage("./Index");
            }
            else
            {
                ViewData["Error"]="El patrocinador ya existe";
                return Page();
            }
        }

    }
}
