using System.Collections.Generic;
using Dominio;
using System.Linq;

namespace Persistencia
{
    public class RepositorioPatrocinador:IRepositorioPatrocinador
    {
        //Atributos
        private readonly AppContext _appContext;

        //Metodos

        //Constructor
        public RepositorioPatrocinador(AppContext appContext)
        {
            _appContext=appContext;
        }
        //Implementar todos los metodos de la interfaz IRepositorioPatrocinador
        bool IRepositorioPatrocinador.CrearPatrocinador(Patrocinador patrocinador)
        {
            bool creado=false;
            try
            {
                _appContext.Patrocinadores.Add(patrocinador);
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
        bool IRepositorioPatrocinador.ActualizarPatrocinador(Patrocinador patrocinador)
        {
            bool actualizado=false;
            var pat=_appContext.Patrocinadores.Find(patrocinador.Id);
            if (pat!=null)
            {
                try
                {
                    pat.Nombre=patrocinador.Nombre;
                    pat.Identificacion=patrocinador.Identificacion;
                    pat.TipoPersona=patrocinador.TipoPersona;
                    pat.NumTelf=patrocinador.NumTelf;
                    pat.Direccion=patrocinador.Direccion;
                    
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
        bool IRepositorioPatrocinador.EliminarPatrocinador(int idPatrocinador)
        {
            bool eliminado=false;
            var patrocinador=_appContext.Patrocinadores.Find(idPatrocinador);
            if (patrocinador!=null)
            {
                try
                {
                    _appContext.Patrocinadores.Remove(patrocinador);
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
        Patrocinador IRepositorioPatrocinador.BuscarPatrocinador(int idPatrocinador)
        {
            Patrocinador patrocinador=_appContext.Patrocinadores.Find(idPatrocinador);
            return patrocinador;
        }

        IEnumerable<Patrocinador> IRepositorioPatrocinador.ListarPatrocinadores()
        {
            return _appContext.Patrocinadores; //Video 2:25:00 Sep/13
        }

        
    }    
}