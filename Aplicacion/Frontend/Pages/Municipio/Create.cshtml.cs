using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dominio;
using Persistencia;

namespace Frontend.Pages
{
    public class CreateModel : PageModel
    {
        //Objeto de solo lectura para utilizar el rpositorio
        private readonly IRepositorioMunicipio _repomunicipio;
        //Objeto para realizar la comunicaciòn con el create.cshtml.cs
        [BindProperty]
        public Municipio Municipio{get;set;}
        

        // Constructor
        public CreateModel(IRepositorioMunicipio repomunicipio)
        {
            this._repomunicipio=repomunicipio;
        }
        public ActionResult OnGet()
        {            
            return Page();
        }

        public ActionResult OnPost()
        {
            bool creado=_repomunicipio.CrearMunicipio(Municipio);
            if(creado)
            {
                return RedirectToPage("./MIndex");
            }
            else
            {
                ViewData["Mensaje"]="El municipio ya se encuentra registrado";
                return Page();
            }
            
        }
    }
}