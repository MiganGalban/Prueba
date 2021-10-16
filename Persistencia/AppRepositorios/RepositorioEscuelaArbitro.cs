using System.Collections.Generic;
using Dominio;
using System.Linq;

namespace Persistencia
{
    public class RepositorioEscuelaArbitro:IRepositorioEscuelaArbitro
    {
        //Atributos
        private readonly AppContext _appContext;

        //Metodos

        //Constructor
        public RepositorioEscuelaArbitro(AppContext appContext)
        {
            _appContext=appContext;
        }
        //Implementar todos los metodos de la interfaz IRepositorioEscuelaArbitro
        bool IRepositorioEscuelaArbitro.CrearEscuelaArbitro(EscuelaArbitro escuelaArbitro)
        {
            bool creado=false;
            try
            {
                _appContext.EscuelaArbitros.Add(escuelaArbitro);
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
        bool IRepositorioEscuelaArbitro.ActualizarEscuelaArbitro(EscuelaArbitro escuelaArbitro)
        {
            bool actualizado=false;
            var escArb=_appContext.EscuelaArbitros.Find(escuelaArbitro.Id);
            if (escArb!=null)
            {
                try
                {
                    escArb.Nombre=escuelaArbitro.Nombre;
                    escArb.NIT=escuelaArbitro.NIT;
                    escArb.Resolucion=escuelaArbitro.Resolucion;
                    escArb.Direccion=escuelaArbitro.Direccion;
                    escArb.NumTelf=escuelaArbitro.NumTelf;
                    escArb.Correo=escuelaArbitro.Correo;
                    
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
        bool IRepositorioEscuelaArbitro.EliminarEscuelaArbitro(int idEscuelaArbitro)
        {
            bool eliminado=false;
            var escuelaArbitro=_appContext.EscuelaArbitros.Find(idEscuelaArbitro);
            if (escuelaArbitro!=null)
            {
                try
                {
                    _appContext.EscuelaArbitros.Remove(escuelaArbitro);
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
        EscuelaArbitro IRepositorioEscuelaArbitro.BuscarEscuelaArbitro(int idEscuelaArbitro)
        {
            EscuelaArbitro escuelaArbitro=_appContext.EscuelaArbitros.Find(idEscuelaArbitro);
            return escuelaArbitro;
        }

        IEnumerable<EscuelaArbitro> IRepositorioEscuelaArbitro.ListarEscuelaArbitros()
        {
            return _appContext.EscuelaArbitros; //Video 2:25:00 Sep/13
        }
        //******************************************
        List <EscuelaArbitro> IRepositorioEscuelaArbitro.ListarEscuelaArbitrosFK()
        {
            return _appContext.EscuelaArbitros.ToList(); //Video 2:25:00 Sep/13
        }
        //******************************************

        
    }    
}