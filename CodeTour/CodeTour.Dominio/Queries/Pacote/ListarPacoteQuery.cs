using CodeTour.Comum.CommandQueries.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTour.Dominio.Queries.Pacote
{
    public class ListarPacoteQuery : IQuery
    {
        public bool? Ativo { get; set; } = null;
        public void Validate()
        {

        }
    }

    public class ListarQueryResult
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Imagem { get; set; }
        public bool Status { get; set; }
        public int QuantidadeComentarios { get; set; }
    }
}
