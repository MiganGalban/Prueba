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
    public class DeleteEquModel : PageModel
    {
        private readonly IRepositorioEquipo _repoequipo;
        public DeleteEquModel(IRepositorioEquipo repoequipo)
        {
            this._repoequipo=repoequipo;
        }
        [BindProperty]
        public Equipo Equipo{get;set;}

        public ActionResult OnGet(int id)
        {
            ViewData["Mensaje"]="Esta seguro de eliminar el registro?";
            Equipo= _repoequipo.BuscarEquipo(id);
            return Page();
        }

         public ActionResult OnPost()
         {
             bool funciono=_repoequipo.EliminarEquipo(Equipo.Id);
             if(funciono)
             {
                return RedirectToPage("./EquIndex");
             }
             else
             {
                 return Page();
             }
             
         }
    }
}
