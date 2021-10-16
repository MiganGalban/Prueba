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
    public class EquIndexModel : PageModel
    {
        //Crear un objeto para hacer uso de los repositorios
        private readonly IRepositorioEquipo _repoequipo;

        //Modelo u objeto para transportar hacia EquIndex.cshtml
        public IEnumerable<Equipo> Equipos {get; set;}//Declaramos lista de equipos
        
        //Declaramos el constructor 
        public EquIndexModel(IRepositorioEquipo repoequipo)
        {
            this._repoequipo=repoequipo;
        }


        public void OnGet()    // Entrega algo al usuario cuando se hace el llamado a la pagina
        {
            Equipos=_repoequipo.ListarEquipos();
        }
    }
}
