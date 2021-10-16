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
    public class CreateTorModel : PageModel
    {
        //Objeto para utilizar el repositorio
        private readonly IRepositorioTorneo _repotorneo;
        //Objeto para transportar al cshtml
        //Etiquetar como propiedad ppl
        [BindProperty]
        public Torneo Torneo{get; set;}
        //Constructor
        public CreateTorModel (IRepositorioTorneo repotorneo)
        {
            this._repotorneo=repotorneo;
        }

        //Se debe retornar algo ActionResult OnGet
        public ActionResult OnGet()
        {
            return Page();
        }

        public ActionResult OnPost()
        {
            bool creado=_repotorneo.CrearTorneo(Torneo);
            if (creado)
            {
                return RedirectToPage("./TorIndex");
            }
            else
            {
                ViewData["Mensaje"]="El torneo ya se encuentra registrado";
                return Page();
            }
        }
    }
}
