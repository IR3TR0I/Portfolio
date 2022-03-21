using CodeTour.Comum.CommandQueries.Command;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTour.Dominio.Commands.Usuario
{
    public class EsqueciSenhaCommand : Notifiable<Notification>, ICommand
    {
        public EsqueciSenhaCommand()
        {

        }
        public EsqueciSenhaCommand(string email)
        {
            Email = email;
        }

        public string Email { get; set; }
        public void Validar()
        {
            AddNotifications(new Contract<Notification>()
               .Requires()
               .IsEmail(Email, "Email", "Informe um e-mail válido")
           );
        }
    }
}
