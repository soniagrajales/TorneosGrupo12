using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dominio;
using Persistencia;

namespace Frontend.Pages.CEscenario
{
    public class DeleteModel : PageModel
    {
        private readonly IREscenario _repoesc;
        private readonly IRTorneo _repotor;
        public DeleteModel(IREscenario repoesc, IRTorneo repotor)
        {
            this._repoesc= repoesc;
            this._repotor= repotor;
        }
        [BindProperty]
        public Escenario Escenario{get;set;}
        public Torneo Torneo{get;set;}

        public ActionResult OnGet(int id)
        {
            Escenario= _repoesc.BuscarEscenario(id);
            Torneo=_repotor.BuscarTorneo(Escenario.TorneoId);
            if (Escenario!=null)
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
                         
             bool funciono =_repoesc.EliminarEscenario(Escenario.Id);
             if(funciono)
             {
                 return RedirectToPage("./Index");
             }
             else
             {
                 ViewData["Error"]="El escenario no se pudo eliminar";
                 return Page();
             }
             
         }
    }
}
