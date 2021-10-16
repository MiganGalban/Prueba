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
    public class DeleteEscArbModel : PageModel
    {
        private readonly IRepositorioEscuelaArbitro _repoescuelaArbitro;
        public DeleteEscArbModel(IRepositorioEscuelaArbitro repoescuelaArbitro)
        {
            this._repoescuelaArbitro=repoescuelaArbitro;
        }
        [BindProperty]
        public EscuelaArbitro EscuelaArbitro{get;set;}

        public ActionResult OnGet(int id)
        {
            ViewData["Mensaje"]="Esta seguro de eliminar el registro?";
            EscuelaArbitro= _repoescuelaArbitro.BuscarEscuelaArbitro(id);
            return Page();
        }

         public ActionResult OnPost()
         {
             bool funciono=_repoescuelaArbitro.EliminarEscuelaArbitro(EscuelaArbitro.Id);
             if(funciono)
             {
                return RedirectToPage("./EscArbIndex");
             }
             else
             {
                 return Page();
             }
             
         }
    }
}
