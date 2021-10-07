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
    public class IndexModel : PageModel
    {
        private readonly IRTorneo _repotor;
        private readonly IRepositorioMunicipio _repomun;

        public IndexModel(IRTorneo repotor, IRepositorioMunicipio repomun)
        {
            this._repotor=repotor;
            this._repomun=repomun;
        }

        [BindProperty]
        public IEnumerable<Torneo> Torneos{get;set;}
        public List<TorneoView> TorneosV = new List<TorneoView>();
        
        public void OnGet()
        {
            List<Municipio> lstMunicipios= _repomun.ListarMunicipios1();
            Torneos=_repotor.ListarTorneos();
            TorneoView tv=null;
            foreach (var t in Torneos)
            {
                tv= new TorneoView();
                foreach(var m in lstMunicipios)
                {
                    if(t.MunicipioId==m.Id)
                    {
                       tv.Municipio=m.Nombre; 
                    }   
                }
                tv.Id=t.Id;
                tv.Nombre=t.Nombre;
                tv.Categoria=t.Categoria;
                tv.FechaInicial=t.FechaInicial;
                tv.FechaFinal=t.FechaFinal;
                tv.Horario=t.Horario;
                TorneosV.Add(tv);
            }
        }
    }
}