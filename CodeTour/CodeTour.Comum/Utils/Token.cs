using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CodeTour.Comum.Utils
// Criamos nosso método que vai gerar nosso Token
{
   public class Token
    {
        public Token(string issuer, string audience, string chaveSecreta)
        {
            Issuer = issuer;
            Audience = audience;
            ChaveSecreta = chaveSecreta;
        }

        public string Issuer { get; private set; }

        public string Audience { get; private set; }
        public string ChaveSecreta { get; private set; }

        public string GerarJsonWebToken(Guid id, string nome, string email, string tipoUsuario)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(ChaveSecreta));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            // Definimos nossas Claims (dados da sessão) para poderem ser capturadas
            // a qualquer momento enquanto o Token for ativo
            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.FamilyName, nome),
                new Claim(JwtRegisteredClaimNames.Email, email),
                new Claim(ClaimTypes.Role,tipoUsuario),
                new Claim("role",tipoUsuario),
                new Claim(JwtRegisteredClaimNames.Jti, id.ToString())
            };

            // Configuramos nosso Token e seu tempo de vida
            var token = new JwtSecurityToken
                (
                    Issuer,
                    Audience,
                    claims,
                    expires: DateTime.Now.AddMinutes(120),
                    signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
