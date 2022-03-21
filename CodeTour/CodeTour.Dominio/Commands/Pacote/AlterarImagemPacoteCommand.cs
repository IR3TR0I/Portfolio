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
    public class AlterarImagemPacoteCommand : Notifiable<Notification>, ICommand
    {
        public AlterarImagemPacoteCommand()
        {

        }
        public AlterarImagemPacoteCommand(Guid idPacote, string imagem)
        {
            IdPacote = idPacote;
            Imagem = imagem;
        }

        public Guid IdPacote { get; set; }
        public string Imagem { get; set; }
        public void Validar()
        {
            AddNotifications(new Contract<Notification>()
              .Requires()
              .AreNotEquals(IdPacote, Guid.Empty, "IdUsuario", "Id do usuário inválido")
              .IsNotNullOrEmpty(Imagem, "Imagem", "Informe a imagem do pacote")
          );
        }
    }
}
