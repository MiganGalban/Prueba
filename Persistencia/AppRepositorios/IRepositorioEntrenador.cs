using System.Collections.Generic;
using Dominio;

namespace Persistencia
{  
    public interface IRepositorioEntrenador
    {
        IEnumerable<Entrenador> ListarEntrenadores();
        bool CrearEntrenador(Entrenador Entrenador);
        bool ActualizarEntrenador(Entrenador Entrenador);
        bool EliminarEntrenador(int idEntrenador);
        Entrenador BuscarEntrenador (int idEntrenador);
    }
}
