using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Plataforma_GUFI.Domains;
using Plataforma_GUFI.Interfaces;
using Plataforma_GUFI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Plataforma_GUFI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class EventosController : ControllerBase
    {
        private IEventoRepository _eventoRepository { get; set; }

        public EventosController()
        {
            _eventoRepository = new EventoRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                // Retorna a resposta da requisição fazendo a chamada para o método
                return Ok(_eventoRepository.Listar());
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                // Retora a resposta da requisição fazendo a chamada para o método
                return Ok(_eventoRepository.BuscarPorId(id));
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Cadastra um novo evento
        /// </summary>
        /// <param name="novoEvento">Objeto novoEvento que será cadastrado</param>
        /// <returns>Um status code 201 - Created</returns>
        // Define que somente o administrador pode acessar o método
        //[Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(Evento novoEvento)
        {
            try
            {
                // Faz a chamada para o método
                _eventoRepository.Cadastrar(novoEvento);

                // Retorna um status code
                return StatusCode(201);//Criado
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        //[Authorize(Roles = "1")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, Evento eventoAtualizado)
        {
            try
            {
                // Faz a chamada para o método
                _eventoRepository.Atualizar(id, eventoAtualizado);

                // Retorna um status code
                return StatusCode(204);//Sem conteudo
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        //[Authorize(sRoles = "1")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                // Faz a chamada para o método
                _eventoRepository.Deletar(id);

                // Retorna um status code
                return StatusCode(204);//Sem Conteudo
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
