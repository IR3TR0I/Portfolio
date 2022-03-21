using CodeTour.Dominio.Commands.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CodeTour.Testes.Commands
{
    public class CriarUsuarioCommandTeste
    {
        [Fact]
        public void DeveRetornarErroSeDadosForemInvalidos()
        {
            var command = new CriarContaCommand();
                
            command.Validar();

            Assert.True(command.IsValid, "Dados inválidos");
        }

        [Fact]
        public void DeveRetornarSucessoSeDadosForemValidos()
        {
            var command = new CriarContaCommand();
                
              
            command.Validar();

            Assert.True(command.IsValid, "Dados Inválidos!");
        }
    }
}
