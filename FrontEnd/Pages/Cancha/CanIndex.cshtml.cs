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
    public class CanIndexModel : PageModel
    {
        //Crear un objeto para hacer uso de los repositorios
        private readonly IRepositorioCancha _repocancha;

        //Modelo u objeto para transportar hacia CanIndex.cshtml
        public IEnumerable<Cancha> Canchas {get; set;}//Declaramos lista de canchas
        
        //Declaramos el constructor 
        public CanIndexModel(IRepositorioCancha repocancha)
        {
            this._repocancha=repocancha;
        }


        public void OnGet()    // Entrega algo al usuario cuando se hace el llamado a la pagina
        {
            Canchas=_repocancha.ListarCanchas();
        }
    }
}
