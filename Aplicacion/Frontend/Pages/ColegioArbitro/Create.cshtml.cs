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
    public class CreateModel : PageModel
    {
        //Objeto de solo lectura para utilizar el rpositorio
        private readonly IRColegioArbitro _repocol;
        //Objeto para realizar la comunicaciòn con el create.cshtml.cs
        [BindProperty]
        public ColegioArbitro ColegioArbitro{get;set;}

        // Constructor
        public CreateModel(IRColegioArbitro repocol)
        {
            this._repocol=repocol;
        }
        public ActionResult OnGet()
        {            
            return Page();
        }

        public ActionResult OnPost()
        {
            // validar los datos que llegan del formulario
            if(!ModelState.IsValid)
             {
                 return Page();
             }

            bool creado=_repocol.CrearColegioArbitro(ColegioArbitro);
            if(creado)
            {
                return RedirectToPage("./Index");
            }
            else
            {
                ViewData["Mensaje"]="El colegio de árbitros ya se encuentra registrado";
                return Page();
            }
            
        }
    }
}
