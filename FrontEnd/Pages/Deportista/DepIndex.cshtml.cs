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
    public class DepIndexModel : PageModel
    {
        //Crear un objeto para hacer uso de los repositorios
        private readonly IRepositorioDeportista _repodeportista;

        //Modelo u objeto para transportar hacia DepIndex.cshtml
        public IEnumerable<Deportista> Deportistas {get; set;}//Declaramos lista de deportistas
        
        //Declaramos el constructor 
        public DepIndexModel(IRepositorioDeportista repodeportista)
        {
            this._repodeportista=repodeportista;
        }

        public void OnGet()    // Entrega algo al usuario cuando se hace el llamado a la pagina
        {
            Deportistas=_repodeportista.ListarDeportistas();
        }
    }
}
