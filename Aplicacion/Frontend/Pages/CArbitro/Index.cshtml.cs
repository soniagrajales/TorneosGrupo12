using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dominio;
using Persistencia;

namespace Frontend.Pages.CArbitro
{
    public class IndexModel : PageModel
    {
        private readonly IRArbitro _repoarb;
        private readonly IRTorneo _repotor;

        public IndexModel(IRArbitro repoarb, IRTorneo repotor)
        {
            this._repoarb=repoarb;
            this._repotor= repotor;
        }

        [BindProperty]
        public IEnumerable<Arbitro>Arbitros{get;set;}
        public List<ArbitroView> ArbitrosV= new List<ArbitroView>();
        
        public void OnGet()
        {
            List<Torneo> lstTorneos= _repotor.ListarTorneos1();
            Arbitros=_repoarb.ListarArbitros();
            ArbitroView tv=null;
            foreach (var t in Arbitros)
            {
                tv= new ArbitroView();
                foreach(var m in lstTorneos)
                {
                    if(t.TorneoId==m.Id)
                    {
                       tv.Torneo=m.Nombre; 
                    }   
                }
                tv.Id=t.Id;
                tv.Nombres=t.Nombres;
                tv.Apellidos=t.Apellidos;
                tv.Disciplina=t.Disciplina;
                ArbitrosV.Add(tv);
            }
        }
    }
}
