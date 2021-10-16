using System.Collections.Generic;
using Dominio;
using System.Linq;

namespace Persistencia
{
    public class RepositorioEscenario:IRepositorioEscenario
    {
        //Atributos
        private readonly AppContext _appContext;

        //Metodos

        //Constructor
        public RepositorioEscenario(AppContext appContext)
        {
            _appContext=appContext;
        }
        //Implementar todos los metodos de la interfaz IRepositorioEscenario
        bool IRepositorioEscenario.CrearEscenario(Escenario escenario)
        {
            bool creado=false;
            try
            {
                _appContext.Escenarios.Add(escenario);
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
        bool IRepositorioEscenario.ActualizarEscenario(Escenario escenario)
        {
            bool actualizado=false;
            var esc=_appContext.Escenarios.Find(escenario.Id);
            if (esc!=null)
            {
                try
                {
                    esc.Nombre=escenario.Nombre;
                    esc.Direccion=escenario.Direccion;
                    esc.NumTelf=escenario.NumTelf;
                    esc.Horario=escenario.Horario;
                    
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
        bool IRepositorioEscenario.EliminarEscenario(int idEscenario)
        {
            bool eliminado=false;
            var escenario=_appContext.Escenarios.Find(idEscenario);
            if (escenario!=null)
            {
                try
                {
                    _appContext.Escenarios.Remove(escenario);
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
        Escenario IRepositorioEscenario.BuscarEscenario(int idEscenario)
        {
            Escenario escenario=_appContext.Escenarios.Find(idEscenario);
            return escenario;
        }

        IEnumerable<Escenario> IRepositorioEscenario.ListarEscenarios()
        {
            return _appContext.Escenarios; //Video 2:25:00 Sep/13
        }

        
    }    
}