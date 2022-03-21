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
    public class CriarContaCommandHandler : Notifiable<Notification>, IHandlerCommand<CriarContaCommand>
    {
        private readonly IUsuarioRepositorio _repositorio;

        public CriarContaCommandHandler(IUsuarioRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public ICommandResult Handle(CriarContaCommand command)
        {
            //Fail Fast Validation
            //Aplicar as validações
            command.Validar();

            if (command.IsValid)
                return new GenericCommandResult(false, "Dados inválidos", command.Notifications);

            //Verifica se email existe
            var usuarioExiste = _repositorio.BuscarPorEmail(command.Email);

            if (usuarioExiste != null)
                return new GenericCommandResult(false, "Email já cadastrado", null);


            //Gerar Entidade Usuario
            var usuario = new Entidades.Usuario(command.Nome, command.Email, command.Senha, command.TipoUsuario);

            if (usuario.IsValid)
                return new GenericCommandResult(false, "Dados inválidos", usuario.Notifications);

            if (!string.IsNullOrEmpty(command.Telefone))
                usuario.AlterarTelefone(command.Telefone);

            //Criptografar senha
            usuario.AlterarSenha(Senha.Criptografar(command.Senha));

            if (usuario.IsValid)
                return new GenericCommandResult(false, "Dados inválidos", usuario.Notifications);

            //Salvar usuario banco
            _repositorio.Adicionar(usuario);

            //Enviar email de boas vindas

            return new GenericCommandResult(true, "Conta criada com Sucesso", null);
        }
    }
}
