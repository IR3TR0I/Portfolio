using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTour.Comum.CommandQueries
{
    //Padronizando saídas para o frontend via JSON
    public class GenericCommandResult : ICommandResult
    {
        public GenericCommandResult()
        {

        }
        public GenericCommandResult(bool sucesso, string mensagem, object data)
        {
            Sucesso = sucesso;
            Mensagem = mensagem;
            Data = data;
        }

        public bool Sucesso { get; set; }
        public string Mensagem { get; set; }
        public Object Data { get; set; }
    }
}
