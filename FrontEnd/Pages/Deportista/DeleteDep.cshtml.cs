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
    public class DeleteDepModel : PageModel
    {
        private readonly IRepositorioDeportista _repodeportista;
        public DeleteDepModel(IRepositorioDeportista repodeportista)
        {
            this._repodeportista=repodeportista;
        }
        [BindProperty]
        public Deportista Deportista{get;set;}

        public ActionResult OnGet(int id)
        {
            ViewData["Mensaje"]="Esta seguro de eliminar el registro?";
            Deportista= _repodeportista.BuscarDeportista(id);
            return Page();
        }

         public ActionResult OnPost()
         {
             bool funciono=_repodeportista.EliminarDeportista(Deportista.Id);
             if(funciono)
             {
                return RedirectToPage("./DepIndex");
             }
             else
             {
                 return Page();
             }
             
         }
    }
}
