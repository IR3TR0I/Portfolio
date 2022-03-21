using CodeTour.Comum.CommandQueries;
using CodeTour.Comum.Handlers;
using CodeTour.Dominio.Queries.Usuario;
using CodeTour.Dominio.Repositorios;
using System.Linq;

namespace CodeTour.Dominio.Queries.Usuarios
{
    public class ListarUsuarioQueryHandler : IHandlerQuery<ListarUsuarioQuery>
    {
        private readonly IUsuarioRepositorio _repositorio;

        public ListarUsuarioQueryHandler(IUsuarioRepositorio repositorio)
        {
            _repositorio = repositorio;
        }
        public ICommandResult Handle(ListarUsuarioQuery command)
        {
            var query = _repositorio.ListarTodos();

            var usuarios = query.Select(
                x =>
                {
                    return new ListarQueryResult()
                    {
                        Id = x.Id,
                        Nome = x.Nome,
                        Email = x.Email,
                        Telefone = x.Telefone,
                        TipoUsuario = x.TipoUsuario.ToString(),
                        QuantidadeComentarios = x.Comentarios.Count
                    };
                }
            );

            return new GenericCommandResult(true, "Usuários", usuarios);
        }
    }
}
