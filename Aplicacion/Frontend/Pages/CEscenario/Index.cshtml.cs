using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dominio;
using Persistencia;

namespace Frontend.Pages.CEscenario
{
    public class IndexModel : PageModel
    {
        private readonly IREscenario _repoesc;
        private readonly IRTorneo _repotor;

        public IndexModel(IREscenario repoesc, IRTorneo repotor)
        {
            this._repoesc=repoesc;
            this._repotor= repotor;
        }

        [BindProperty]
        public IEnumerable<Escenario>Escenarios{get;set;}
        public List<EscenarioView> EscenariosV= new List<EscenarioView>();
        
        public void OnGet()
        {
            List<Torneo> lstTorneos= _repotor.ListarTorneos1();
            Escenarios=_repoesc.ListarEscenarios();
            EscenarioView tv=null;
            foreach (var t in Escenarios)
            {
                tv= new EscenarioView();
                foreach(var m in lstTorneos)
                {
                    if(t.TorneoId==m.Id)
                    {
                       tv.Torneo=m.Nombre; 
                    }   
                }
                tv.Id=t.Id;
                tv.Nombre=t.Nombre;
                tv.Direccion=t.Direcion;
                tv.Telefono=t.Telefono;
                EscenariosV.Add(tv);
            }
        }
    }
}
