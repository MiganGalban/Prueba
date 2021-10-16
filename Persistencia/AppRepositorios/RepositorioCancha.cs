using System.Collections.Generic;
using Dominio;
using System.Linq;

namespace Persistencia
{
    public class RepositorioCancha:IRepositorioCancha
    {
        //Atributos
        private readonly AppContext _appContext;

        //Metodos

        //Constructor
        public RepositorioCancha(AppContext appContext)
        {
            _appContext=appContext;
        }
        //Implementar todos los metodos de la interfaz IRepositorioCancha
        bool IRepositorioCancha.CrearCancha(Cancha cancha)
        {
            bool creado=false;
            try
            {
                _appContext.Canchas.Add(cancha);
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
        bool IRepositorioCancha.ActualizarCancha(Cancha cancha)
        {
            bool actualizado=false;
            var can=_appContext.Canchas.Find(cancha.Id);
            if (can!=null)
            {
                try
                {
                    can.Nombre=cancha.Nombre;
                    can.Estado=cancha.Estado;
                    can.CapacidadEsp=cancha.CapacidadEsp;
                    can.Medidas=cancha.Medidas;
                    can.DisciplinaDep=cancha.DisciplinaDep;
                    
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
        bool IRepositorioCancha.EliminarCancha(int idCancha)
        {
            bool eliminado=false;
            var cancha=_appContext.Canchas.Find(idCancha);
            if (cancha!=null)
            {
                try
                {
                    _appContext.Canchas.Remove(cancha);
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
        Cancha IRepositorioCancha.BuscarCancha(int idCancha)
        {
            Cancha cancha=_appContext.Canchas.Find(idCancha);
            return cancha;
        }

        IEnumerable<Cancha> IRepositorioCancha.ListarCanchas()
        {
            return _appContext.Canchas; //Video 2:25:00 Sep/13
        }

        
    }    
}