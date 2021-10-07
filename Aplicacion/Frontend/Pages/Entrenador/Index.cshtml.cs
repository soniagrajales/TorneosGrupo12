using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dominio;
using Persistencia;

namespace Frontend.Pages.CEntrenador
{
    public class IndexModel : PageModel
    {
        private readonly IREntrenador _repoent;
        private readonly IREquipo _repoeq;

        public IndexModel(IREntrenador repoent, IREquipo repoeq)
        {
            this._repoent = repoent;
            this._repoeq = repoeq;
        }

        [BindProperty]
        public IEnumerable<Entrenador> Entrenadores{get;set;}
        public List<EntrenadorView> EntrenadoresV = new List<EntrenadorView>();

        public void OnGet()
        {
            List<Equipo> lstEquipos= _repoeq.ListarEquipos1();
            Entrenadores=_repoent.ListarEntrenadores();
            EntrenadorView entv=null;
            foreach (var e in Entrenadores)
            {
                entv= new EntrenadorView();
                foreach(var eq in lstEquipos)
                {
                    if(e.EquipoId==eq.Id)
                    {
                       entv.Equipo=eq.Nombre; 
                    }   
                }
                entv.Id=e.Id;
                entv.Documento=e.Documento;
                entv.Nombres=e.Nombres;
                entv.Apellidos=e.Apellidos;
                entv.Genero=e.Genero;
                EntrenadoresV.Add(entv);
            }
        }
    }
}
