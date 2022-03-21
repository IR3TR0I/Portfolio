using CodeTour.Comum.CommandQueries;
using CodeTour.Comum.Handlers;
using CodeTour.Dominio.Queries.Usuario;
using CodeTour.Dominio.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTour.Dominio.Queries.Usuarios
{
    public class BuscarUsuarioPorIdQueryHandler : IHandlerQuery<BuscarUsuarioPorIdQuery>
    {
        private readonly IUsuarioRepositorio _repositorio;

        public BuscarUsuarioPorIdQueryHandler(IUsuarioRepositorio repositorio)
        {
            _repositorio = repositorio;
        }
        public ICommandResult Handle(BuscarUsuarioPorIdQuery query)
        {
            var usuario = _repositorio.BuscarPorId(query.IdUsuario);

            var retorno = new BuscarUsuarioPorIdQueryResult()
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Email = usuario.Email,
                Telefone = usuario.Telefone,
                QuantidadeComentarios = usuario.Comentarios.Count,
                Comentarios = usuario.Comentarios.ToList()
            };

            return new GenericCommandResult(true, "Dados do usuário", retorno);
        }
    }
}
