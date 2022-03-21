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
    public class EsqueceuSenhaCommandHandler : Notifiable<Notification>, IHandlerCommand<EsqueciSenhaCommand>
    {
        private readonly IUsuarioRepositorio _repositorio;

        public EsqueceuSenhaCommandHandler(IUsuarioRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public ICommandResult Handle(EsqueciSenhaCommand command)
        {
            //Fail Fast Validation
            //Aplicar as validações
            command.Validar();

            if (command.IsValid)
                return new GenericCommandResult(false, "Dados inválidos", command.Notifications);

            //Verifica se email existe
            var usuario = _repositorio.BuscarPorEmail(command.Email);

            if (usuario == null)
                return new GenericCommandResult(false, "Email inválido", null);

            //Gerar nova senha
            string senha = Senha.GeradorSenha();
            //Criptografar senha
            usuario.AlterarSenha(Senha.Criptografar(senha));

            if (usuario.IsValid)
                return new GenericCommandResult(false, "Dados inválidos", usuario.Notifications);

            //Salvar usuario banco
            _repositorio.Alterar(usuario);

            //TODO: Enviar email de boas vindas

            return new GenericCommandResult(true, "Uma nova senha foi criada e enviada para o seu e-mail, verifique!!!", null);
        }

       
    }
}
