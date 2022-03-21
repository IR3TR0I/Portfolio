using CodeTour.Comum.CommandQueries;
using CodeTour.Dominio.Commands.Usuario;
using CodeTour.Dominio.Queries.Commands.Usuario;
using CodeTour.Dominio.Repositorios;
using CodeTour.Infra.Repositories;
using CodeTour.Testes.Repositories;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CodeTour.Testes.Handlers
{
    public class CriaUsuarioHandlerTestes 
    {
        //[Fact]
        //public void DadosUmComandoInvalidoDeveInterromperExecucao()
        //{
        //    var command = new CriarContaCommand("", "", "", Comum.Enum.EnTipoUsuario.Comum, "");
        //    var handler = new CriarContaCommandHandler(new FakeUsuarioRepositorio());
        //    GenericCommandResult result = (GenericCommandResult)handler.Handle(command);
        //    Assert.False(result.Sucesso, "Usuário válido");
        //}

        //[Fact]
        //public void DadosUmComandoValidoDeveCriarUsuario()
        //{
        //    var command = new CriarContaCommand("Fernando Henrique", "email@email.com", "1234567", Comum.Enum.EnTipoUsuario.Comum, "11972084338");
        //    var handler = new CriarContaCommandHandler(new FakeUsuarioRepositorio());
        //    GenericCommandResult result = (GenericCommandResult)handler.Handle(command);
        //    Assert.True(result.Sucesso, "Usuário inválido");
        //}
    }
}
