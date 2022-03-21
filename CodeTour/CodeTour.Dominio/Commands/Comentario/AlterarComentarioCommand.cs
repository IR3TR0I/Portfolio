using CodeTour.Comum.CommandQueries.Command;
using CodeTour.Comum.Enum;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTour.Dominio.Commands.Comentario
{
    public class AlterarComentarioCommand : Notifiable<Notification>, ICommand
    {
        public AlterarComentarioCommand()
        {

        }
        public AlterarComentarioCommand(Guid idPacote, string texto, string sentimento, EnStatusComentario status)
        {
            IdPacote = idPacote;
            Texto = texto;
            Sentimento = sentimento;
            Status = status;
        }

        public Guid IdPacote { get; set; }
        public string Texto { get; private set; }
        public string Sentimento { get; private set; }
        public EnStatusComentario Status { get; private set; }
        public void Validar()
        {
            AddNotifications(new Contract<Notification>()
                .Requires()
                .IsNotNullOrEmpty(Texto, "Texto", "Informe o Texto do comentário")
                .IsNotNullOrEmpty(Sentimento, "Sentimento", "Informe o sentimento do comentário")
                .AreNotEquals(IdPacote, Guid.Empty, "IdUsuario", "Informe o Id do Usuário do comentário")
            );
        }
    }
}
