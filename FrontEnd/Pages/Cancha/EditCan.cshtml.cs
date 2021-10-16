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
    public class EditCanModel : PageModel
    {
        private readonly IRepositorioCancha _repocancha;
        public EditCanModel(IRepositorioCancha repocancha)
        {
            this._repocancha=repocancha;
        }
        [BindProperty]
        public Cancha Cancha{get;set;}

        public ActionResult OnGet(int id)
        {            
            Cancha= _repocancha.BuscarCancha(id);
            return Page();
        }

         public ActionResult OnPost()
         {
                       
            bool funciono=_repocancha.ActualizarCancha(Cancha);
            if(funciono)
            {
                return RedirectToPage("./CanIndex");
            }
            else
            {
                ViewData["Mensaje"]="se ha presentado un error...";
                return Page();
            }             
            
         }
    }
}
