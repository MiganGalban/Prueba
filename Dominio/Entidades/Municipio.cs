//Importacion de librerias y referencias
using System;
using System.Collections.Generic;

namespace Dominio
{
    public class Municipio
    {
        public int Id {get; set;}
        public string Nombre  {get; set;}
        //Propiedad navigacional con Torneo
        public List<Torneo> Torneos  {get; set;}
    }
}
