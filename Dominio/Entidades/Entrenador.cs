//Importacion de librerias y referencias
using System;
using System.Collections.Generic;

namespace Dominio
{
    public class Entrenador
    {
        public int Id {get; set;}
        public string Documento  {get; set;}
        public string Nombres  {get; set;}
        public string Apellidos  {get; set;}
        public string Genero  {get; set;}
        public string DisciplinaDep  {get; set;}
        public string NumTelf  {get; set;}

        //Llave foranea de Equipo
        public int EquipoId {get; set;}

    }
}