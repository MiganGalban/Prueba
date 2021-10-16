//Importacion de librerias y referencias
using System;
using System.Collections.Generic;

namespace Dominio
{
    public class Arbitro
    {
        public int Id {get; set;}
        public string Documento  {get; set;}
        public string Nombres  {get; set;}
        public string Apellidos  {get; set;}
        public string Genero  {get; set;}
        public string DisciplinaDep  {get; set;}
        public string NumTelf  {get; set;}
        public string Correo  {get; set;}
        


        //Llave foranea de Torneo y Escuela
        public int TorneoId {get; set;}
        public int EscuelaArbitroId {get; set;}

    }
}