using System.Collections.Generic;
using Dominio;

namespace Persistencia
{
    public interface IRepositorioPatrocinador
    {
        IEnumerable<Patrocinador> ListarPatrocinadores();
        bool CrearPatrocinador(Patrocinador Patrocinador);
        bool ActualizarPatrocinador(Patrocinador Patrocinador);
        bool EliminarPatrocinador(int idPatrocinador);
        Patrocinador BuscarPatrocinador (int idPatrocinador);
    }
}