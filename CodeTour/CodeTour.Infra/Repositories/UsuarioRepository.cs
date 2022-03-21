using CodeTour.Dominio.Entidades;
using CodeTour.Dominio.Repositorios;
using CodeTour.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeTour.Infra.Repositories
{
    public class UsuarioRepository : IUsuarioRepositorio
    {
        private readonly CodeTourContext _context;

        public UsuarioRepository(CodeTourContext context)
        {
            _context = context;
        }

        public void Adicionar(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
        }

        public void Alterar(Usuario usuario)
        {
            _context.Entry(usuario).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public Usuario BuscarPorEmail(string email)
        {
            return _context
                .Usuarios
                .FirstOrDefault(x => x.Email == email);
        }

        public Usuario BuscarPorId(Guid id)
        {
            return _context
                .Usuarios
                .AsNoTracking()
                .Include(x => x.Comentarios)
                .FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Usuario> ListarTodos()
        {
            return _context.Usuarios
                .AsNoTracking()
                .Include(x => x.Comentarios)
                .OrderBy(x => x.DataCriacao);
        }
    }
}
