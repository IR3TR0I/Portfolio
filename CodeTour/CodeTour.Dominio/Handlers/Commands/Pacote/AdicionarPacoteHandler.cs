using CodeTour.Comum.CommandQueries;
using CodeTour.Comum.Handlers;
using CodeTour.Dominio.Commands.Pacote;
using CodeTour.Dominio.Repositorios;
using Flunt.Notifications;
using System;

namespace CodeTour.Dominio.Handlers.Pacote
{
    public class AdicionarPacoteHandler : Notifiable<Notification>, IHandlerCommand<CriarPacoteCommand>
    {
        private readonly IPacoteRepositorio _repositorio;

        public AdicionarPacoteHandler(IPacoteRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public ICommandResult Handle(CriarPacoteCommand command)
        {
            //Fail Fast Validation
            //Aplicar as validações
            command.Validar();

            if (command.IsValid)
                return new GenericCommandResult(false, "Dados inválidos", command.Notifications);

            //Verifica se titulo pacote existe
            var pacoteExiste = _repositorio.BuscarPorTitulo(command.Titulo);

            if (pacoteExiste != null)
                return new GenericCommandResult(false, "Pacote já cadastrado", null);

            //Gerar Entidade Usuario
            var pacote = new Entidades.Pacote(command.Titulo, command.Descricao, command.Imagem, command.Status, command.Telefone);

            if (pacote.IsValid)
                return new GenericCommandResult(false, "Dados inválidos", pacote.Notifications);

            _repositorio.Adicionar(pacote);

            return new GenericCommandResult(true, "Pacote criado", null);
        }

        
    }
}
