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
    public class DetailsEscModel : PageModel
    {
        private readonly IRepositorioEscenario _repoescenario;
        public DetailsEscModel(IRepositorioEscenario repoescenario)
        {
            this._repoescenario=repoescenario;
        }
        [BindProperty]
        public Escenario Escenario{get;set;}

        public ActionResult OnGet(int id)
        {
            Escenario= _repoescenario.BuscarEscenario(id);
            if (Escenario==null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
