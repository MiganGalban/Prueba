using System;
using Dominio;
using Persistencia;
using System.Collections.Generic;


namespace Consola
{
    class Program
    {
        //Instabciar un objeto de tipo IRepositorio
        private static IRepositorioMunicipio _repomunicipio= new RepositorioMunicipio(new Persistencia.AppContext());
        static void Main(string[] args)
        {
            /*bool funciono= crearMunicipio();
            if(funciono)
            {
                Console.WriteLine("Municipio adicionado con exito");
            }
            else
            {
                Console.WriteLine("Se ha presentado falla en el proceso...");
            }*/

           /* bool f=eliminarMunicipio();
            
            if(f)
            {
                Console.WriteLine("Municipio eliminado con exito");
            }
            else
            {
                Console.WriteLine("Se ha presentado falla en el proceso...");
            }*/

          /*  bool f=actualizarMunicipio();
            
            if(f)
            {
                Console.WriteLine("Municipio actualizado con exito");
            }
            else
            {
                Console.WriteLine("Se ha presentado falla en el proceso...");
            }

            Console.WriteLine("Lista actualizada"); 
            listarMunicipios();
            */
            buscarMunicipio();

            
        }
    
        private static bool crearMunicipio()
        {
            var municipio=new Municipio
            {
                Nombre="Manizales"
            };
            bool funciono= _repomunicipio.CrearMunicipio(municipio);
            return funciono;

        }
        private static void listarMunicipios()
        {
            IEnumerable<Municipio> municipios=_repomunicipio.ListarMunicipios();
            foreach (var mun in municipios)
            {
                Console.WriteLine(mun.Id + " " + mun.Nombre);
            }
        }
        private static bool eliminarMunicipio()
        {
            bool funciono=_repomunicipio.EliminarMunicipio(2);
            return funciono;
        }

        private static bool actualizarMunicipio()
        {
            var municipio = new Municipio
            {
                Id=5,
                Nombre="Cali"
            };
            bool funciono = _repomunicipio.ActualizarMunicipio(municipio);
            return funciono;
        }

        private static void buscarMunicipio()
        {
            var mun= _repomunicipio.BuscarMunicipio(1);
            if (mun!=null)
            {
                Console.WriteLine(mun.Id);
                Console.WriteLine(mun.Nombre);
            }
            else
            {
                Console.WriteLine("Municipio no encontrado");
            }
        }

    }
}
