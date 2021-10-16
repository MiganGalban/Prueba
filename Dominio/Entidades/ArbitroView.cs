//Importacion de librerias y referencias
using System;
using System.Collections.Generic;

namespace Dominio
{
    public class ArbitroView
    {
        public int Id {get; set;}
        public string Documento  {get; set;}
        public string Nombres  {get; set;}
        public string Apellidos  {get; set;}
        public string Genero  {get; set;}
        public string DisciplinaDep  {get; set;}
        public string NumTelf  {get; set;}
        public string Correo  {get; set;}
        
        //Esto no lleva Propiedad navigacional con ni llave foranea
        //No se incluye en AppContext de AppRepoositorio
        public string EscuelaArbitro {get; set;}
        public string Torneo {get; set;}

    }
}