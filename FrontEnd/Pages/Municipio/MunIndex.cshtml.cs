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
    public class MunIndexModel : PageModel
    {
        //Crear un objeto para hacer uso de los repositorios
        private readonly IRepositorioMunicipio _repomunicipio;

        //Modelo u objeto para transportar hacia MunIndex.cshtml
        public IEnumerable<Municipio> Municipios {get; set;}//Declaramos lista de municipios y se va a almacenar en la misma cuando se dispare el metodo OnGet
        
        //Declaramos el constructor 
        public MunIndexModel(IRepositorioMunicipio repomunicipio)
        {
            this._repomunicipio=repomunicipio; //Tomamos los datos que llegan dentro de la varible local q declaramos para nuestra archivo que es _repo
        }


        public void OnGet()    // Entrega algo al usuario cuando se hace el llamado a la pagina, cuando cargamos la pagina Index de Municipio esto es lo que cargaria
        {
            Municipios=_repomunicipio.ListarMunicipios();
        }
    }
}
