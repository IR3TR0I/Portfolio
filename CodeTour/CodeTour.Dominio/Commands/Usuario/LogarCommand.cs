using CodeTour.Comum.CommandQueries.Command;
using Flunt.Notifications;
using Flunt.Validations;

namespace CodeTour.Dominio.Commands.Usuario
{
    public class LogarCommand : Notifiable<Notification>, ICommand
    {
        public LogarCommand(string email, string senha)
        {
            Email = email;
            Senha = senha;
        }

        public string Email { get; set; }
        public string Senha { get; set; }
        public void Validar()
        {
            AddNotifications(new Contract<Notification>()
               .Requires()
               .IsEmail(Email, "Email", "Informe um e-mail válido")
               .IsGreaterThan(Senha, 6, "Senha", "Senha deve ter no minímo 6 caracteres")
               .IsLowerOrEqualsThan(Senha, 16, "Senha", "Senha deve ter no máximo 16 caracteres")
           );
        }
    }
}
