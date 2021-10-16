//Importacion de librerias y referencias
using System;
using System.Collections.Generic;

namespace Dominio
{
    public class EscuelaArbitro
    {
        public int Id {get; set;}
        public string NIT  {get; set;}
        public string Nombre  {get; set;}
        public string Resolucion  {get; set;}
        public string Direccion  {get; set;}
        public string NumTelf  {get; set;}
        public string Correo  {get; set;}
        


        //Propiedad navigacional con Arbitro
        public List<Arbitro> Arbitros {get; set;}

    }
}