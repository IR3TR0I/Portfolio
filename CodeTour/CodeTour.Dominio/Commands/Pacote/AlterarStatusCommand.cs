using CodeTour.Comum.CommandQueries.Command;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTour.Dominio.Commands.Pacote
{
    public class AlterarStatusCommand : Notifiable<Notification>, ICommand
    {
        public AlterarStatusCommand()
        {

        }
        public AlterarStatusCommand(bool status, Guid idPacote)
        {
            Status = status;
            IdPacote = idPacote;
        }

        public bool Status { get; set; }
        public Guid IdPacote { get; set; }
        public void Validar()
        {
            AddNotifications(new Contract<Notification>()
               .Requires()
               .AreNotEquals(IdPacote, Guid.Empty, "IdUsuario", "Id do usuário inválido")
           );
        }
    }
}
