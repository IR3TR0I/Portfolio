using Plataforma_GUFI.Contexts;
using Plataforma_GUFI.Domains;
using Plataforma_GUFI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Plataforma_GUFI.Repositories
{
    //Puxando TiposEvento Repository para Implementarmos os métodos
    public class TiposEventoRepository : ITiposEventoRepository
    {
        /// <summary>
        /// Objeto contexto por onde serão chamados os métodos do EF Core
        /// </summary>
        GufiContext ctx = new GufiContext();

        public void Atualizar(int id, TiposEvento tipoEventoAtualizado)
        {
            //Buscando um tipo de evento atraves do seu ID USANDO FIND

            TiposEvento tipoEventoBuscado = ctx.TiposEventos.Find(id);

            //verificando se o titulo foi encontrado com condicional if
            if (tipoEventoAtualizado.TituloTipoEvento != null) //!= Operador Relacional "Diferente De"
            {
                //atribuindo novo valor ao campo que ´já existe
                tipoEventoBuscado.TituloTipoEvento = tipoEventoAtualizado.TituloTipoEvento;
            }

            //atualizando o tipo de evento buscado
            ctx.TiposEventos.Update(tipoEventoBuscado);//metodo de atualizar puxado

            //agora salvando as alteracoes
            ctx.SaveChanges();
        }

        public TiposEvento BuscarPorId(int id)
        {
            //retornar o primeiro tipo de evento para o id informado igual USANdO FIRSTORDEFAULT COM lambda
            return ctx.TiposEventos.FirstOrDefault(te => te.IdTipoEvento == id);//usando expressao lambda
        }

        public void Cadastrar(TiposEvento novoTipoEvento)
        {
            //adicionando novo tipo de evento USANDO ADD()
            ctx.TiposEventos.Add(novoTipoEvento);
            //Salvando
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            //deletando um tipo de evento
            //buscar usando método FIND(id)
            TiposEvento tiposEventoBuscado = ctx.TiposEventos.Find(id);
            //removendo
            ctx.TiposEventos.Remove(tiposEventoBuscado);
            //salvando no banco
            ctx.SaveChanges();
        }

        public List<TiposEvento> Listar()
        {
            //Listar e Retornar usando metodo ToList
            return ctx.TiposEventos.ToList();
        }
    }
}
