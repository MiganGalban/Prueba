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
    public class CreateCanModel : PageModel
    {
        //Objeto para utilizar el repositorio
        private readonly IRepositorioCancha _repocancha;
        //Objeto para transportar al cshtml
        //Etiquetar como propiedad ppl
        [BindProperty]
        public Cancha Cancha{get; set;}
        //Constructor
        public CreateCanModel (IRepositorioCancha repocancha)
        {
            this._repocancha=repocancha;
        }

        //Se debe retornar algo ActionResult OnGet
        public ActionResult OnGet()
        {
            return Page();
        }

        public ActionResult OnPost()
        {
            bool creado=_repocancha.CrearCancha(Cancha);
            if (creado)
            {
                return RedirectToPage("./CanIndex");
            }
            else
            {
                ViewData["Mensaje"]="El cancha ya se encuentra registrado";
                return Page();
            }
        }
    }
}
