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
    public class CreateDepModel : PageModel
    {
        //Objeto para utilizar el repositorio
        private readonly IRepositorioDeportista _repodeportista;
        //Objeto para transportar al cshtml
        //Etiquetar como propiedad ppl
        [BindProperty]
        public Deportista Deportista{get; set;}
        //Constructor
        public CreateDepModel (IRepositorioDeportista repodeportista)
        {
            this._repodeportista=repodeportista;
        }

        //Se debe retornar algo ActionResult OnGet
        public ActionResult OnGet()
        {
            return Page();
        }

        public ActionResult OnPost()
        {
            bool creado=_repodeportista.CrearDeportista(Deportista);
            if (creado)
            {
                return RedirectToPage("./DepIndex");
            }
            else
            {
                ViewData["Mensaje"]="El deportista ya se encuentra registrado";
                return Page();
            }
        }
    }
}
