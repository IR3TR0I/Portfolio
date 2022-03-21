using CodeTour.Comum.CommandQueries;
using CodeTour.Comum.CommandQueries.Command;
using CodeTour.Comum.Handlers;
using CodeTour.Comum.Utils;
using CodeTour.Dominio.Commands.Usuario;
using CodeTour.Dominio.Repositorios;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTour.Dominio.Queries.Commands.Usuario
{
    public class LogarCommandHandler : Notifiable<Notification>, IHandlerCommand<LogarCommand>
    {
        private readonly IUsuarioRepositorio _repositorio;

        public LogarCommandHandler(IUsuarioRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public ICommandResult Handle(LogarCommand command)
        {
            //Fail Fast Validation
            //Aplicar as validações
            command.Validar();

            if (command.IsValid)
                return new GenericCommandResult(false, "Email ou senha Inválidos", command.Notifications);

            //Verificar email existe
            var usuarioexiste = _repositorio.BuscarPorEmail(command.Email);

            if (usuarioexiste == null)
                return new GenericCommandResult(false, "Email inválido", command.Notifications);

            //Validar senha
            if (!Senha.ValidacaoSenha(command.Senha, usuarioexiste.Senha))
                return new GenericCommandResult(false, "Senha inválida", command.Notifications);


            return new GenericCommandResult(true, "Usuário logado", usuarioexiste);
        }
    }
}
