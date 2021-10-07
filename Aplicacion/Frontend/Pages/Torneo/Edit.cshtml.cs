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
    public class EditModel : PageModel
    {
        //objeto para hacer del repositorio
        private readonly IRTorneo _repotor;
        //objeto para acceder al repositorio de municipios
        private readonly IRepositorioMunicipio _repomun;

        //Constructor
        public EditModel(IRTorneo repotor, IRepositorioMunicipio repomun)
        {
            this._repotor=repotor;
            this._repomun= repomun;
        }

        //propiedad transportable
        [BindProperty]
        public Torneo Torneo{get;set;}
        public IEnumerable<Municipio> Municipios{get;set;}

        public ActionResult OnGet(int id)
        {
            Torneo=_repotor.BuscarTorneo(id);
            Municipios=_repomun.ListarMunicipios();
            if(Torneo!=null)
            {
                return Page();
            }
            else
            {
                return RedirectToPage("./Index");
            }
        }
        public ActionResult OnPost()
        {
            bool funciono=_repotor.ActualizarTorneo(Torneo);
            if(funciono)
            {
                return RedirectToPage("./Index");
            }
            else
            {
                ViewData["Error"]="El torneo ya existe";
                return Page();
            }
        }
    }
}