using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dominio;
using Persistencia;

namespace Frontend.Pages.CInscribirEquipo
{
    public class DeleteModel : PageModel
    {
        private readonly IRTorneoEquipo _repotorequ;
        private readonly IRTorneo _repotor;
        private readonly IREquipo _repoequ;

        public DeleteModel(IRTorneoEquipo repotorequ, IRTorneo repotor, IREquipo repoequ)
        {
            this._repoequ= repoequ;
            this._repotor= repotor;
            this._repotorequ= repotorequ;
        }

        [BindProperty]
        public Equipo Equipo{get;set;}
        public Torneo Torneo{get;set;}

        public TorneoEquipo TorneoEquipo{get; set;}

        public ActionResult OnGet(TorneoEquipo obj)
        {
            TorneoEquipo= _repotorequ.BuscarTorneoEquipo(obj);
            Torneo=_repotor.BuscarTorneo(obj.TorneoId);
            Equipo=_repoequ.BuscarEquipo(obj.EquipoId); 
           
            if (TorneoEquipo!=null)
            {
                ViewData["Mensaje"]="Esta seguro de retirar el equipo del torneo?";
                return Page();
            }
            else
            {
                return RedirectToPage("./Index");
            }            
        }

         public ActionResult OnPost()
         {
                         
             bool funciono =_repotorequ.EliminarTorneoEquipo(TorneoEquipo);
             if(funciono)
             {
                 return RedirectToPage("./Index");
             }
             else
             {
                 ViewData["Error"]="El equipo no se pudo eliminar";
                 return Page();
             }
             
         }
    }
}
