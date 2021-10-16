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
    public class EditEscArbModel : PageModel
    {
        private readonly IRepositorioEscuelaArbitro _repoescuelaArbitro;
        public EditEscArbModel(IRepositorioEscuelaArbitro repoescuelaArbitro)
        {
            this._repoescuelaArbitro=repoescuelaArbitro;
        }
        [BindProperty]
        public EscuelaArbitro EscuelaArbitro{get;set;}

        public ActionResult OnGet(int id)
        {            
            EscuelaArbitro= _repoescuelaArbitro.BuscarEscuelaArbitro(id);
            return Page();
        }

         public ActionResult OnPost()
         {
                       
            bool funciono=_repoescuelaArbitro.ActualizarEscuelaArbitro(EscuelaArbitro);
            if(funciono)
            {
                return RedirectToPage("./EscArbIndex");
            }
            else
            {
                ViewData["Mensaje"]="se ha presentado un error...";
                return Page();
            }             
            
         }
    }
}
