using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;
using ProEventos.Persistence.Contextos;
using ProEventos.Persistence.Contratos;

namespace ProEventos.Persistence
{
    public class PalestrantePersit : IPalestrantePersist
    {
        private readonly ProEventosContext _context;
        public PalestrantePersit(ProEventosContext context)
        {
            _context = context;

        }
      
      

        public async Task<Palestrante[]> GetAllPalestrantesAsync(bool IncludeEventos = false)
        {
           IQueryable<Palestrante> query = _context.Palestrantes
            .Include(p => p.RedeSociais);

            if(IncludeEventos){
                query =query
                .Include(p => p.PalestranteEventos)
                .ThenInclude(pe => pe.Evento);
            }

            query = query.AsNoTracking().OrderBy(p => p.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string nome, bool IncludeEventos)
        {
           IQueryable<Palestrante> query = _context.Palestrantes
            .Include(p => p.RedeSociais);

            if(IncludeEventos){
                query =query
                .Include(p => p.PalestranteEventos)
                .ThenInclude(pe => pe.Evento);
            }

            query = query.AsNoTracking().OrderBy(p => p.Id)
                                        .Where(p => p.Nome.ToLower().Contains(nome.ToLower()));

            return await query.ToArrayAsync();
        }

        public async Task<Palestrante> GetAPalestranteByIdAsync(int palestranteId, bool IncludeEventos)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
            .Include(p => p.RedeSociais);

            if(IncludeEventos){
                query =query
                .Include(p => p.PalestranteEventos)
                .ThenInclude(pe => pe.Evento);
            }

            query = query.AsNoTracking().OrderBy(p => p.Id)
                                        .Where(p => p.Id == palestranteId);

            return await query.FirstOrDefaultAsync();
        }


    }
}