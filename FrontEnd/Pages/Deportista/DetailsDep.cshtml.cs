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
    public class DetailsDepModel : PageModel
    {
        private readonly IRepositorioDeportista _repodeportista;
        public DetailsDepModel(IRepositorioDeportista repodeportista)
        {
            this._repodeportista=repodeportista;
        }
        [BindProperty]
        public Deportista Deportista{get;set;}

        public ActionResult OnGet(int id)
        {
            Deportista= _repodeportista.BuscarDeportista(id);
            if (Deportista==null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
