using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProEventos.API.Models;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : ControllerBase
    {
        

        public EventoController()
        {
           
        }

     
        public IEnumerable<Evento> _event = new Evento []
        {
                new Evento(){
                EventoId = 1,
                Tema ="Angular 11 e .Net 5",
                Local ="Belo Horizonte",
                Lote="1 Lote ",
                QtdPessoas = 250,
                DataEvento = DateTime.Now.AddDays(2).ToString(),
                ImagemURL = "foto.png"
                },
                new Evento(){
                EventoId = 2,
                Tema ="Angular 11 e .Net 5 e Novidades",
                Local ="São Paulo",
                Lote="2 Lote ",
                QtdPessoas = 23,
                DataEvento = DateTime.Now.AddDays(1).ToString(),
                ImagemURL = "fotoTeste.png"
                }
        };

         [HttpGet]
        public IEnumerable<Evento> Get()
        {
            return _event;
        }

         [HttpGet("{id}")]
        public IEnumerable<Evento> Get(int id)
        {
            return _event.Where(evento => evento.EventoId == id);
        }

         [HttpPost]
        public string Post()
        {
            return "exemplo de post";
        }

         [HttpPut("{id}")]
        public string Put(int id)
        {
            return $"exemplo de put com Id = {id}";
        }

         [HttpDelete("{id}")]
        public string HttpDelete(int id)
        {
            return $"exemplo de HttpDelete com Id = {id}";
        }
    }
}
