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
    public class EscIndexModel : PageModel
    {
        //Crear un objeto para hacer uso de los repositorios
        private readonly IRepositorioEscenario _repoescenario;
        //Modelo u objeto para transportar hacia EscIndex.cshtml
        public IEnumerable<Escenario> Escenarios {get; set;}//Declaramos lista de escenarios
        //Declaramos el constructor 
        public EscIndexModel(IRepositorioEscenario repoescenario)
        {
            this._repoescenario=repoescenario;
        }


        public void OnGet()    // Entrega algo al usuario cuando se hace el llamado a la pagina
        {
            Escenarios=_repoescenario.ListarEscenarios();
        }
    }
}
