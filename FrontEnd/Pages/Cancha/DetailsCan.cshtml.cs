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
    public class DetailsCanModel : PageModel
    {
        private readonly IRepositorioCancha _repocancha;
        public DetailsCanModel(IRepositorioCancha repocancha)
        {
            this._repocancha=repocancha;
        }
        [BindProperty]
        public Cancha Cancha{get;set;}

        public ActionResult OnGet(int id)
        {
            Cancha= _repocancha.BuscarCancha(id);
            if (Cancha==null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
