using CodeTour.Dominio.Entidades;
using CodeTour.Dominio.Repositorios;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTour.Testes.Repositories
{
    public class FakeUsuarioRepositorio : Notifiable<Notification>, IUsuarioRepositorio
    {
        public void Adicionar(Usuario usuario)
        {
            if (usuario.IsValid)
                AddNotification("Usuario", "Dados inválidos");
        }

        public void Alterar(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public Usuario BuscarPorEmail(string email)
        {
            var usuario = new Usuario("Fernando Henrique", email, "1234567", Comum.Enum.EnTipoUsuario.Comum);
            if (usuario.IsValid)
                return usuario;

            AddNotification("Usuario", "Dados Inválidos");

            return usuario;
        }

        public Usuario BuscarPorId(Guid id)
        {
            var usuario = new Usuario("Fernando Henrique", "email@email.com", "1234567", Comum.Enum.EnTipoUsuario.Comum);
            if (usuario.IsValid)
                return usuario;

            AddNotification("Usuario", "Usuário não encontrado");

            return usuario;
        }

        public IEnumerable<Usuario> ListarTodos()
        {
            return new List<Usuario>();
        }
    }
}
