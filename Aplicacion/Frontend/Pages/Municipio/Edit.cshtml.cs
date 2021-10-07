using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dominio;
using Persistencia;

namespace Frontend.Pages
{
    public class EditModel : PageModel
    {
                //objeto para hacer del repositorio
        private readonly IRepositorioMunicipio _repomunicipio;
        //Constructor
        public EditModel(IRepositorioMunicipio repomunicipio)
        {
            this._repomunicipio=repomunicipio;
        }
        //propiedad transportable
        [BindProperty]
        public Municipio Municipio{get;set;}
        public ActionResult OnGet(int id)
        {
            Municipio=_repomunicipio.BuscarMunicipio(id);
            if(Municipio!=null)
            {
                return Page();
            }
            else
            {
                return RedirectToPage("./MIndex");
            }
        }
        public ActionResult OnPost()
        {
            bool funciono=_repomunicipio.ActualizarMunicipio(Municipio);
            if(funciono)
            {
                return RedirectToPage("./MIndex");
            }
            else
            {
                ViewData["Error"]="El municipio ya existe";
                return Page();
            }
        }


    }
}
