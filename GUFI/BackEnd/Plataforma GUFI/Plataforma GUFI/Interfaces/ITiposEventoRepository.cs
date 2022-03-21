using Plataforma_GUFI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Plataforma_GUFI.Interfaces
{   //Aqui onde aplicamos o CRUD
    //Interface responsável pelos tiposeventoRepository
    interface ITiposEventoRepository
    {
        //Read/Listar
        List<TiposEvento> Listar();
        //Busca um tipo de evento pelo seu ID
        TiposEvento BuscarPorId(int id);
        //CREATE/Cadastrar
        /// <summary>
        /// Cadastra um novo tipo de evento
        /// </summary>
        /// <param name="novoTipoEvento">Objeto novoTipoEvento que será cadastrado</param>
        void Cadastrar(TiposEvento novoTipoEvento);
        /// <summary>
        /// Atualiza um tipo de evento existente
        /// </summary>
        /// <param name="id">ID do tipo de evento que será atualizado</param>
        /// <param name="tipoEventoAtualizado">Objeto com as novas informações</param>
        void Atualizar(int id, TiposEvento tipoEventoAtualizado);

        //Deletar Por /Delete
        void Deletar(int id);
    }
}
