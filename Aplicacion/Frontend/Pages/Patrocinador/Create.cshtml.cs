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
    public class CreateModel : PageModel
    {
        //Objeto de solo lectura para utilizar el rpositorio
        private readonly IRPatrocinador _repopat;
        //Objeto para realizar la comunicaciòn con el create.cshtml.cs
        [BindProperty]
        public Patrocinador Patrocinador{get;set;}
        

        // Constructor
        public CreateModel(IRPatrocinador repopat)
        {
            this._repopat=repopat;
        }
        public ActionResult OnGet()
        {            
            return Page();
        }

        public ActionResult OnPost()
        {
            bool creado=_repopat.CrearPatrocinador(Patrocinador);
            if(creado)
            {
                return RedirectToPage("./Index");
            }
            else
            {
                ViewData["Mensaje"]="El patrocinador ya se encuentra registrado";
                return Page();
            }
            
        }
    }
}
