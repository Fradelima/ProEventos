using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProEventos.Persistence;
using ProEventos.Domain;
using ProEventos.Persistence.Contextos;
using ProEvento.Aplication.Contratos;
using Microsoft.AspNetCore.Http;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventosController : ControllerBase
    {
        private readonly IEventoService _eventoService;

        public EventosController(IEventoService eventoService)
        {
            _eventoService = eventoService;

        }




        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var eventos = await _eventoService.GetAllEventosAsync(true);
                if(eventos == null) return NotFound("nenhum evento encontrado.");
                return Ok (eventos);
            }
            catch (Exception ex)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar recuperar eventos. Erro: {ex.Message}"); 
            }
        
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
             try
            {
                var evento = await _eventoService.GetAEventoByIdAsync(id, true);
                if(evento == null) return NotFound("evento por id encontrado.");
                return Ok (evento);
            }
            catch (Exception ex)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar recuperar eventos. Erro: {ex.Message}"); 
            }
        }


        [HttpGet("{tema}/tema")]
        public async Task<IActionResult> Get(string tema)
        {
             try
            {
                var evento = await _eventoService.GetAllEventosByTemaAsync(tema, true);
                if(evento == null) return NotFound(" eventos por tema não encontrado.");
                return Ok (evento);
            }
            catch (Exception ex)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar recuperar eventos. Erro: {ex.Message}"); 
            }
        }


        [HttpPost]
        public async Task<IActionResult> Post(Evento model)
        {
             try
            {
                var evento = await _eventoService.AddEventos(model);
                if(evento == null) return BadRequest(" Erro ao tentar adicionar evento.");
                return Ok (evento);
            }
            catch (Exception ex)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar adicionar eventos. Erro: {ex.Message}"); 
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Evento model)
        {
             try
            {
                var evento = await _eventoService.UpdateEventos(id, model);
                if(evento == null) return BadRequest(" Erro ao tentar adicionar evento.");
                return Ok (evento);
            }
            catch (Exception ex)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar atualizar eventos. Erro: {ex.Message}"); 
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                return await _eventoService.DeleteEvento(id) ?
                Ok("deletado") : 
                BadRequest("Evento não deletado");
            }
           catch (Exception ex)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar deletar eventos. Erro: {ex.Message}"); 
            }
        }
    }
}
