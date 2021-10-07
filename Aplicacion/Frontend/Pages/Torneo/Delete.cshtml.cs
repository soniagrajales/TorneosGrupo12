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
    public class DeleteModel : PageModel
    {
        //Objeto para hacer uso del repositorio
        private readonly IRTorneo _repotor;
        private readonly IRepositorioMunicipio _repomun;

        //Constructor por defecto
        public DeleteModel(IRTorneo repotor, IRepositorioMunicipio repomun)
        {
            this._repotor=repotor;
            this._repomun = repomun;
        }

        //propiedad transportable al cshtml
        [BindProperty]
        public Torneo Torneo{get;set;}
        public Municipio Municipio{get;set;}

        public ActionResult OnGet(int id)
        {
            Torneo=_repotor.BuscarTorneo(id);
            Municipio = _repomun.BuscarMunicipio(Torneo.MunicipioId);
            if(Torneo!=null)
            {
                ViewData["Confirmar"]="Esta seguro de eliminar este registro?";
                return Page();
            }
            else
            {
                return RedirectToPage("./Index");
            }
        }
        public ActionResult OnPost()
        {
            bool funciono=_repotor.EliminarTorneo(Torneo.Id);
            if(funciono)
            {
                return RedirectToPage("./Index");
            }
            else
            {
                return Page();
            }
        }
    }
}