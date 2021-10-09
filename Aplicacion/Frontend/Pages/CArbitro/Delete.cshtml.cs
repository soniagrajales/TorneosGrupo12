using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dominio;
using Persistencia;

namespace Frontend.Pages.CArbitro
{
    public class DeleteModel : PageModel
    {
        private readonly IRArbitro _repoarb;
        private readonly IRTorneo _repotor;
        private readonly IRColegioArbitro _repocol;
        public DeleteModel(IRArbitro repoarb, IRTorneo repotor, IRColegioArbitro repocol)
        {
            this._repoarb= repoarb;
            this._repotor= repotor;
            this._repocol= repocol;
        }
        [BindProperty]
        public Arbitro Arbitro{get;set;}
        public Torneo Torneo{get;set;}
        public ColegioArbitro ColegioArbitro{get;set;}

        public ActionResult OnGet(int id)
        {
            Arbitro= _repoarb.BuscarArbitro(id);
            Torneo=_repotor.BuscarTorneo(Arbitro.TorneoId);
            ColegioArbitro=_repocol.BuscarColegioArbitro(Arbitro.ColegioArbitroId);
            if (Arbitro!=null)
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
                         
             bool funciono =_repoarb.EliminarArbitro(Arbitro.Id);
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
