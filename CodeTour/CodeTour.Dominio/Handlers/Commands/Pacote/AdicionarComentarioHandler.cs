using CodeTour.Comum.CommandQueries;
using CodeTour.Comum.Handlers;
using CodeTour.Dominio.Commands.Pacote;
using CodeTour.Dominio.Entidades;
using CodeTour.Dominio.Repositorios;
using Flunt.Notifications;

namespace CodeTour.Dominio.Handlers.Commands.Pacote
{
    public class AdicionarComentarioHandler : Notifiable<Notification>, IHandlerCommand<AdicionarComentarioCommand>
    {
        private readonly IPacoteRepositorio _repositorio;
        public AdicionarComentarioHandler(IPacoteRepositorio repositorio)
        {
            _repositorio = repositorio;
        }
        public ICommandResult Handle(AdicionarComentarioCommand command)
        {
            command.Validar();

            if (command.IsValid)
                return new GenericCommandResult(false, "Dados inválidos", command.Notifications);

            //Verifica se titulo pacote existe
            var pacoteExiste = _repositorio.BuscarPorId(command.IdPacote);

            if (pacoteExiste == null)
                return new GenericCommandResult(false, "Pacote não encontrado", null);

            Comentarios comentario = new Comentarios(command.Texto, "", command.IdUsuario, command.IdPacote, CodeTour.Comum.Enum.EnStatusComentario.Publicado);

            if (comentario.IsValid)
                return new GenericCommandResult(false, "Dados inválidos", comentario.Notifications);

            pacoteExiste.AdicionarComentarioPacote(comentario);

            _repositorio.Alterar(pacoteExiste);

            return new GenericCommandResult(true, "Comentário Adicionado", null);
        }
    }
}
