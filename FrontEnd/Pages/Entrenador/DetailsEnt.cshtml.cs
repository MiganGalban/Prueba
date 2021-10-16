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
    public class DetailsEntModel : PageModel
    {
        private readonly IRepositorioEntrenador _repoentrenador;
        public DetailsEntModel(IRepositorioEntrenador repoentrenador)
        {
            this._repoentrenador=repoentrenador;
        }
        [BindProperty]
        public Entrenador Entrenador{get;set;}

        public ActionResult OnGet(int id)
        {
            Entrenador= _repoentrenador.BuscarEntrenador(id);
            if (Entrenador==null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
