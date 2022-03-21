using Plataforma_GUFI.Contexts;
using Plataforma_GUFI.Domains;
using Plataforma_GUFI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Plataforma_GUFI.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        GufiContext ctx = new GufiContext();
        public void Atualizar(int id, Usuario usuarioAtualizado)
        {
            Usuario usuarioBuscado = ctx.Usuarios.Find(id);
            if (usuarioBuscado.NomeUsuario != null)
            {
                usuarioBuscado.NomeUsuario = usuarioBuscado.NomeUsuario;
            }
        }

        public Usuario BuscarPorId(int id)
        {
            return ctx.Usuarios
                 .Select(u => new Usuario()
                 {
                     IdUsuario = u.IdUsuario,
                     NomeUsuario = u.NomeUsuario,
                     Email = u.Email,
                     IdTipoUsuario = u.IdTipoUsuario,

                     IdTipoUsuarioNavigation = new TiposUsuario()
                     {
                         IdTipoUsuario = u.IdTipoUsuarioNavigation.IdTipoUsuario,
                         TituloTipoUsuario = u.IdTipoUsuarioNavigation.TituloTipoUsuario
                     }
                 })
                 .FirstOrDefault(u => u.IdTipoUsuario == id);
        }

        public void Cadastrar(Usuario novoUsuario)
        {
            ctx.Usuarios.Add(novoUsuario);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            ctx.Usuarios.Remove(BuscarPorId(id));

            ctx.SaveChanges();
        }

        public List<Usuario> Listar()
        {
            return ctx.Usuarios
                .Select(u => new Usuario()
                {
                    IdUsuario = u.IdUsuario,
                    NomeUsuario = u.NomeUsuario,
                    Email = u.Email,
                    IdTipoUsuario = u.IdTipoUsuario,

                    IdTipoUsuarioNavigation = new TiposUsuario()
                    {
                        IdTipoUsuario = u.IdTipoUsuarioNavigation.IdTipoUsuario,
                        TituloTipoUsuario = u.IdTipoUsuarioNavigation.TituloTipoUsuario
                    }
                })
                .ToList();
        }

        public Usuario Login(string email, string senha)
        {
            return ctx.Usuarios.FirstOrDefault(u => u.Email == email && u.Senha == senha);
        }
    }
}
