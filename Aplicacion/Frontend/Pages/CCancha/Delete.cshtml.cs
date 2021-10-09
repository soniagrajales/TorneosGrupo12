using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dominio;
using Persistencia;

namespace Frontend.Pages.CCancha
{
    public class DeleteModel : PageModel
    {
        private readonly IRCancha _repocan;
        private readonly IREscenario _repoesc;
        public DeleteModel(IRCancha repocan, IREscenario repoesc)
        {
            this._repocan= repocan;
            this._repoesc= repoesc;
        }
        [BindProperty]
        public Cancha Cancha{get;set;}
        public Escenario Escenario{get;set;}

        public ActionResult OnGet(int id)
        {
            Cancha= _repocan.BuscarCancha(id);
            Escenario=_repoesc.BuscarEscenario(Cancha.EscenarioId);
            if (Cancha!=null)
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
                         
             bool funciono =_repocan.EliminarCancha(Cancha.Id);
             if(funciono)
             {
                 return RedirectToPage("./Index");
             }
             else
             {
                 ViewData["Error"]="La cancha no se pudo eliminar";
                 return Page();
             }
             
         }
    }
}
