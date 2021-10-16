//Importacion de librerias y referencias
using System;
using System.Collections.Generic;

namespace Dominio
{
    public class Torneo
    {
        public int Id {get; set;}
        public string Nombre  {get; set;}
        public string Categoria  {get; set;}
        public DateTime FechaIni  {get; set;}
        public DateTime FechaFin  {get; set;}
        public string DisciplinaDep  {get; set;}
        //Propiedad navigacional con Torneo
        public List<TorneoEquipo> TorneoEquipos  {get; set;}
        //Llave foranea para la relacion con el municipio
        public int MunicipioId {get; set;}
        //Propiedad Navigacional hacia la tabla de arbitros
        public List<Arbitro> Arbitros  {get; set;}
        //Propiedad Navigacional hacia la tabla de escenario
        public List<Escenario> Escenarios  {get; set;}
        public bool CapacidadEsp {get; set;}

    }
}
