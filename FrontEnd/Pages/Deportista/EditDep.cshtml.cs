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
    public class EditDepModel : PageModel
    {
        private readonly IRepositorioDeportista _repodeportista;
        public EditDepModel(IRepositorioDeportista repodeportista)
        {
            this._repodeportista=repodeportista;
        }
        [BindProperty]
        public Deportista Deportista{get;set;}

        public ActionResult OnGet(int id)
        {            
            Deportista= _repodeportista.BuscarDeportista(id);
            return Page();
        }

         public ActionResult OnPost()
         {
                       
            bool funciono=_repodeportista.ActualizarDeportista(Deportista);
            if(funciono)
            {
                return RedirectToPage("./DepIndex");
            }
            else
            {
                ViewData["Mensaje"]="se ha presentado un error...";
                return Page();
            }             
            
         }
    }
}
