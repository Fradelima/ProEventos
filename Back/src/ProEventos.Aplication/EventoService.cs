using System;
using System.Threading.Tasks;
using ProEvento.Aplication;
using ProEvento.Aplication.Contratos;
using ProEventos.Persistence.Contextos;

using ProEventos.Domain;
using ProEventos.Persistence.Contratos;

namespace ProEventos.Aplication
{
    public class EventoService : IEventoService
    {
        private readonly IGeralPersist _geralPersist;
        private readonly IEventoPersist _eventoPersist;

        public EventoService(IGeralPersist geralPersist, IEventoPersist eventoPersist)
        {
            _eventoPersist = eventoPersist;
            _geralPersist = geralPersist;

        }
        public async Task<Evento> AddEventos(Evento model)
        {
            try
            {
                _geralPersist.Add<Evento>(model);
                if (await _geralPersist.SaveChangesAsync()){
                  return await _eventoPersist.GetAEventoByIdAsync(model.Id, false);

                }
                return null;
            }
            catch (Exception ex)
            {
                
                throw new  Exception(ex.Message);
            }
        }

        public async Task<Evento> UpdateEventos(int eventoId, Evento model)
        {
             try
        {
             var evento = await _eventoPersist.GetAEventoByIdAsync(eventoId, false);
                if(evento == null) return null;
                model.Id = evento.Id;

                _geralPersist.Update(model);
                if (await _geralPersist.SaveChangesAsync()){
                  return await _eventoPersist.GetAEventoByIdAsync(model.Id, false);

                }
                return null;
            
        }
            catch (Exception ex)
            {
                
                throw new  Exception(ex.Message);
            }
           
        }


        public async Task<bool> DeleteEvento(int eventoId)
        {
             try
        {
             var evento = await _eventoPersist.GetAEventoByIdAsync(eventoId, false);
                if(evento == null) throw new Exception("O evento não foi encontrado .");

                _geralPersist.Delete(evento);
                 return await _geralPersist.SaveChangesAsync();
            
        }
            catch (Exception ex)
            {
                
                throw new  Exception(ex.Message);
            }
        }

        public async Task<Evento[]> GetAllEventosAsync(bool includePalestrantes = false)
        {
            try
            {
                 var eventos = await _eventoPersist.GetAllEventosAsync(includePalestrantes);
                 if(eventos == null) return null;
                return eventos;
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
           

        }

   public async Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false)
        {
            try
            {
                 var eventos = await _eventoPersist.GetAllEventosByTemaAsync(tema, includePalestrantes);
                 if(eventos == null) return null;
                return eventos;
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }

        public async Task<Evento> GetAEventoByIdAsync(int eventoId, bool includePalestrantes = false)
        {
            try
            {
                 var evento = await _eventoPersist.GetAEventoByIdAsync(eventoId, includePalestrantes);
                 if(evento == null) return null;
                return evento;
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }

        
     

        
    }
}