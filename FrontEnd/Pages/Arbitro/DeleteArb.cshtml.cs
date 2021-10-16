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
    public class DeleteArbModel : PageModel
    {
        private readonly IRepositorioArbitro _repoarbitro;
        public DeleteArbModel(IRepositorioArbitro repoarbitro)
        {
            this._repoarbitro=repoarbitro;
        }
        [BindProperty]
        public Arbitro Arbitro{get;set;}

        public ActionResult OnGet(int id)
        {
            ViewData["Mensaje"]="Esta seguro de eliminar el registro?";
            Arbitro= _repoarbitro.BuscarArbitro(id);
            return Page();
        }

         public ActionResult OnPost()
         {
             bool funciono=_repoarbitro.EliminarArbitro(Arbitro.Id);
             if(funciono)
             {
                return RedirectToPage("./ArbIndex");
             }
             else
             {
                return Page();
             }
             
         }
    }
}
