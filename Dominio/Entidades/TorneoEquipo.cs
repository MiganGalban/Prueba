//Importacion de librerias y referencias
using System;
using System.Collections.Generic;

namespace Dominio
{
    public class TorneoEquipo
    {
        //Lave Ppl compuesta por dos dos campos ID
        public int TorneoId {get; set;}
        public int EquipoId {get; set;}
        
        //Propiedad navigacional a Torneo
        public List<Torneo> Torneos  {get; set;}
  
        //Propiedad Navigacional a Equipo
        public List<Equipo> Equipos  {get; set;}

    }
}
