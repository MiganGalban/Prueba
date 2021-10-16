using System.Collections.Generic;
using Dominio;
using System.Linq;

namespace Persistencia
{
    public class RepositorioDeportista:IRepositorioDeportista
    {
        //Atributos
        private readonly AppContext _appContext;

        //Metodos

        //Constructor
        public RepositorioDeportista(AppContext appContext)
        {
            _appContext=appContext;
        }
        //Implementar todos los metodos de la interfaz IRepositorioDeportista
        bool IRepositorioDeportista.CrearDeportista(Deportista deportista)
        {
            bool creado=false;
            try
            {
                _appContext.Deportistas.Add(deportista);
                _appContext.SaveChanges();
                creado=true;
            }
            catch (System.Exception)
            {
                return creado;
                //throw;
            }
            return creado;

        }
        bool IRepositorioDeportista.ActualizarDeportista(Deportista deportista)
        {
            bool actualizado=false;
            var dep=_appContext.Deportistas.Find(deportista.Id);
            if (dep!=null)
            {
                try
                {
                    dep.Nombres=deportista.Nombres;
                    dep.Apellidos=deportista.Apellidos;
                    dep.Genero=deportista.Genero;
                    dep.NumTelf=deportista.NumTelf;
                    dep.Direccion=deportista.Direccion;
                    dep.DisciplinaDep=deportista.DisciplinaDep;
                    dep.Documento=deportista.Documento;
                    dep.RH=deportista.RH;
                    dep.EPS=deportista.EPS;
                    dep.FechaNac=deportista.FechaNac;
                    dep.CapacidadEsp=deportista.CapacidadEsp;
                    
                    _appContext.SaveChanges();
                    actualizado=true;
                }
                catch
                {
                    return actualizado;
                }
            }
            return actualizado;

        }
        bool IRepositorioDeportista.EliminarDeportista(int idDeportista)
        {
            bool eliminado=false;
            var deportista=_appContext.Deportistas.Find(idDeportista);
            if (deportista!=null)
            {
                try
                {
                    _appContext.Deportistas.Remove(deportista);
                    _appContext.SaveChanges();
                    eliminado=true;
                }
                catch (System.Exception)
                {
                    return eliminado;
                }

            }
            return eliminado;

        }
        Deportista IRepositorioDeportista.BuscarDeportista(int idDeportista)
        {
            Deportista deportista=_appContext.Deportistas.Find(idDeportista);
            return deportista;
        }

        IEnumerable<Deportista> IRepositorioDeportista.ListarDeportistas()
        {
            return _appContext.Deportistas; //Video 2:25:00 Sep/13
        }

        
    }    
}