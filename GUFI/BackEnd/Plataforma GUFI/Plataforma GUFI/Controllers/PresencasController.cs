using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Plataforma_GUFI.Domains;
using Plataforma_GUFI.Interfaces;
using Plataforma_GUFI.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace Plataforma_GUFI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class PresencasController : ControllerBase
    {
        private IPresencaRepository _presencaRepository { get; set; }


        public PresencasController()
        {
            _presencaRepository = new PresencaRepository();
        }
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
               return Ok(_presencaRepository.Listar());
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }
        //[Authorize(Roles = "1")]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_presencaRepository.BuscarPorId(id));
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }
        //[Authorize(Roles = "1")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, Presenca presencaAtualizada)
        {
            try
            {
                _presencaRepository.Atualizar(id, presencaAtualizada);

                return StatusCode(204);//Sem Conteudo
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }
        //[Authorize(Roles = "1")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _presencaRepository.Deletar(id);

                return StatusCode(204);//Sem Conteudo
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }
        //[Authorize(Roles = "2")]
        [HttpGet("minhas")]
        public IActionResult GetMy()
        {
            try
            {
                int idUsuario = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);

                return Ok(_presencaRepository.ListarMinhas(idUsuario));
            }
            catch (Exception error)
            {

                return BadRequest(new 
                {
                    mensagem = "Não é possível mostrar as presenças se o usuário não estiver logado!",
                    error
                });
            }
        }
        //[Authorize(Roles = "2")]
        [HttpPost("inscricao/{idEvento}")]
        public IActionResult Join(int idEvento)
        {
            try
            {
                Presenca inscricao = new Presenca()
                {
                    // Armazena na propriedade IdUsuario da presenca recebida o ID do usuário logado
                    IdUsuario = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value),
                    // Armazena na propriedade IdEvento o ID do evento recebido pela URL
                    IdEvento = idEvento,
                    // Define a situação da presença como "Não confirmada"
                    Situacao = "Não confirmada"
                };

                // Faz a chamada para o método
                _presencaRepository.Inscrever(inscricao);

                return StatusCode(201);
            }
            catch (Exception error)
            {

                return BadRequest(error);
            }
        }

        //[Authorize(Roles = "1")]
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Presenca status)
        {
            try
            {
                _presencaRepository.Atualizar(id, status);

                return StatusCode(204);//Sem Conteudo
            }
            catch (Exception error)
            {

                return BadRequest(error);
            }
        }
    }
}
