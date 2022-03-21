using CodeTour.Comum.Enum;
using CodeTour.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CodeTour.Testes
{
    public class UsuarioTestes
    {
        [Fact]
        public void DeveRetornarSeUsuarioForValido()
        {
            var usuario = new Usuario(
                "Ruan",
                "ruangustavo@gmail.com",
                "654321",
                EnTipoUsuario.Comum
                );

            Assert.True(usuario.IsValid, "Usuário é válido");
        }
        [Fact]
        public void DeveRetornarSucessoSeUsuarioValido()
        {
            //Verifica se o usuário é realmente válido Assert.True
            var usuario = new Usuario("Fernando Henrique", "colte12@gmail.com", "123456", EnTipoUsuario.Admin);
            Assert.True(usuario.IsValid, "Usuário é válido");
        }

        [Fact]
        public void DeveRetornarErroSeTelefoneUsuarioInvalido()
        {
            //Verifica se o usuário é realmente inválido Assert.True
            var usuario = new Usuario("Fernando Henrique", "colte12@gmail.com", "12345", EnTipoUsuario.Admin);
            usuario.AlterarTelefone("1198545");

            Assert.True(usuario.IsValid, "Usuário é inválido");
        }

        [Fact]
        public void DeveRetornarSucessoSeTelefoneUsuarioInvalido()
        {
            //Verifica se o usuário é realmente inválido Assert.True
            var usuario = new Usuario("Fernando Henrique", "colte12@gmail.com", "1234567", EnTipoUsuario.Admin);
            usuario.AlterarTelefone("11985455852");

            Assert.True(usuario.IsValid, "Usuário é inválido");
        }
    }
}
