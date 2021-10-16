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
    public class CreateEscArbModel : PageModel
    {
        //Objeto para utilizar el repositorio
        private readonly IRepositorioEscuelaArbitro _repoescuelaArbitro;
        //Objeto para transportar al cshtml
        //Etiquetar como propiedad ppl
        [BindProperty]
        public EscuelaArbitro EscuelaArbitro{get; set;}
        //Constructor
        public CreateEscArbModel (IRepositorioEscuelaArbitro repoescuelaArbitro)
        {
            this._repoescuelaArbitro=repoescuelaArbitro;
        }

        //Se debe retornar algo ActionResult OnGet
        public ActionResult OnGet()
        {
            return Page();
        }

        public ActionResult OnPost()
        {
            bool creado=_repoescuelaArbitro.CrearEscuelaArbitro(EscuelaArbitro);
            if (creado)
            {
                return RedirectToPage("./EscArbIndex");
            }
            else
            {
                ViewData["Mensaje"]="El escuelaArbitro ya se encuentra registrado";
                return Page();
            }
        }
    }
}
