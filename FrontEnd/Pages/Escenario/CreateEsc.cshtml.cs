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
    public class CreateEscModel : PageModel
    {
        //Objeto para utilizar el repositorio
        private readonly IRepositorioEscenario _repoescenario;
        //Objeto para transportar al cshtml
        //Etiquetar como propiedad ppl
        [BindProperty]
        public Escenario Escenario{get; set;}
        //Constructor
        public CreateEscModel (IRepositorioEscenario repoescenario)
        {
            this._repoescenario=repoescenario;
        }

        //Se debe retornar algo ActionResult OnGet
        public ActionResult OnGet()
        {
            return Page();
        }

        public ActionResult OnPost()
        {
            bool creado=_repoescenario.CrearEscenario(Escenario);
            if (creado)
            {
                return RedirectToPage("./EscIndex");
            }
            else
            {
                ViewData["Mensaje"]="El escenario ya se encuentra registrado";
                return Page();
            }
        }
    }
}
