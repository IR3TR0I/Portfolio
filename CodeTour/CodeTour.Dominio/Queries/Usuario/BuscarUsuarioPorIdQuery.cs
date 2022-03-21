using CodeTour.Comum.CommandQueries.Query;
using CodeTour.Dominio.Entidades;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTour.Dominio.Queries.Usuario
{
   public class BuscarUsuarioPorIdQuery : Notifiable<Notification>, IQuery
    {
        public BuscarUsuarioPorIdQuery()
        { }

        public BuscarUsuarioPorIdQuery(Guid idUsuario)
        {
            IdUsuario = idUsuario;
        }

        public Guid IdUsuario { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract<Notification>()
                .Requires()
                .AreNotEquals(IdUsuario, Guid.Empty, "IdUsuario", "Informe o Id do Usuário do comentário")
            );
        }
    }

    public class BuscarUsuarioPorIdQueryResult
    {
        public BuscarUsuarioPorIdQueryResult()
        {
            Comentarios = new List<Comentarios>();
        }
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string TipoUsuario { get; set; }
        //Define o tipo como IReadOnlyCollection para definir como somente leitura, usuário não poderá mexer no objeto
        public int QuantidadeComentarios { get; set; }
        public ICollection<Comentarios> Comentarios { get; set; }
    }
}

