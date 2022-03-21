using CodeTour.Comum.CommandQueries.Command;
using CodeTour.Comum.Enum;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Implementando a metodológia CQRS(Command Query Responsability Segregation)
namespace CodeTour.Dominio.Commands.Usuario
{
    public class CriarContaCommand : Notifiable<Notification>, ICommand
    {
        public CriarContaCommand()
        {

        }
        public CriarContaCommand(string nome, string email, string senha, EnTipoUsuario tipoUsuario, string telefone)
        {
            Nome = nome;
            Email = email;
            Senha = senha;
            TipoUsuario = tipoUsuario;
            Telefone = telefone;
        }

        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public EnTipoUsuario TipoUsuario { get; set; }
        public string Telefone { get; set; }
        public void Validar()
        {
            AddNotifications(
            new Contract<Notification>()
                .Requires()
                .IsGreaterOrEqualsThan(Nome, 3, "Nome", "Nome deve conter pelo menos 3 caracteres")
                .IsLowerOrEqualsThan(Nome, 40, "Nome", "Nome deve conter até 40 caracteres")
                .IsEmail(Email, "Email", "Informe um e-mail válido")
                .IsLowerOrEqualsThan(Senha, 6, "Senha", "Senha deve ter no minímo 6 caracteres")
            );
        }
    }
}
