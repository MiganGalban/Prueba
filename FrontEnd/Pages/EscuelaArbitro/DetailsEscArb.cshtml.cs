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
    public class DetailsEscArbModel : PageModel
    {
        private readonly IRepositorioEscuelaArbitro _repoescuelaArbitro;
        public DetailsEscArbModel(IRepositorioEscuelaArbitro repoescuelaArbitro)
        {
            this._repoescuelaArbitro=repoescuelaArbitro;
        }
        [BindProperty]
        public EscuelaArbitro EscuelaArbitro{get;set;}

        public ActionResult OnGet(int id)
        {
            EscuelaArbitro= _repoescuelaArbitro.BuscarEscuelaArbitro(id);
            if (EscuelaArbitro==null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
