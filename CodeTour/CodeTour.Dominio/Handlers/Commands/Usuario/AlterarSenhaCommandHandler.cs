using CodeTour.Comum.CommandQueries;
using CodeTour.Comum.Handlers;
using CodeTour.Comum.Utils;
using CodeTour.Dominio.Commands.Usuario;
using CodeTour.Dominio.Repositorios;
using Flunt.Notifications;

namespace CodeTour.Dominio.Queries.Commands.Usuario
{
    public class AlterarSenhaCommandHandler : Notifiable<Notification>, IHandlerCommand<AlterarSenhaCommand>
    {
        private readonly IUsuarioRepositorio _repositorio;

        public AlterarSenhaCommandHandler(IUsuarioRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public ICommandResult Handle(AlterarSenhaCommand command)
        {
            //Fail Fast Validation
            //Aplicar as validações
            command.Validar();

            if (command.IsValid)
                return new GenericCommandResult(false, "Senha inválida", command.Notifications);

            var usuarioexiste = _repositorio.BuscarPorId(command.IdUsuario);

            if (usuarioexiste == null)
                return new GenericCommandResult(false, "Usuário não encontrado", command.Notifications);

            //TODO: Criptografar senha
            command.Senha = Senha.Criptografar(command.Senha);
            usuarioexiste.AlterarSenha(command.Senha);

            _repositorio.Alterar(usuarioexiste);


            return new GenericCommandResult(true, "Senha Alterada", null);
        }

        
    }
}
