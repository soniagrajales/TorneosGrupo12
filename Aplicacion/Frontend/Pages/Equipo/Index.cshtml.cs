using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dominio;
using Persistencia;

namespace Frontend.Pages.CEquipo
{
    public class IndexModel : PageModel
    {
        private readonly IREquipo _repoeq;
        //objeto para acceder al repositorio de patrocinadores
        private readonly IRPatrocinador _repopat;

        public IndexModel(IREquipo repoeq, IRPatrocinador repopat)
        {
            this._repoeq = repoeq;
            this._repopat = repopat;
        }

        [BindProperty]
        public IEnumerable<Equipo> Equipos{get;set;}
        public List<EquipoView> EquiposV = new List<EquipoView>();

        public void OnGet()
        {
            List<Patrocinador> lstPatrocinadores= _repopat.ListarPatrocinadores1();
            Equipos=_repoeq.ListarEquipos();
            EquipoView eqv=null;
            foreach (var e in Equipos)
            {
                eqv= new EquipoView();
                foreach(var p in lstPatrocinadores)
                {
                    if(e.PatrocinadorId==p.Id)
                    {
                       eqv.Patrocinador=p.Nombre; 
                    }   
                }
                eqv.Id=e.Id;
                eqv.Nombre=e.Nombre;
                eqv.Disciplina=e.Disciplina;
                EquiposV.Add(eqv);
            }
        }
    }
}
