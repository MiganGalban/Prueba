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
    public class EditArbModel : PageModel
    {
        private readonly IRepositorioArbitro _repoarbitro;
        public EditArbModel(IRepositorioArbitro repoarbitro)
        {
            this._repoarbitro=repoarbitro;
        }
        [BindProperty]
        public Arbitro Arbitro{get;set;}

        public ActionResult OnGet(int id)
        {            
            Arbitro= _repoarbitro.BuscarArbitro(id);
            return Page();
        }

         public ActionResult OnPost()
         {
                       
            bool funciono=_repoarbitro.ActualizarArbitro(Arbitro);
            if(funciono)
            {
                return RedirectToPage("./ArbIndex");
            }
            else
            {
                ViewData["Mensaje"]="se ha presentado un error...";
                return Page();
            }             
            
         }
    }
}
