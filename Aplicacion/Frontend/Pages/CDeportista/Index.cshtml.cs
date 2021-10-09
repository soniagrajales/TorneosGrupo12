using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dominio;
using Persistencia;

namespace Frontend.Pages.CDeportista
{
    public class IndexModel : PageModel
    {
        private readonly IRDeportista _repodep;
        private readonly IREquipo _repoequ;

        public IndexModel(IRDeportista repodep, IREquipo repoequ)
        {
            this._repodep=repodep;
            this._repoequ= repoequ;
        }

        [BindProperty]
        public IEnumerable<Deportista>Deportistas{get;set;}
        public List<DeportistaView> DeportistasV= new List<DeportistaView>();
        
        public void OnGet()
        {
            List<Equipo> lstEquipos= _repoequ.ListarEquipos1();
            Deportistas=_repodep.ListarDeportistas();
            DeportistaView tv=null;
            foreach (var t in Deportistas)
            {
                tv= new DeportistaView();
                foreach(var m in lstEquipos)
                {
                    if(t.EquipoId==m.Id)
                    {
                       tv.Equipo=m.Nombre; 
                    }   
                }
                tv.Id=t.Id;
                tv.Nombres=t.Nombres;
                tv.Apellidos=t.Apellidos;
                tv.Disciplina=t.Disciplina;
                DeportistasV.Add(tv);
            }
        }
    }
}
