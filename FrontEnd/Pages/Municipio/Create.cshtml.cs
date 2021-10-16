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
    public class CreateModel : PageModel
    {
        //Objeto para utilizar el repositorio
        private readonly IRepositorioMunicipio _repomunicipio;
        //Objeto para transportar al cshtml
        //Etiquetar como propiedad ppl
        [BindProperty]
        public Municipio Municipio{get; set;}
        //Constructor
        public CreateModel (IRepositorioMunicipio repomunicipio)
        {
            this._repomunicipio=repomunicipio;
        }

        //Se debe retornar algo ActionResult OnGet
        public ActionResult OnGet()
        {
            return Page();
        }

        public ActionResult OnPost()
        {
            bool creado=_repomunicipio.CrearMunicipio(Municipio);
            if (creado)
            {
                return RedirectToPage("./MunIndex");
            }
            else
            {
                ViewData["Mensaje"]="El municipio ya se encuentra registrado";
                return Page();
            }
        }
    }
}
