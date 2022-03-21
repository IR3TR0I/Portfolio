using CodeTour.Comum.CommandQueries.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTour.Dominio.Queries.Usuario
{
    public class ListarUsuarioQuery : IQuery
    {
        public void Validate()
        {

        }
    }

    public class ListarQueryResult
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string TipoUsuario { get; set; }
        public int QuantidadeComentarios { get; set; }
    }
}
