//Importacion de librerias y referencias
using System;
using System.Collections.Generic;

namespace Dominio
{
    public class Cancha
    {
        public int Id {get; set;}
        public string Nombre  {get; set;}
        public string DisciplinaDep  {get; set;}
        public string Estado  {get; set;}
        public int CapacidadEsp  {get; set;}
        public double Medidas {get; set;} // Cambiar tipo por string
        


        //Llave foranea de Escenario
        public int EscenarioId {get; set;}
        

    }
}