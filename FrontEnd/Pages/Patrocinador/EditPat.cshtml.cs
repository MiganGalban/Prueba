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
    public class EditPatModel : PageModel
    {
        private readonly IRepositorioPatrocinador _repopatrocinador;
        public EditPatModel(IRepositorioPatrocinador repopatrocinador)
        {
            this._repopatrocinador=repopatrocinador;
        }
        [BindProperty]
        public Patrocinador Patrocinador{get;set;}

        public ActionResult OnGet(int id)
        {            
            Patrocinador= _repopatrocinador.BuscarPatrocinador(id);
            return Page();
        }

         public ActionResult OnPost()
         {
                       
            bool funciono=_repopatrocinador.ActualizarPatrocinador(Patrocinador);
            if(funciono)
            {
                return RedirectToPage("./PatIndex");
            }
            else
            {
                ViewData["Mensaje"]="se ha presentado un error...";
                return Page();
            }             
            
         }
    }
}
