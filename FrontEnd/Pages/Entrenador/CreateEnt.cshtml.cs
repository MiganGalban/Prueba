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
    public class CreateEntModel : PageModel
    {
        //Objeto para utilizar el repositorio
        private readonly IRepositorioEntrenador _repoentrenador;
        //Objeto para transportar al cshtml
        //Etiquetar como propiedad ppl
        [BindProperty]
        public Entrenador Entrenador{get; set;}
        //Constructor
        public CreateEntModel (IRepositorioEntrenador repoentrenador)
        {
            this._repoentrenador=repoentrenador;
        }

        //Se debe retornar algo ActionResult OnGet
        public ActionResult OnGet()
        {
            return Page();
        }

        public ActionResult OnPost()
        {
            bool creado=_repoentrenador.CrearEntrenador(Entrenador);
            if (creado)
            {
                return RedirectToPage("./EntIndex");
            }
            else
            {
                ViewData["Mensaje"]="El entrenador ya se encuentra registrado";
                return Page();
            }
        }
    }
}
