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
    public class CreateModel : PageModel
    {
        private readonly IRDeportista _repodep;
        //objeto para acceder al repositorio de equipos
        private readonly IREquipo _repoequ;

        public CreateModel(IRDeportista repodep, IREquipo repoequ)
        {
            this._repodep=repodep;
            this._repoequ= repoequ;
        }

        [BindProperty]
        public Deportista Deportista{get;set;}
        public IEnumerable<Equipo> Equipos{get;set;}
        
        public ActionResult OnGet()
        {
            Equipos=_repoequ.ListarEquipos();
            return Page();
        }

        public ActionResult OnPost()
        {
            // validar los datos que llegan del formulario
            if(!ModelState.IsValid)
             {
                 return Page();
             }

            bool funciono=_repodep.CrearDeportista(Deportista);
            if(funciono)
            {
                return RedirectToPage("./Index");
            }
            else
            {
                Equipos=_repoequ.ListarEquipos();
                ViewData["Error"]="El deportista ya se encuentra registrado";
                return Page();
            }
        }
    }
}
