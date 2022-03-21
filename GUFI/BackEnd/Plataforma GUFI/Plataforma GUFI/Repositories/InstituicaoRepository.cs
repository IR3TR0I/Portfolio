using Plataforma_GUFI.Contexts;
using Plataforma_GUFI.Domains;
using Plataforma_GUFI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Plataforma_GUFI.Repositories
{
    public class InstituicaoRepository : IInstituicaoRepository
    {
        GufiContext ctx = new GufiContext();
        public void Atualizar(int id, Instituico instituicaoAtualizada)
        {
            Instituico instituicoBuscada = ctx.Instituicoes.Find(id);

            //CNPJ
            if (instituicoBuscada.Cnpj != null)
            {
                instituicaoAtualizada.Cnpj = instituicoBuscada.Cnpj;
            }
            if (instituicoBuscada.Endereco != null)
            {
                instituicaoAtualizada.Endereco = instituicoBuscada.Endereco;
            }
            if (instituicoBuscada.NomeFantasia != null)
            {
                instituicaoAtualizada.NomeFantasia = instituicoBuscada.NomeFantasia;
            }
            ctx.Instituicoes.Update(instituicoBuscada);

            ctx.SaveChanges();
        }

        public Instituico BuscarPorId(int id)
        {
            return ctx.Instituicoes.FirstOrDefault(i => i.Idinstituicao == id);
        }

        public void Cadastrar(Instituico novaInstituicao)
        {
            ctx.Instituicoes.Add(novaInstituicao);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {

            ctx.Instituicoes.Remove(BuscarPorId(id));

            ctx.SaveChanges();
        }

        public List<Instituico> Listar()
        {
            return ctx.Instituicoes.ToList();
        }
    }
}
