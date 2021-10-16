using System.Collections.Generic;
using Dominio;

namespace Persistencia
{

    public interface IRepositorioEscuelaArbitro
    {
        IEnumerable<EscuelaArbitro> ListarEscuelaArbitros();
        bool CrearEscuelaArbitro(EscuelaArbitro EscuelaArbitro);
        bool ActualizarEscuelaArbitro(EscuelaArbitro EscuelaArbitro);
        bool EliminarEscuelaArbitro(int idEscuelaArbitro);
        EscuelaArbitro BuscarEscuelaArbitro (int idEscuelaArbitro);
        List <EscuelaArbitro> ListarEscuelaArbitrosFK();//******************************************

    }
}