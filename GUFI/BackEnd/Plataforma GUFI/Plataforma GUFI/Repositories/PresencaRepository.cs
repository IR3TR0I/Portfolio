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
    public class PresencaRepository : IPresencaRepository
    {
        GufiContext ctx = new GufiContext();
        public void AprovarRecusar(int id, string status)
        {
            throw new NotImplementedException();
        }

        public void Atualizar(int id, Presenca presencaAtualizada)
        {
            Presenca presencaBuscada = ctx.Presencas.Find(id);

            if (presencaAtualizada.IdUsuario != null)
            {
                presencaBuscada.IdUsuario = presencaAtualizada.IdUsuario;
            }
            if (presencaAtualizada.IdEvento != null)
            {
                presencaAtualizada.IdEvento = presencaBuscada.IdEvento;
            }
            if (presencaAtualizada.Situacao != null)
            {
                presencaAtualizada.Situacao = presencaBuscada.Situacao;
            }
            ctx.Update(presencaBuscada);

            ctx.SaveChanges();
        }
        public Presenca BuscarPorId(int id)
        {
            return ctx.Presencas.FirstOrDefault(p => p.IdPresenca == id);

        }

        public void Cadastrar(Presenca novaPresenca)
        {
            ctx.Presencas.Add(novaPresenca);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            Presenca presencaBuscada = ctx.Presencas.Find();

            ctx.Presencas.Remove(presencaBuscada);

            ctx.SaveChanges();
        }

        public void Inscrever(Presenca inscricao)
        {
            ctx.Presencas.Add(inscricao);

            ctx.SaveChanges();
        }

        public List<Presenca> Listar()
        {
            return ctx.Presencas.ToList();
        }

        public List<Presenca> ListarMinhas(int id)
        {
            return ctx.Presencas
                // Adiciona na busca as informações do evento que o usuário participa
                .Include(p => p.IdEventoNavigation)
                // Adiciona na busca as informações do Tipo de Evento (categoria) deste evento
                .Include(p => p.IdEventoNavigation.IdTipoEventoNavigation)
                // Adiciona na busca as informações da Instituição deste evento
                .Include(p => p.IdEventoNavigation.IdinstituicaoNavigation)
                // Estabelece como parâmetro de consulta o ID do usuário recebido
                .Where(p => p.IdUsuario == id)
                .ToList();
        }
    }
}
