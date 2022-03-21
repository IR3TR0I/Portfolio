using CodeTour.Comum.CommandQueries;
using CodeTour.Comum.CommandQueries.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CodeTour.Comum.Handlers
{
    public interface IHandlerCommand<T> where T : ICommand
    {
        ICommandResult Handle(T command);
    }
}
