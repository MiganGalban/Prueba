using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dominio;
using Persistencia;

namespace FrontEnd.Pages
{
    public class TorIndexModel : PageModel
    {
       //Crear un objeto para hacer uso de los repositorios
        private readonly IRepositorioTorneo _repotorneo;

        //Modelo u objeto para transportar hacia TorIndex.cshtml
        public IEnumerable<Torneo> Torneos {get; set;}//Declaramos lista de torneos
        
        //Declaramos el constructor 
        public TorIndexModel(IRepositorioTorneo repotorneo)
        {
            this._repotorneo=repotorneo;
        }


        public void OnGet()    // Entrega algo al usuario cuando se hace el llamado a la pagina
        {
            Torneos=_repotorneo.ListarTorneos();
        }
    }
}
