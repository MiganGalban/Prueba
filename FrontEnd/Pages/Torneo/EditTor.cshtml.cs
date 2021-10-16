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
    public class EditTorModel : PageModel
    {
        private readonly IRepositorioTorneo _repotorneo;
        public EditTorModel(IRepositorioTorneo repotorneo)
        {
            this._repotorneo=repotorneo;
        }
        [BindProperty]
        public Torneo Torneo{get;set;}

        public ActionResult OnGet(int id)
        {            
            Torneo= _repotorneo.BuscarTorneo(id);
            return Page();
        }

         public ActionResult OnPost()
         {
                       
            bool funciono=_repotorneo.ActualizarTorneo(Torneo);
            if(funciono)
            {
                return RedirectToPage("./TorIndex");
            }
            else
            {
                ViewData["Mensaje"]="se ha presentado un error...";
                return Page();
            }             
            
         }
    }
}
