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
    public class CriarPacoteCommand : Notifiable<Notification>, ICommand
    {
        public CriarPacoteCommand()
        {

        }

        public CriarPacoteCommand(string titulo, string imagem, string descricao, bool status, string telefone)
        {
            if (IsValid)
            {
                Titulo = titulo;
                Imagem = imagem;
                Descricao = descricao;
                Status = status;
                Telefone = telefone;
            }
        }

        public string Titulo { get; set; }
        public string Imagem { get; set; }
        public string Descricao { get; set; }
        public bool Status { get; set; }
        public string Telefone { get; set; }
        public void Validar()
        {
            AddNotifications(new Contract<Notification>()
                 .Requires()
                 .IsNotNullOrEmpty(Titulo, "Titulo", "Informe o Título do pacote")
                 .IsNotNullOrEmpty(Descricao, "Descricao", "Informe o Descrição do pacote")
                 .IsNotNullOrEmpty(Imagem, "Imagem", "Informe o Imagem do pacote")
             );
        }
    }
}
