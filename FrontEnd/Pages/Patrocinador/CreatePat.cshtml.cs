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
    public class CreatePatModel : PageModel
    {
        //Objeto para utilizar el repositorio
        private readonly IRepositorioPatrocinador _repopatrocinador;
        //Objeto para transportar al cshtml
        //Etiquetar como propiedad ppl
        [BindProperty]
        public Patrocinador Patrocinador{get; set;}
        //Constructor
        public CreatePatModel (IRepositorioPatrocinador repopatrocinador)
        {
            this._repopatrocinador=repopatrocinador;
        }

        //Se debe retornar algo ActionResult OnGet
        public ActionResult OnGet()
        {
            return Page();
        }

        public ActionResult OnPost()
        {
            bool creado=_repopatrocinador.CrearPatrocinador(Patrocinador);
            if (creado)
            {
                return RedirectToPage("./PatIndex");
            }
            else
            {
                ViewData["Mensaje"]="El patrocinador ya se encuentra registrado";
                return Page();
            }
        }
    }
}
