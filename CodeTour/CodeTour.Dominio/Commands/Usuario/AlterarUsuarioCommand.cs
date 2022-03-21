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
    public class AlterarUsuarioCommand : Notifiable<Notification>, ICommand
    {
        public AlterarUsuarioCommand()
        {
            
        }
        public AlterarUsuarioCommand(string nome, string email, string telefone, Guid idUsuario)
        {
            Nome = nome;
            Email = email;
            Telefone = telefone;
            IdUsuario = idUsuario;
        }

        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public Guid IdUsuario { get; set; }
        public void Validar()
        {
            AddNotifications(new Contract<Notification>()
                .Requires()
                .IsGreaterThan(Nome, 3, "Nome", "Nome deve conter pelo menos 3 caracteres")
                .IsLowerOrEqualsThan(Nome, 40, "Nome", "Nome deve conter até 40 caracteres")
                .IsEmail(Email, "Email", "Informe um e-mail válido")
            );
        }
    }
}
