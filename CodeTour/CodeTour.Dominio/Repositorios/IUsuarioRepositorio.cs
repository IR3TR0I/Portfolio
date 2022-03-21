using CodeTour.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTour.Dominio.Repositorios
{
   public interface IUsuarioRepositorio
    {
        void Adicionar(Usuario usuario);
        void Alterar(Usuario usuario);
        Usuario BuscarPorEmail(string email);
        Usuario BuscarPorId(Guid id);
        IEnumerable<Usuario> ListarTodos();
    }
}
