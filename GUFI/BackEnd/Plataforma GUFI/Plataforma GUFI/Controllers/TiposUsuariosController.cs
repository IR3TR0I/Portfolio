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
    public class TiposUsuariosController : ControllerBase
    {
        /// Objeto _tiposUsuarioRepository que irá receber todos os métodos definidos na interface ITiposUsuarioRepository
        private ITiposUsuarioRepository _tiposUsuarioRepository { get; set; }


        public TiposUsuariosController()
        {
            _tiposUsuarioRepository = new TiposUsuarioRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                // Retorna a resposta da requisição fazendo a chamada para o método
                return Ok(_tiposUsuarioRepository.Listar());
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
                return Ok(_tiposUsuarioRepository.BuscarPorId(id));
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpPost]
        public IActionResult Post(TiposUsuario novoTipousuario)
        {
            try
            {
                // Faz a chamada para o método
                _tiposUsuarioRepository.Cadastrar(novoTipousuario);

                // Retorna um status code
                return StatusCode(201);//Criado
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, TiposUsuario tipoUsuarioAtualizado)
        {
            try
            {
                // Faz a chamada para o método
                _tiposUsuarioRepository.Atualizar(id, tipoUsuarioAtualizado);

                // Retorna um status code
                return StatusCode(204);//Sem Conteudo
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
                _tiposUsuarioRepository.Deletar(id);

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
