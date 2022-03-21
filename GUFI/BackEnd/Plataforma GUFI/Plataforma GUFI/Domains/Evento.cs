using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Plataforma_GUFI.Domains
{
    public partial class Evento
    {
        public Evento()
        {
            Presencas = new HashSet<Presenca>();
        }

        public int IdEvento { get; set; }
        public int? IdTipoEvento { get; set; }
        public int? Idinstituicao { get; set; }

        [Required(ErrorMessage = "Informe o título do evento")]
        public string NomeEvento { get; set; }
        public bool? AcessoLivre { get; set; }

        [Required(ErrorMessage = "Informe a data do evento")]
        public DateTime DataEvento { get; set; }

        [Required(ErrorMessage = "Informe a descrição do evento")]
        public string Descricao { get; set; }

        public virtual TiposEvento IdTipoEventoNavigation { get; set; }
        public virtual Instituico IdinstituicaoNavigation { get; set; }
        public virtual ICollection<Presenca> Presencas { get; set; }
    }
}
