using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dominio;
using Persistencia;

namespace Frontend.Pages.CCancha
{
    public class IndexModel : PageModel
    {
        private readonly IRCancha _repocan;
        private readonly IREscenario _repoesc;

        public IndexModel(IRCancha repocan, IREscenario repoesc)
        {
            this._repocan=repocan;
            this._repoesc= repoesc;
        }

        [BindProperty]
        public IEnumerable<Cancha>Canchas{get;set;}
        public List<CanchaView> CanchasV= new List<CanchaView>();
        
        public void OnGet()
        {
            List<Escenario> lstEscenarios= _repoesc.ListarEscenarios1();
            Canchas=_repocan.ListarCanchas();
            CanchaView tv=null;
            foreach (var t in Canchas)
            {
                tv= new CanchaView();
                foreach(var m in lstEscenarios)
                {
                    if(t.EscenarioId==m.Id)
                    {
                       tv.Escenario=m.Nombre; 
                    }   
                }
                tv.Id=t.Id;
                tv.Nombre=t.Nombre;
                tv.Disciplina=t.Disciplina;
                tv.CapacidadEsp=t.CapacidadEsp;
                CanchasV.Add(tv);
            }
        }
    }
}
