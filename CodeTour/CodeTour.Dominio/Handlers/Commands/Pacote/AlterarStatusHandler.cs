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
    public class AlterarStatusHandler : Notifiable<Notification>, IHandlerCommand<AlterarStatusCommand>
    {
        private readonly IPacoteRepositorio _repositorio;

        public AlterarStatusHandler(IPacoteRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public ICommandResult Handle(AlterarStatusCommand command)
        {
            //Fail Fast Validation
            //Aplicar as validações
            command.Validar();

            if (command.IsValid)
                return new GenericCommandResult(false, "Dados inválidos", command.Notifications);

            //Verifica se existe pacote
            var pacote = _repositorio.BuscarPorId(command.IdPacote);

            if (pacote == null)
                return new GenericCommandResult(false, "Pacote não encontrado", null);

            pacote.AlterarStatus(command.Status);

            if (pacote.IsValid)
                return new GenericCommandResult(false, "Dados inválidos", pacote.Notifications);

            //Altera pacote banco
            _repositorio.Alterar(pacote);

            //Enviar email de boas vindas

            return new GenericCommandResult(true, "Pacote alterado", null);
        }

        
    }
}
