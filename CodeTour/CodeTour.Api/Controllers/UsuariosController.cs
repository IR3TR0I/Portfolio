using CodeTour.Comum.CommandQueries;
using CodeTour.Comum.Utils;
using CodeTour.Dominio.Commands.Usuario;
using CodeTour.Dominio.Entidades;
using CodeTour.Dominio.Queries.Commands.Usuario;
using CodeTour.Dominio.Queries.Usuario;
using CodeTour.Dominio.Queries.Usuarios;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace CodeTour.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        public IConfiguration Configuration { get; }
        public UsuariosController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        [Route("Usuarios")]
        [HttpGet]
        public GenericCommandResult ListarTodos([FromServices] ListarUsuarioQueryHandler handler)
        {
            var query = new ListarUsuarioQuery();
            return (GenericCommandResult)handler.Handle(query);
        }

        [Route("Usuarios/{id}")]
        [HttpGet]
        public GenericCommandResult ListarPorId(Guid id, [FromServices] BuscarUsuarioPorIdQueryHandler handler)
        {
            var query = new BuscarUsuarioPorIdQuery();
            query.IdUsuario = id;
            return (GenericCommandResult)handler.Handle(query);
        }
        [Route("Cadastro")]
        [HttpPost]
        public GenericCommandResult Register([FromBody] CriarContaCommand command, [FromServices] CriarContaCommandHandler handler)
        {
            //command.User = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
            return (GenericCommandResult)handler.Handle(command);
        }

        [Route("Login")]
        [HttpPost]
        public GenericCommandResult SignIn([FromBody] LogarCommand command, [FromServices] LogarCommandHandler handler)
        {
            var resultado = (GenericCommandResult)handler.Handle(command);

            if (resultado.Sucesso)
            {
                Usuario usuario = (Usuario)resultado.Data;
                var token = new Token(
                                        Configuration["Token:issuer"],
                                        Configuration["Token:audience"],
                                        Configuration["Token:secretKey"]
                                     )
                                     .GerarJsonWebToken(
                                        usuario.Id,
                                        usuario.Nome,
                                        usuario.Email,
                                        usuario.TipoUsuario.ToString()
                                     );

                return new GenericCommandResult(true, "Usuário logado", new { token = token });
            }
            return resultado;
        }
        [Route("reset-password")]
        [HttpPut]
        public GenericCommandResult ResetPassword([FromBody] EsqueciSenhaCommand command, [FromServices] EsqueceuSenhaCommandHandler handler)
        {
            var resultado = (GenericCommandResult)handler.Handle(command);

            return resultado;
        }

        [Route("update-password")]
        [Authorize]
        [HttpPut]
        public GenericCommandResult UpdatePassword([FromBody] AlterarSenhaCommand command, [FromServices] AlterarSenhaCommandHandler handler)
        {
            var idUsuario = HttpContext.User.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Jti);
            command.IdUsuario = new Guid(idUsuario.Value);

            return (GenericCommandResult)handler.Handle(command);
        }
    }
}
