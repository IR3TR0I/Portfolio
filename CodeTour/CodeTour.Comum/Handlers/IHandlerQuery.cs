using CodeTour.Comum.CommandQueries;
using CodeTour.Comum.CommandQueries.Query;

namespace CodeTour.Comum.Handlers
{
    public interface IHandlerQuery<T> where T : IQuery
    {
        ICommandResult Handle(T query);
    }
}
