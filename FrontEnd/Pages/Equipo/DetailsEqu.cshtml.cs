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
    public class DetailsEquModel : PageModel
    {
        private readonly IRepositorioEquipo _repoequipo;
        public DetailsEquModel(IRepositorioEquipo repoequipo)
        {
            this._repoequipo=repoequipo;
        }
        [BindProperty]
        public Equipo Equipo{get;set;}

        public ActionResult OnGet(int id)
        {
            Equipo= _repoequipo.BuscarEquipo(id);
            if (Equipo==null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
