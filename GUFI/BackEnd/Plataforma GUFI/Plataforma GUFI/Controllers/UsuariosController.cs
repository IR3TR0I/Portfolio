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
    public class UsuariosController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository { get; set; }

        public UsuariosController()
        {
            _usuarioRepository = new UsuarioRepository();
        }


        /// <summary>
        /// Lista todos os usuários
        /// </summary>
        /// <returns>Uma lista de usuários e um status code 200 - Ok</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_usuarioRepository.Listar());
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
                throw;
            }
        }

        /// <summary>
        /// Busca um usuário através do ID
        /// </summary>
        /// <param name="id">ID do usuário que será buscado</param>
        /// <returns>Um usuário buscado e um status code 200 - Ok</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_usuarioRepository.BuscarPorId(id));
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Cadastra um novo usuário
        /// </summary>
        /// <param name="novoUsuario">Objeto novoUsuario que será cadastrado</param>
        /// <returns>Um status code 201 - Created</returns>
        [HttpPost]
        public IActionResult Post(Usuario novoUsuario)
        {
            try
            {
                _usuarioRepository.Cadastrar(novoUsuario);

                return StatusCode(201);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }

        }

        /// <summary>
        /// Atualiza um usuário existente
        /// </summary>
        /// <param name="id">ID do usuário que será atualizado</param>
        /// <param name="usuarioAtualizado">Objeto com as novas informações</param>
        [HttpPut("{id}")]
         public IActionResult Put(int id ,Usuario usuarioAtualizado)
            {
            try
            {
                _usuarioRepository.Atualizar(id, usuarioAtualizado);

                return StatusCode(204);//Sem Conteudo
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }


         }

        /// <summary>
        /// Deleta um usuário existente
        /// </summary>
        /// <param name="id">ID do usuário que será deletado</param>
   
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                // Faz a chamada para o método
                _usuarioRepository.Deletar(id);

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
