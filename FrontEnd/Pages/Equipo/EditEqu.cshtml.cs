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
    public class EditEquModel : PageModel
    {
        private readonly IRepositorioEquipo _repoequipo;
        public EditEquModel(IRepositorioEquipo repoequipo)
        {
            this._repoequipo=repoequipo;
        }
        [BindProperty]
        public Equipo Equipo{get;set;}

        public ActionResult OnGet(int id)
        {            
            Equipo= _repoequipo.BuscarEquipo(id);
            return Page();
        }

         public ActionResult OnPost()
         {
                       
            bool funciono=_repoequipo.ActualizarEquipo(Equipo);
            if(funciono)
            {
                return RedirectToPage("./EquIndex");
            }
            else
            {
                ViewData["Mensaje"]="se ha presentado un error...";
                return Page();
            }             
            
         }
    }
}
