using Microsoft.EntityFrameworkCore;
using Plataforma_GUFI.Contexts;
using Plataforma_GUFI.Domains;
using Plataforma_GUFI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Plataforma_GUFI.Repositories
{
    public class EventoRepository : IEventoRepository
    {
        GufiContext ctx = new GufiContext();
        public void Atualizar(int id, Evento eventoAtualizado)
        {
            Evento eventoBuscado = ctx.Eventos.Find(id);

            if (eventoAtualizado.NomeEvento != null)
            {
                eventoBuscado.NomeEvento = eventoAtualizado.NomeEvento;
            }

            if (eventoAtualizado.IdTipoEvento != null)
            {
                eventoBuscado.IdTipoEvento = eventoAtualizado.IdTipoEvento;
            }

            if (eventoAtualizado.IdTipoEvento > 0)
            {
                eventoBuscado.IdTipoEvento = eventoAtualizado.IdTipoEvento;
            }
            if (eventoAtualizado.Descricao != null)
            {
                eventoBuscado.Descricao = eventoAtualizado.Descricao;
            }
            if (eventoAtualizado.DataEvento >= DateTime.Today)
            {
                eventoBuscado.DataEvento = eventoAtualizado.DataEvento;
            }
            ctx.Eventos.Update(eventoBuscado);

            ctx.SaveChanges();
        }

        public Evento BuscarPorId(int id)
        {
            return ctx.Eventos.FirstOrDefault(e => e.IdEvento == id);
        }

        public void Cadastrar(Evento novoEvento)
        {
            ctx.Eventos.Add(novoEvento);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            ctx.Eventos.Remove(BuscarPorId(id));

            ctx.SaveChanges();
        }

        public List<Evento> Listar()
        {
            return ctx.Eventos
                // Adiciona na busca as informações do tipo de evento
                .Include(e => e.IdTipoEventoNavigation)
                // Adiciona na busca as informações da instituição
                .Include(e => e.IdinstituicaoNavigation)
                .ToList();
        }
    }
}
