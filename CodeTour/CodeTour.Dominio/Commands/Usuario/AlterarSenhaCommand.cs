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
    public class AlterarSenhaCommand : Notifiable<Notification>, ICommand
    {
        public AlterarSenhaCommand()
        {

        }
        public AlterarSenhaCommand(Guid idUsuario, string senha)
        {
            IdUsuario = idUsuario;
            Senha = senha;
        }

        public Guid IdUsuario { get; set; }
        public string Senha { get; set; }
        public void Validar()
        {
            AddNotifications(new Contract<Notification>()
                .Requires()
                .AreNotEquals(IdUsuario, Guid.Empty, "IdUsuario", "Id do usuário inválido")
                .IsLowerThan(Senha, 6, "Senha", "Senha deve ter no minímo 6 caracteres")
            );
        }
    }
}
