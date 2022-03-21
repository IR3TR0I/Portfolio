using CodeTour.Comum.Entidades;
using CodeTour.Comum.Enum;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTour.Dominio.Entidades
{
    public class Usuario : Entidade
    {
        private IList<Comentarios> _comentarios;
        public Usuario(string nome, string email ,string senha, EnTipoUsuario tipoUsuario)
         {
            AddNotifications(new Contract<Notification>()
               .Requires()
               .IsGreaterOrEqualsThan(nome, 3, "Nome", "Nome deve conter pelo menos 3 caracteres")
               .IsLowerOrEqualsThan(nome, 40, "Nome", "Nome deve conter até 40 caracteres")
               .IsEmail(email, "Email", "Informe um e-mail válido")
               .IsLowerOrEqualsThan(senha, 6, "Senha", "Senha deve ter no minímo 6 caracteres")
           );
            if (IsValid)
            {

                Nome = nome;
                Email = email;
                Senha = senha;
                TipoUsuario = tipoUsuario;
                _comentarios = new List<Comentarios>();
            }
        }

        //Trabalho com Single Responsability e Open/Closed do S.O.L.I.D
        public string Nome { get; private set; }
        public string Email { get; set; }
        public string Senha { get; private set; }
        public string Telefone { get; private set; }
        public EnTipoUsuario TipoUsuario { get; private set; }

        //Composições
        //Define o tipo como IReadOnlyCollection para definir como somente leitura, usuário não poderá mexer no objeto
        public IReadOnlyCollection<Comentarios> Comentarios { get { return _comentarios.ToArray(); } }

        public void AlterarUsuario(string nome, string email)
        {
            AddNotifications(new Contract<Notification>()
               .Requires()
               .IsLowerOrEqualsThan(nome, 3, "Nome", "Nome deve conter pelo menos 3 caracteres")
               .IsGreaterOrEqualsThan(nome, 40, "Nome", "Nome deve conter até 40 caracteres")
               .IsEmail(email, "Email", "Informe um e-mail válido")
           );

            if (IsValid)
            {
                Nome = nome;
                Email = email;
            }
        }

        public void AlterarSenha(string senha)
        {
            AddNotifications(new Contract<Notification>()
                .Requires()
                .IsLowerOrEqualsThan(senha, 6, "Senha", "Senha deve ter no minímo 6 caracteres")
            );

            if (IsValid)
                Senha = senha;
        }

        public void AlterarTelefone(string telefone)
        {
            AddNotifications(new Contract<Notification>()
                .Requires()
                .IsNotNull(telefone, "Telefone", "Informe um Telefone Válido")
            );

            if (IsValid)
                Telefone = telefone;
        }
    }
}   

