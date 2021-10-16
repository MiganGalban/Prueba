using System.Collections.Generic;
using Dominio;
using System.Linq;

namespace Persistencia
{
    public class RepositorioTorneo:IRepositorioTorneo
    {
        //Atributos
        private readonly AppContext _appContext;

        //Metodos

        //Constructor
        public RepositorioTorneo(AppContext appContext)
        {
            _appContext=appContext;
        }
        //Implementar todos los metodos de la interfaz IRepositorioTorneo
        bool IRepositorioTorneo.CrearTorneo(Torneo torneo)
        {
            bool creado=false;
            try
            {
                _appContext.Torneos.Add(torneo);
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
        bool IRepositorioTorneo.ActualizarTorneo(Torneo torneo)
        {
            bool actualizado=false;
            var tor=_appContext.Torneos.Find(torneo.Id);
            if (tor!=null)
            {
                try
                {
                    tor.Nombre=torneo.Nombre;
                    tor.Categoria=torneo.Categoria;
                    tor.FechaIni=torneo.FechaIni;
                    tor.FechaFin=torneo.FechaFin;
                    tor.DisciplinaDep=torneo.DisciplinaDep;
                    tor.CapacidadEsp=torneo.CapacidadEsp;
                    
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
        bool IRepositorioTorneo.EliminarTorneo(int idTorneo)
        {
            bool eliminado=false;
            var torneo=_appContext.Torneos.Find(idTorneo);
            if (torneo!=null)
            {
                try
                {
                    _appContext.Torneos.Remove(torneo);
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
        Torneo IRepositorioTorneo.BuscarTorneo(int idTorneo)
        {
            Torneo torneo=_appContext.Torneos.Find(idTorneo);
            return torneo;
        }

        IEnumerable<Torneo> IRepositorioTorneo.ListarTorneos()
        {
            return _appContext.Torneos; //Video 2:25:00 Sep/13
        }
        //******************************************
        List <Torneo> IRepositorioTorneo.ListarTorneosFK()
        {
            return _appContext.Torneos.ToList(); //Video 2:25:00 Sep/13
        }
        //******************************************
        
    }    
}