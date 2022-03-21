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
    public class AlterarPacoteCommand : Notifiable<Notification>, ICommand
    {
        public AlterarPacoteCommand()
        {

        }
        public AlterarPacoteCommand(string titulo, string descricao, Guid idPacote)
        {
            Titulo = titulo;
            Descricao = descricao;
            IdPacote = idPacote;
        }

        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public Guid IdPacote { get; set; }
        public void Validar()
        {
            AddNotifications(new Contract<Notification>()
               .Requires()
               .AreNotEquals(IdPacote, Guid.Empty, "IdPacote", "Id do pacote inválido")
               .IsNotNullOrEmpty(Titulo, "Titulo", "Informe o Título do pacote")
               .IsNotNullOrEmpty(Descricao, "Descricao", "Informe a Descrição do pacote")
           );
        }
    }
}
