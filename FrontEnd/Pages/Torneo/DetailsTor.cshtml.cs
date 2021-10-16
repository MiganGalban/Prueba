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
    public class DetailsTorModel : PageModel
    {
        private readonly IRepositorioTorneo _repotorneo;
        public DetailsTorModel(IRepositorioTorneo repotorneo)
        {
            this._repotorneo=repotorneo;
        }
        [BindProperty]
        public Torneo Torneo{get;set;}

        public ActionResult OnGet(int id)
        {
            Torneo= _repotorneo.BuscarTorneo(id);
            if (Torneo==null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
