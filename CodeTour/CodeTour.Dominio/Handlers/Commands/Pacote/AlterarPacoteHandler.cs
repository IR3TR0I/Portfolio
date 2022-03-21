using CodeTour.Comum.CommandQueries;
using CodeTour.Comum.CommandQueries.Command;
using CodeTour.Comum.Handlers;
using CodeTour.Dominio.Commands.Pacote;
using CodeTour.Dominio.Repositorios;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTour.Dominio.Queries.Commands.Pacote
{
    public class AlterarPacoteHandler : Notifiable<Notification>, IHandlerCommand<AlterarPacoteCommand>
    {
        private readonly IPacoteRepositorio _repositorio;

        public AlterarPacoteHandler(IPacoteRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public ICommandResult Handle(AlterarPacoteCommand command)
        {
            //Fail Fast Validation
            //Aplicar as validações
            command.Validar();

            if (command.IsValid)
                return new GenericCommandResult(false, "Dados inválidos", command.Notifications);

            //Verifica se email existe
            var pacote = _repositorio.BuscarPorId(command.IdPacote);

            if (pacote == null)
                return new GenericCommandResult(false, "Pacote não encontrado", null);

            //Verifica se titulo pacote existe
            var pacoteExiste = _repositorio.BuscarPorTitulo(command.Titulo);

            if (pacoteExiste != null)
                return new GenericCommandResult(false, "Pacote já cadastrado", null);

            //Altera titulo e descricao do pacote
            pacote.AlterarPacote(command.Titulo, command.Descricao);

            if (pacote.IsValid)
                return new GenericCommandResult(false, "Dados inválidos", pacote.Notifications);

            //Salvar usuario banco
            _repositorio.Alterar(pacote);

            //Enviar email de boas vindas

            return new GenericCommandResult(true, "Pacote alterado", null);
        }

        
    }
}
