using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dominio;
using Persistencia;

namespace Frontend.Pages.CTorneo
{
    public class DetailsModel : PageModel
    {
        //Objeto para hacer uso del repositorio
        private readonly IRTorneo _repotor;
        private readonly IRepositorioMunicipio _repomun;

        //Constructor por defecto
         public DetailsModel(IRTorneo repotor, IRepositorioMunicipio repomun)
        {
            this._repotor = repotor;
            this._repomun = repomun;
        }
        [BindProperty]
        public Torneo Torneo{get;set;}
        public Municipio Municipio{get;set;}

        public ActionResult OnGet(int id)
        {
            Torneo = _repotor.BuscarTorneo(id);
            Municipio = _repomun.BuscarMunicipio(Torneo.MunicipioId);
            if(Torneo!=null)
            {
                return Page();
            }
            else
            {
                return RedirectToPage("./Index");
            }
        }
    }
}
