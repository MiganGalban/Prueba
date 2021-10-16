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
    public class DetailsArbModel : PageModel
    {
        private readonly IRepositorioArbitro _repoarbitro;
        public DetailsArbModel(IRepositorioArbitro repoarbitro)
        {
            this._repoarbitro=repoarbitro;
        }
        [BindProperty]
        public Arbitro Arbitro{get;set;}

        public ActionResult OnGet(int id)
        {
            Arbitro= _repoarbitro.BuscarArbitro(id);
            if (Arbitro==null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
