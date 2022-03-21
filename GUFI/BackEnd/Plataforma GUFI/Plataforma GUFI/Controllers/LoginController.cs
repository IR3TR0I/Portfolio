using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Plataforma_GUFI.Domains;
using Plataforma_GUFI.Interfaces;
using Plataforma_GUFI.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Plataforma_GUFI.Controllers
{// Define que o tipo de resposta da API será no formato
    [Produces("application/json")]
    // Define que a rota de uma requisição será no formato domínio/api/NomeController
    [Route("api/[controller]")]
    // Define que é um controlador de API
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository { get; set; }


        public LoginController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        [HttpPost]
        public IActionResult Post(LoginViewModel login)
        {

            try
            {
                Usuario usuarioBuscado = _usuarioRepository.Login(login.Email, login.Senha);

                if (usuarioBuscado == null)
                {
                    return NotFound("Email ou senha Inválidos!!");
                }

                var claims = new[]
                {
                    // Armazena na Claim o e-mail do usuário autenticado
                    new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email),

                    // Armazena na Claim o ID do usuário autenticado
                    new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.IdUsuario.ToString()),

                    // Armazena na Claim o tipo de usuário que foi autenticado (Administrador ou Comum)
                    new Claim(ClaimTypes.Role, usuarioBuscado.IdTipoUsuario.ToString()),

                    // Armazena na Claim o tipo de usuário que foi autenticado (Administrador ou Comum) de forma personalizada
                    new Claim("Role", usuarioBuscado.IdTipoUsuario.ToString()),

                    // Armazena na Claim o nome do usuário que foi autenticado
                    new Claim(JwtRegisteredClaimNames.Name, usuarioBuscado.NomeUsuario)

                };
                // Define a chave de acesso ao token
                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("gufi-chave-autenticacao"));

                // Define as credenciais do token - Header
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                // Gera o token
                var token = new JwtSecurityToken(
                    issuer: "gufi.webApi",                 // emissor do token
                    audience: "gufi.webApi",               // destinatário do token
                    claims: claims,                        // dados definidos acima
                    expires: DateTime.Now.AddMinutes(30),  // tempo de expiração
                    signingCredentials: creds              // credenciais do token
                );

                // Retorna Ok com o token
                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });

            }
            catch (Exception ex )
            {

                return BadRequest(ex);
            }
        }
    }
}
