using System.Collections.Generic;
using Dominio;
using System.Linq;

namespace Persistencia
{
    public class RepositorioMunicipio:IRepositorioMunicipio
    {
        //Atributos
        private readonly AppContext _appContext;

        //Metodos

        //Constructor
        public RepositorioMunicipio(AppContext appContext)
        {
            _appContext=appContext;
        }
        //Implementar todos los metodos de la interfaz IRepositorioMunicipio
        bool IRepositorioMunicipio.CrearMunicipio(Municipio municipio)
        {
            bool creado=false;
            bool ex= Existe(municipio);
            if(!ex)
            {
                try
                {
                    _appContext.Municipios.Add(municipio); // Agrega municipio nuevo a _appContext quien se encarga de comunicar con la BD
                    _appContext.SaveChanges();  //Guarda cambios en la BD
                    creado=true;
                }
                catch (System.Exception)
                {
                    return creado;
                    //throw;
                }
            }
            return creado;

        }

        bool Existe(Municipio muni)
        {
            bool ex=false;
            var mun=_appContext.Municipios.FirstOrDefault(m=> m.Nombre==muni.Nombre);
            if(mun!=null)
            {
                ex=true;
            }
            return ex;
        }

        bool IRepositorioMunicipio.ActualizarMunicipio(Municipio municipio) //Trae todos los parametros del objeto municipio para reemplazar todo el objeto y tomar su ID
        {
            bool actualizado=false;
            var mun=_appContext.Municipios.Find(municipio.Id); //Busca el municipio objetivo con un Metodo de C# con appContext Hacia la lista y lo guarda en una variable mun para luego reemplazarlo
            if (mun!=null)
            {
                try
                {
                    mun.Nombre=municipio.Nombre; //Se reemplaza cada uno de los atributos de dicha entidad uno a uno, nombre, documento, telf, etc
                    _appContext.SaveChanges();   //mun es la variable referencia al obj antiguo, municipio es el obj nuevo que se recibio
                    actualizado=true;
                }
                catch (System.Exception)
                {
                    return actualizado;
                }
            }
            return actualizado;

        }
        bool IRepositorioMunicipio.EliminarMunicipio(int idMunicipio)
        {
            bool eliminado=false;
            var municipio=_appContext.Municipios.Find(idMunicipio);// Se busca el municipio completo a partir del Id que se suministro en un principio
            if (municipio!=null)
            {
                try
                {
                    _appContext.Municipios.Remove(municipio); //Cuando el objeto municipio con el Id q se le dio, lo encuentra lo remueve de la BD a traves de _appContext
                    _appContext.SaveChanges(); // Guarda cambios
                    eliminado=true;
                }
                catch (System.Exception)
                {
                    return eliminado;
                }

            }
            return eliminado;

        }
        Municipio IRepositorioMunicipio.BuscarMunicipio(int idMunicipio)
        {
            Municipio municipio=_appContext.Municipios.Find(idMunicipio); //Se busca el municipio y lo devuelve
            return municipio;
        }

        IEnumerable<Municipio> IRepositorioMunicipio.ListarMunicipios()
        {
            return _appContext.Municipios; //Video 2:25:00 Sep/13   Trae los datos con appContext que es la encargada de comunicacion con la BD apuntando a la tabla Municipios
        }

        
    }    
}