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
    public class DeleteModel : PageModel
    {
        private readonly IRDeportista _repodep;
        private readonly IREquipo _repoequ;
        public DeleteModel(IRDeportista repodep, IREquipo repoequ)
        {
            this._repodep= repodep;
            this._repoequ= repoequ;
        }
        [BindProperty]
        public Deportista Deportista{get;set;}
        public Equipo Equipo{get;set;}

        public ActionResult OnGet(int id)
        {
            Deportista= _repodep.BuscarDeportista(id);
            Equipo=_repoequ.BuscarEquipo(Deportista.EquipoId);
            if (Deportista!=null)
            {
                ViewData["Mensaje"]="Esta seguro de eliminar este registro";
                return Page();
            }
            else
            {
                return RedirectToPage("./Index");
            }
            
        }

         public ActionResult OnPost()
         {
                         
             bool funciono =_repodep.EliminarDeportista(Deportista.Id);
             if(funciono)
             {
                 return RedirectToPage("./Index");
             }
             else
             {
                 ViewData["Error"]="El patrocinador no se pudo eliminar";
                 return Page();
             }
             
         }
    }
}
