using CodeTour.Comum.CommandQueries.Command;
using CodeTour.Comum.Enum;
using Flunt.Notifications;
using Flunt.Validations;
using System;

namespace CodeTour.Dominio.Commands.Pacote
{
    public class AdicionarComentarioCommand : Notifiable<Notification>, ICommand
    {
        public AdicionarComentarioCommand()
        {

        }
        public AdicionarComentarioCommand(string texto, string sentimento, EnStatusComentario status, Guid idUsuario, Guid idPacote)
        {
            Texto = texto;
            Sentimento = sentimento;
            Status = status;
            IdUsuario = idUsuario;
            IdPacote = idPacote;
        }

        public string Texto { get; set; }
        public string Sentimento { get; set; }
        public EnStatusComentario Status { get; set; }
        public Guid IdUsuario { get; set; }
        public Guid IdPacote { get; set; }
        public void Validar()
        {
            AddNotifications(new Contract<Notification>()
               .Requires()
               .IsNotNullOrEmpty(Texto, "Texto", "Informe o Texto do comentário")
               .IsNotNullOrEmpty(Sentimento, "Sentimento", "Informe o sentimento do comentário")
               .AreNotEquals(IdUsuario, Guid.Empty, "IdUsuario", "Informe o Id do Usuário do comentário")
               .AreNotEquals(IdPacote, Guid.Empty, "IdPacote", "Informe o Id do Pacote do comentário")
           );
        }
    }
}
