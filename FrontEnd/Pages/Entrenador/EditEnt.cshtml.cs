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
    public class EditEntModel : PageModel
    {
        private readonly IRepositorioEntrenador _repoentrenador;
        public EditEntModel(IRepositorioEntrenador repoentrenador)
        {
            this._repoentrenador=repoentrenador;
        }
        [BindProperty]
        public Entrenador Entrenador{get;set;}

        public ActionResult OnGet(int id)
        {            
            Entrenador= _repoentrenador.BuscarEntrenador(id);
            return Page();
        }

         public ActionResult OnPost()
         {
                       
            bool funciono=_repoentrenador.ActualizarEntrenador(Entrenador);
            if(funciono)
            {
                return RedirectToPage("./EntIndex");
            }
            else
            {
                ViewData["Mensaje"]="se ha presentado un error...";
                return Page();
            }             
            
         }
    }
}
