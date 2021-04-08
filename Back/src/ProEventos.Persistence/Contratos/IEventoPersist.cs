using System.Threading.Tasks;
using ProEventos.Domain;

namespace ProEventos.Persistence.Contratos
{
    public interface IEventoPersist
    {
          // Eventos
          Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false);
          Task<Evento[]> GetAllEventosAsync(bool includePalestrantes = false);
           Task<Evento> GetAEventoByIdAsync(int eventoId, bool includePalestrantes = false);


            }
}