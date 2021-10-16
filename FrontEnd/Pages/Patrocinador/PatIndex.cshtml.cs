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
    public class PatIndexModel : PageModel
    {
        //Crear un objeto para hacer uso de los repositorios
        private readonly IRepositorioPatrocinador _repopatrocinador;

        //Modelo u objeto para transportar hacia PatIndex.cshtml
        public IEnumerable<Patrocinador> Patrocinadores {get; set;}//Declaramos lista de patrocinadors
        
        //Declaramos el constructor 
        public PatIndexModel(IRepositorioPatrocinador repopatrocinador)
        {
            this._repopatrocinador=repopatrocinador;
        }


        public void OnGet()    // Entrega algo al usuario cuando se hace el llamado a la pagina
        {
            Patrocinadores=_repopatrocinador.ListarPatrocinadores();
        }
    }
}
