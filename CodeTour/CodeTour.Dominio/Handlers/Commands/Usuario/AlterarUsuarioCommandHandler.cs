using CodeTour.Comum.CommandQueries;
using CodeTour.Comum.CommandQueries.Command;
using CodeTour.Comum.Handlers;
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
    public class AlterarUsuarioCommandHandler : Notifiable<Notification>, IHandlerCommand<AlterarUsuarioCommand>
    {
        private readonly IUsuarioRepositorio _repositorio;

        public AlterarUsuarioCommandHandler(IUsuarioRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public ICommandResult Handle(AlterarUsuarioCommand command)
        {
            //Fail Fast Validation
            //Aplicar as validações
            command.Validar();

            if (command.IsValid)
                return new GenericCommandResult(false, "Dados inválidos", command.Notifications);

            //Verifica se email existe
            var usuario = _repositorio.BuscarPorId(command.IdUsuario);

            if (usuario == null)
                return new GenericCommandResult(false, "Usuário não encontrado", null);

            //Caso o usuário informe outro e-mail verifica se já existe algum usuário cadastrado com o e-mail
            if (usuario.Email != command.Email)
            {
                var emailExiste = _repositorio.BuscarPorEmail(command.Email);

                if (emailExiste != null)
                    return new GenericCommandResult(false, "Email já cadastrado", null);
            }

            usuario.AlterarUsuario(command.Nome, command.Email);

            if (!string.IsNullOrEmpty(command.Telefone))
                usuario.AlterarTelefone(command.Telefone);

            if (usuario.IsValid)
                return new GenericCommandResult(false, "Dados inválidos", usuario.Notifications);

            //Salvar usuario banco
            _repositorio.Alterar(usuario);

            //Enviar email de boas vindas

            return new GenericCommandResult(true, "Conta alterada com Sucesso", null);
        }

       
    }
}
