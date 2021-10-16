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
    public class DeletePatModel : PageModel
    {
        private readonly IRepositorioPatrocinador _repopatrocinador;
        public DeletePatModel(IRepositorioPatrocinador repopatrocinador)
        {
            this._repopatrocinador=repopatrocinador;
        }
        [BindProperty]
        public Patrocinador Patrocinador{get;set;}

        public ActionResult OnGet(int id)
        {
            ViewData["Mensaje"]="Esta seguro de eliminar el registro?";
            Patrocinador= _repopatrocinador.BuscarPatrocinador(id);
            return Page();
        }

         public ActionResult OnPost()
         {
             bool funciono=_repopatrocinador.EliminarPatrocinador(Patrocinador.Id);
             if(funciono)
             {
                return RedirectToPage("./PatIndex");
             }
             else
             {
                 return Page();
             }
             
         }
    }
}
