using CodeTour.Comum.CommandQueries;
using CodeTour.Comum.Enum;
using CodeTour.Comum.Handlers;
using CodeTour.Dominio.Entidades;
using CodeTour.Dominio.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTour.Dominio.Queries.Pacote
{
    public class BuscarPacotePorIdQueryHandler : IHandlerQuery<BuscarPacotePorIdQuery>
    {
        private readonly IPacoteRepositorio _repositorio;

        public BuscarPacotePorIdQueryHandler(IPacoteRepositorio repositorio)
        {
            _repositorio = repositorio;
        }
        public ICommandResult Handle(BuscarPacotePorIdQuery query)
        {
            var pacote = _repositorio.BuscarPorId(query.IdPacote);

            if (pacote == null)
                return new GenericCommandResult(false, "Pacote não encontrado", null);

            var retorno = new BuscarPacotePorIdQueryResult()
            {
                Id = pacote.Id,
                Titulo = pacote.Titulo,
                Descricao = pacote.Descricao,
                Ativo = pacote.Status,
                QuantidadeComentarios = pacote.Comentarios.Count,
                Comentarios = (query.TipoUsuario == EnTipoUsuario.Admin ? GerarResultadoComentarios(pacote.Comentarios.ToList()) : GerarResultadoComentarios(pacote.Comentarios.Where(x => x.Status == EnStatusComentario.Publicado).ToList()))
            };

            return new GenericCommandResult(true, "Dados do pacote", retorno);
        }

        private List<ComentarioResult> GerarResultadoComentarios(List<Comentarios> comentarios)
        {
            return comentarios.Select(c =>
            {
                return new ComentarioResult()
                {
                    Id = c.Id,
                    Texto = c.Texto,
                    Sentimento = c.Sentimento,
                    Status = c.Status.ToString(),
                    IdUsuario = c.IdUsuario,
                    IdPacote = c.IdPacote
                };
            }).ToList();
        }
    }
}
