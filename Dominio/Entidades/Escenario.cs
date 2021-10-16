//Importacion de librerias y referencias
using System;
using System.Collections.Generic;

namespace Dominio
{
    public class Escenario
    {
        public int Id {get; set;}
        public string Nombre  {get; set;}
        public string Direccion  {get; set;}
        public string NumTelf  {get; set;}
        public string Horario  {get; set;}
        


        //Llave foranea de Torneo
        public int TorneoId {get; set;}
        
        //Propiedad navigacional con Cancha
        public List<Cancha> Canchas {get; set;}

    }
}