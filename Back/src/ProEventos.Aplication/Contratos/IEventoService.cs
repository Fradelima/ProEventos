using System.Threading.Tasks;
using ProEventos.Domain;

namespace ProEvento.Aplication.Contratos
{
    public interface IEventoService
    {
         Task<Evento> AddEventos(Evento Model);
         Task<Evento> UpdateEventos(int eventoId, Evento Model);
         Task<bool> DeleteEvento(int eventoId);
         Task<Evento[]> GetAllEventosAsync(bool IncludePalestrantes = false);
         Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool IncludePalestrantes = false);
          
         Task<Evento> GetAEventoByIdAsync(int eventoId, bool IncludePalestrantes = false);
    }
}