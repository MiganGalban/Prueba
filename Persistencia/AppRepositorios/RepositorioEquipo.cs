using System.Collections.Generic;
using Dominio;
using System.Linq;

namespace Persistencia
{
    public class RepositorioEquipo:IRepositorioEquipo
    {
        //Atributos
        private readonly AppContext _appContext;

        //Metodos

        //Constructor
        public RepositorioEquipo(AppContext appContext)
        {
            _appContext=appContext;
        }
        //Implementar todos los metodos de la interfaz IRepositorioEquipo
        bool IRepositorioEquipo.CrearEquipo(Equipo equipo)
        {
            bool creado=false;
            try
            {
                _appContext.Equipos.Add(equipo);
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
        bool IRepositorioEquipo.ActualizarEquipo(Equipo equipo)
        {
            bool actualizado=false;
            var equ=_appContext.Equipos.Find(equipo.Id);
            if (equ!=null)
            {
                try
                {
                    equ.Nombre=equipo.Nombre;
                    equ.CantDep=equipo.CantDep;
                    equ.DisciplinaDep=equipo.DisciplinaDep;
                    equ.CapacidadEsp=equipo.CapacidadEsp;
                    
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
        bool IRepositorioEquipo.EliminarEquipo(int idEquipo)
        {
            bool eliminado=false;
            var equipo=_appContext.Equipos.Find(idEquipo);
            if (equipo!=null)
            {
                try
                {
                    _appContext.Equipos.Remove(equipo);
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
        Equipo IRepositorioEquipo.BuscarEquipo(int idEquipo)
        {
            Equipo equipo=_appContext.Equipos.Find(idEquipo);
            return equipo;
        }

        IEnumerable<Equipo> IRepositorioEquipo.ListarEquipos()
        {
            return _appContext.Equipos; //Video 2:25:00 Sep/13
        }

        
    }    
}