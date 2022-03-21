using CodeTour.Comum.CommandQueries;
using CodeTour.Comum.Handlers;
using CodeTour.Dominio.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTour.Dominio.Queries.Pacote
{
    public class ListarPacoteQueryHandler : IHandlerQuery<ListarPacoteQuery>
    {
        private readonly IPacoteRepositorio _repositorio;

        public ListarPacoteQueryHandler(IPacoteRepositorio repositorio)
        {
            _repositorio = repositorio;
        }
        public ICommandResult Handle(ListarPacoteQuery query)
        {
            var pacotes = _repositorio.Listar(query.Ativo);

            var Pacotes = pacotes.Select(
                x =>
                {
                    return new ListarQueryResult()
                    {
                        Id = x.Id,
                        Titulo = x.Titulo,
                        Descricao = x.Descricao,
                        Status = x.Status,
                        QuantidadeComentarios = x.Comentarios.Count
                    };
                }
            );

            return new GenericCommandResult(true, "Usuários", Pacotes);
        }
    }
}
