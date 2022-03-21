using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable
//CLASSE QUE REPRESENTA A ENTIDADE/Tabela TIPOS EVENTO
namespace Plataforma_GUFI.Domains
{
    public partial class TiposEvento
    {
        public TiposEvento()
        {
            Eventos = new HashSet<Evento>();
        }

        public int IdTipoEvento { get; set; }


        //classe required define que o campo é obrigatorio
        [Required(ErrorMessage = "O Titulo do Tipo do Evento é obrigatório!!")]
        public string TituloTipoEvento { get; set; }

        public virtual ICollection<Evento> Eventos { get; set; }
    }
}
