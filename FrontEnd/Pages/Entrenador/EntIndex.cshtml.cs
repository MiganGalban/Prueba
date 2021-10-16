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
    public class EntIndexModel : PageModel
    {
        //Crear un objeto para hacer uso de los repositorios
        private readonly IRepositorioEntrenador _repoentrenador;
        //Modelo u objeto para transportar hacia EntIndex.cshtml
        public IEnumerable<Entrenador> Entrenadores {get; set;}//Declaramos lista de entrenadors
        //Declaramos el constructor 
        public EntIndexModel(IRepositorioEntrenador repoentrenador)
        {
            this._repoentrenador=repoentrenador;
        }

        public void OnGet()    // Entrega algo al usuario cuando se hace el llamado a la pagina
        {
            Entrenadores=_repoentrenador.ListarEntrenadores();
        }
    }
}
