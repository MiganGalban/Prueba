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
    public class DetailsPatModel : PageModel
    {
        private readonly IRepositorioPatrocinador _repopatrocinador;
        public DetailsPatModel(IRepositorioPatrocinador repopatrocinador)
        {
            this._repopatrocinador=repopatrocinador;
        }
        [BindProperty]
        public Patrocinador Patrocinador{get;set;}

        public ActionResult OnGet(int id)
        {
            Patrocinador= _repopatrocinador.BuscarPatrocinador(id);
            if (Patrocinador==null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
