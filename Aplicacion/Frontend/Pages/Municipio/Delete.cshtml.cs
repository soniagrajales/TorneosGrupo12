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
    public class DeleteModel : PageModel
    {
        //Objeto para hacer uso del repositorio
        private readonly IRepositorioMunicipio _repomunicipio;

        //Constructor por defecto
        public DeleteModel(IRepositorioMunicipio repomunicipio)
        {
            this._repomunicipio=repomunicipio;
        }

        //propiedad transportable al cshtml
        [BindProperty]
        public Municipio Municipio{get;set;}

        public ActionResult OnGet(int id)
        {
            Municipio=_repomunicipio.BuscarMunicipio(id);
            if(Municipio!=null)
            {
                ViewData["Confirmar"]="Esta seguro de eliminar este registro?";
                return Page();
            }
            else
            {
                return RedirectToPage("./MIndex");
            }
        }
        public ActionResult OnPost()
        {
            bool funci=_repomunicipio.EliminarMunicipio(Municipio.Id);
            if(funci)
            {
                return RedirectToPage("./MIndex");
            }
            else
            {
                ViewData["Mensaje"]="No es posible eliminar registros con entidad referencial";
                return Page();
            }
           
        }
    }
}
