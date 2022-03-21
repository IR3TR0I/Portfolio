using Plataforma_GUFI.Contexts;
using Plataforma_GUFI.Domains;
using Plataforma_GUFI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Plataforma_GUFI.Repositories
{
    public class TiposUsuarioRepository : ITiposUsuarioRepository
    {
        GufiContext ctx = new GufiContext();
        public void Atualizar(int id, TiposUsuario tipoUsuarioAtualizado)
        {
            TiposUsuario tiposUsuarioBuscado = ctx.TiposUsuarios.Find(id);

            if (tiposUsuarioBuscado.TituloTipoUsuario != null)
            {
                tiposUsuarioBuscado.TituloTipoUsuario = tipoUsuarioAtualizado.TituloTipoUsuario;
            }

            ctx.TiposUsuarios.Update(tiposUsuarioBuscado);

            ctx.SaveChanges();
        }

        public TiposUsuario BuscarPorId(int id)
        {
            return ctx.TiposUsuarios.FirstOrDefault(tu => tu.IdTipoUsuario == id);
        }

        public void Cadastrar(TiposUsuario novoTipoUsuario)
        {
            //Criando
            ctx.TiposUsuarios.Add(novoTipoUsuario);
            //salvando
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            //buscando
            TiposUsuario tiposUsuarioBuscado = ctx.TiposUsuarios.Find(id);
            //Removendo
            ctx.TiposUsuarios.Remove(tiposUsuarioBuscado);
        }

        public List<TiposUsuario> Listar()
        {
            //Retornando
            return ctx.TiposUsuarios.ToList();
        }
    }
}
