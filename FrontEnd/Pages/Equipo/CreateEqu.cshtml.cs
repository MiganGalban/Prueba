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
    public class CreateEquModel : PageModel
    {
        //Objeto para utilizar el repositorio
        private readonly IRepositorioEquipo _repoequipo;
        //Objeto para transportar al cshtml
        //Etiquetar como propiedad ppl
        [BindProperty]
        public Equipo Equipo{get; set;}
        //Constructor
        public CreateEquModel (IRepositorioEquipo repoequipo)
        {
            this._repoequipo=repoequipo;
        }

        //Se debe retornar algo ActionResult OnGet
        public ActionResult OnGet()
        {
            return Page();
        }

        public ActionResult OnPost()
        {
            bool creado=_repoequipo.CrearEquipo(Equipo);
            if (creado)
            {
                return RedirectToPage("./EquIndex");
            }
            else
            {
                ViewData["Mensaje"]="El equipo ya se encuentra registrado";
                return Page();
            }
        }
    }
}
