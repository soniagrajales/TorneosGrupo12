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
    public class CreateModel : PageModel
    {
        private readonly IRTorneo _repotor;
        //objeto para acceder al repositorio de municipios
        private readonly IRepositorioMunicipio _repomun;

        public CreateModel(IRTorneo repotor, IRepositorioMunicipio repomun)
        {
            this._repotor=repotor;
            this._repomun= repomun;
        }

        [BindProperty]
        public Torneo Torneo{get;set;}
        public IEnumerable<Municipio> Municipios{get;set;}
        
        public ActionResult OnGet()
        {
            Municipios=_repomun.ListarMunicipios();
            return Page();
        }

        public ActionResult OnPost()
        {
            // validar los datos que llegan del formulario
            if(!ModelState.IsValid)
             {
                 return Page();
             }
            bool funciono=_repotor.CrearTorneo(Torneo);
            if(funciono)
            {
                return RedirectToPage("./Index");
            }
            else
            {
                Municipios=_repomun.ListarMunicipios();
                ViewData["Error"]="el torneo ya se encuentra registrado";
                return Page();
            }
        }
    }
}
