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
    public class EscArbIndexModel : PageModel
    {
        //Crear un objeto para hacer uso de los repositorios
        private readonly IRepositorioEscuelaArbitro _repoescuelaArbitro;

        //Modelo u objeto para transportar hacia EscArbIndex.cshtml
        public IEnumerable<EscuelaArbitro> EscuelaArbitros {get; set;}//Declaramos lista de escuelaArbitros
        
        //Declaramos el constructor 
        public EscArbIndexModel(IRepositorioEscuelaArbitro repoescuelaArbitro)
        {
            this._repoescuelaArbitro=repoescuelaArbitro;
        }


        public void OnGet()    // Entrega algo al usuario cuando se hace el llamado a la pagina
        {
            EscuelaArbitros=_repoescuelaArbitro.ListarEscuelaArbitros();
        }
    }
}
