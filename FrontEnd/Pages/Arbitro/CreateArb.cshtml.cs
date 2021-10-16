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
    public class CreateArbModel : PageModel
    {
        //Objeto para utilizar el repositorio
        private readonly IRepositorioArbitro _repoarbitro;
        private readonly IRepositorioEscuelaArbitro _repoescArbitro;
        private readonly IRepositorioTorneo _repotorneo;
        //Objeto para transportar al cshtml
        //Etiquetar como propiedad ppl
        [BindProperty]
        public Arbitro Arbitro{get; set;}
        public IEnumerable <EscuelaArbitro> EscuelaArbitros {get; set;}
        public IEnumerable <Torneo> Torneos {get; set;}
        //Constructor
        public CreateArbModel (IRepositorioArbitro repoarbitro, IRepositorioEscuelaArbitro repoescArbitro, IRepositorioTorneo repotorneo)
        {
            this._repoarbitro=repoarbitro;
            this._repoescArbitro=repoescArbitro;
            this._repotorneo=repotorneo;
        }

        //Se debe retornar algo ActionResult OnGet
        //En el get se hace la primera solicitud y esta retorna el formulario en blanco con la lista de las demas llaves foraneas

        public ActionResult OnGet()
        {
            EscuelaArbitros=_repoescArbitro.ListarEscuelaArbitros();
            Torneos=_repotorneo.ListarTorneos();
            return Page();
        }

        public ActionResult OnPost()
        {
            bool creado=_repoarbitro.CrearArbitro(Arbitro);
            if (creado)
            {
                return RedirectToPage("./ArbIndex");
            }
            else
            {
                EscuelaArbitros=_repoescArbitro.ListarEscuelaArbitros();
                Torneos=_repotorneo.ListarTorneos();
                ViewData["Mensaje"]="El arbitro ya se encuentra registrado";
                return Page();
            }
        }
    }
}
