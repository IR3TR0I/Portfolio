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

    //[Authorize(Roles = "1")]
    public class TiposEventosController : ControllerBase
    {
        private ITiposEventoRepository _tiposEventoRepository { get; set; }


        public TiposEventosController()
        {
            _tiposEventoRepository = new TiposEventoRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                // Retorna a resposta da requisição fazendo a chamada para o método
                return Ok(_tiposEventoRepository.Listar());
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
                // Retorna a resposta da requisição fazendo a chamada para o método
                return Ok(_tiposEventoRepository.BuscarPorId(id));
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpPost]
        public IActionResult Post(TiposEvento novoTipoEvento)
        {
            try
            {
                // Faz a chamada para o método
                _tiposEventoRepository.Cadastrar(novoTipoEvento);

                // Retorna um status code
                return StatusCode(201);//Criado
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, TiposEvento tipoEventoAtualizado)
        {
            try
            {
                // Faz a chamada para o método
                _tiposEventoRepository.Atualizar(id, tipoEventoAtualizado);

                // Retorna um status code
                return StatusCode(204);//Sem conteudo
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                // Faz a chamada para o método
                _tiposEventoRepository.Deletar(id);

                // Retorna um status code
                return StatusCode(204);//Sem conteudo
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
