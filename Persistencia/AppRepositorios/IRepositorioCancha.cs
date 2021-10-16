using System.Collections.Generic;
using Dominio;

namespace Persistencia
{   

    public interface IRepositorioCancha
        {
            IEnumerable<Cancha> ListarCanchas();
            bool CrearCancha(Cancha Cancha);
            bool ActualizarCancha(Cancha Cancha);
            bool EliminarCancha(int idCancha);
            Cancha BuscarCancha (int idCancha);
        }
}