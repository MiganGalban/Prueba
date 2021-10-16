using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
//Luego de haber hecho la referenica por consola a las dos carpetas para poder enlazar Dominio y Persistencia dotnet add reference ..\Dominio\ 
using Dominio;
using Persistencia;

namespace FrontEnd.Pages
{
    public class ArbIndexModel : PageModel
    {
        //Crear un objeto para hacer uso de los repositorios
        private readonly IRepositorioArbitro _repoarbitro;
        private readonly IRepositorioEscuelaArbitro _repoescArbitro;
        private readonly IRepositorioTorneo _repotorneo;

        //Modelo u objeto para transportar hacia MunIndex.cshtml
        [BindProperty]
        public IEnumerable<Arbitro> Arbitros {get; set;}//Declaramos lista de arbitros
        public List<ArbitroView> ArbitroV = new List<ArbitroView>();

        public  EscuelaArbitro EscArb {get; set;}
        public Torneo Tor{get; set;}
        
        
        //Declaramos el constructor 
        public ArbIndexModel(IRepositorioArbitro repoarbitro,  IRepositorioEscuelaArbitro repoescArbitro, IRepositorioTorneo repotorneo) 
        {
            this._repoarbitro=repoarbitro;
            this._repoescArbitro=repoescArbitro;
            this._repotorneo=repotorneo;
        }


        public void OnGet()    // Entrega algo al usuario cuando se hace el llamado a la pagina
        {
            List<EscuelaArbitro> lstEscuelaArbitros=_repoescArbitro.ListarEscuelaArbitrosFK();
            List<Torneo> lstTorneo=_repotorneo.ListarTorneosFK();
            Arbitros=_repoarbitro.ListarArbitros();

            ArbitroView arbv=null;

            foreach (var a in Arbitros)
            {
                arbv= new ArbitroView();
                foreach (var ea in lstEscuelaArbitros)
                {
                    if (a.EscuelaArbitroId==ea.Id)
                    {
                        arbv.EscuelaArbitro=ea.Nombre;
                    }
                    
                }
                arbv.Id=a.Id;
                arbv.Documento=a.Documento;
                arbv.Nombres=a.Nombres;
                arbv.Apellidos=a.Apellidos;
                arbv.DisciplinaDep=a.DisciplinaDep;
                arbv.NumTelf=a.NumTelf;
                arbv.Correo=a.Correo;
                arbv.Genero=a.Genero;
                ArbitroV.Add(arbv);

                
                foreach (var t in lstTorneo)
                {
                    if (a.TorneoId==t.Id)
                    {
                        arbv.Torneo=t.Nombre;
                    }
                }

                arbv.Id=a.Id;
                arbv.Documento=a.Documento;
                arbv.Nombres=a.Nombres;
                arbv.Apellidos=a.Apellidos;
                arbv.DisciplinaDep=a.DisciplinaDep;
                arbv.NumTelf=a.NumTelf;
                arbv.Correo=a.Correo;
                arbv.Genero=a.Genero;
                ArbitroV.Add(arbv);

                
            }
        }
    }
}
