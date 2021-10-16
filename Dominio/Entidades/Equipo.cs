//Importacion de librerias y referencias
using System;
using System.Collections.Generic;

namespace Dominio
{
    public class Equipo
    {
        public int Id {get; set;}
        public string Nombre  {get; set;}
        public int CantDep  {get; set;}
        public string DisciplinaDep  {get; set;}
        
        //Propiedad navigacional hacia la tabla del enetrenador
        public Entrenador Entrenador {get;set;}

        //Llave foranea de Patrocinador
        public int PatrocinadorId {get; set;}

        //Propiedad navigacional hacia la tabla intermedia TorneoEquipo
        public List<TorneoEquipo> TorneoEquipos  {get; set;}

        //Propiedad Navigacional hacia la tabla de Deportistas
        public List<Deportista> Deportistas  {get; set;}
        public bool CapacidadEsp {get; set;}
       

    }
}