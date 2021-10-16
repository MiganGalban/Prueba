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
    public class DeleteCanModel : PageModel
    {
        private readonly IRepositorioCancha _repocancha;
        public DeleteCanModel(IRepositorioCancha repocancha)
        {
            this._repocancha=repocancha;
        }
        [BindProperty]
        public Cancha Cancha{get;set;}

        public ActionResult OnGet(int id)
        {
            ViewData["Mensaje"]="Esta seguro de eliminar el registro?";
            Cancha= _repocancha.BuscarCancha(id);
            return Page();
        }

         public ActionResult OnPost()
         {
             bool funciono=_repocancha.EliminarCancha(Cancha.Id);
             if(funciono)
             {
                return RedirectToPage("./CanIndex");
             }
             else
             {
                 return Page();
             }
             
         }
    }
}
