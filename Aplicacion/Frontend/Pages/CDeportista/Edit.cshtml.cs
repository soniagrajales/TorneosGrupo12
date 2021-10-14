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
    public class EditModel : PageModel
    {
        private readonly IRDeportista _repodep;
        private readonly IREquipo _repoequ;
        public EditModel(IRDeportista repodep, IREquipo repoequ)
        {
            this._repodep= repodep;
            this._repoequ= repoequ;
        }
        [BindProperty]
        public Deportista Deportista{get;set;}
        public IEnumerable<Equipo> Equipos{get;set;}
        public Equipo Equipo{get;set;}

        public ActionResult OnGet(int id)
        {
            Deportista=_repodep.BuscarDeportista(id);
            if(Deportista!=null)
            {
                Equipos=_repoequ.ListarEquipos();
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

            bool funciono=_repodep.ActualizarDeportista(Deportista);
            if(funciono)
            {
                return RedirectToPage("./Index");
            }
            else
            {
                ViewData["Error"]="El deportista ya existe";
                return Page();
            }
        }
    }
}
