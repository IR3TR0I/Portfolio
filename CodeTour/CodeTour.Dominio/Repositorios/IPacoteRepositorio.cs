using CodeTour.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTour.Dominio.Repositorios
{
   public interface IPacoteRepositorio
    {
        void Adicionar(Pacote pacote);
        void Alterar(Pacote pacote);
        IEnumerable<Pacote> Listar(bool? ativo = null);
        Pacote BuscarPorTitulo(string titulo);
        Pacote BuscarPorId(Guid id);
    }
}
