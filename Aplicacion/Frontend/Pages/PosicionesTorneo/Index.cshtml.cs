using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dominio;
using Persistencia;

namespace Frontend.Pages.CPosicionesTorneo
{
    public class IndexModel : PageModel
    {
        private readonly IRTorneoEquipo _repotorequ;
        private readonly IRTorneo _repotor;
        private readonly IREquipo _repoequ;

        public IndexModel(IRTorneoEquipo repotorequ, IRTorneo repotor, IREquipo repoequ)
        {
            this._repoequ= repoequ;
            this._repotor= repotor;
            this._repotorequ= repotorequ;
        }

        [BindProperty]
        public IEnumerable<TorneoEquipo> TorneoEquipos{get;set;}
        public List<TorneoEquipoView>TorneoEquiposV= new List<TorneoEquipoView>();
        public void OnGet()
        {
            Console.Write("---- INDEX ----");
            List<Torneo> lstTorneos=_repotor.ListarTorneos1();
            List<Equipo> lstEquipos=_repoequ.ListarEquipos1();
            // el torneo id que irá como parámetro será el que se seleccione en la lista desplegable
            TorneoEquipos=_repotorequ.ListarTorneoEquipos(1);

            TorneoEquipoView tev=null;
            foreach(var te in TorneoEquipos)
            {
                tev= new TorneoEquipoView();
                foreach(var t in lstTorneos)
                {
                    if(te.TorneoId==t.Id)
                    {
                        tev.Torneo=t.Nombre;
                        tev.TorneoId=t.Id;
                    }
                }

                foreach(var e in lstEquipos)
                {
                    if(te.EquipoId==e.Id)
                    {
                        tev.Equipo=e.Nombre;
                        tev.EquipoId=e.Id;
                    }
                }
                tev.Posicion=te.Posicion;
                TorneoEquiposV.Add(tev);
            }

        }
    }
}
