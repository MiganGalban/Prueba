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
    public class DeleteEscModel : PageModel
    {
        private readonly IRepositorioEscenario _repoescenario;
        public DeleteEscModel(IRepositorioEscenario repoescenario)
        {
            this._repoescenario=repoescenario;
        }
        [BindProperty]
        public Escenario Escenario{get;set;}

        public ActionResult OnGet(int id)
        {
            ViewData["Mensaje"]="Esta seguro de eliminar el registro?";
            Escenario= _repoescenario.BuscarEscenario(id);
            return Page();
        }

         public ActionResult OnPost()
         {
             bool funciono=_repoescenario.EliminarEscenario(Escenario.Id);
             if(funciono)
             {
                return RedirectToPage("./EscIndex");
             }
             else
             {
                 return Page();
             }
             
         }
    }
}
