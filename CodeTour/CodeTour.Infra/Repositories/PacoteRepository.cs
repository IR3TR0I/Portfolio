using CodeTour.Dominio.Entidades;
using CodeTour.Dominio.Repositorios;
using CodeTour.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;


namespace CodeTour.Infra.Repositories
{
    public class PacoteRepository : IPacoteRepositorio
    {
        private readonly CodeTourContext _context;

        public PacoteRepository(CodeTourContext context)
        {
            _context = context;
        }

        public void Adicionar(Pacote pacote)
        {
            _context.Pacotes.Add(pacote);
            _context.SaveChanges();
        }

        public void Alterar(Pacote pacote)
        {
            _context.Entry(pacote).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public Pacote BuscarPorId(Guid id)
        {
            return _context.Pacotes
              .AsNoTracking()
              .Include(p => p.Comentarios)
              .FirstOrDefault(x => x.Id == id);
        }

        public Pacote BuscarPorTitulo(string titulo)
        {
            return _context.Pacotes
              .AsNoTracking()
              .Include(p => p.Comentarios)
              .FirstOrDefault(x => x.Titulo == titulo);
        }

        public IEnumerable<Pacote> Listar(bool? ativo = null)
        {
            if (ativo == null)
                return _context.Pacotes
                  .AsNoTracking()
                  .Include(p => p.Comentarios)
                  .OrderBy(x => x.DataCriacao);
            else
                return _context.Pacotes
                  .AsNoTracking()
                  .Include(p => p.Comentarios)
                  .Where(p => p.Status == ativo)
                  .OrderBy(x => x.DataCriacao);
        }
    }
}
