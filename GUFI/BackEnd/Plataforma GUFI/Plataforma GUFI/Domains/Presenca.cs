using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Plataforma_GUFI.Domains
{
    public partial class Presenca
    {
        public int IdPresenca { get; set; }
        public int? IdUsuario { get; set; }
        public int? IdEvento { get; set; }

        [Required(ErrorMessage = "A situação da presença é obrigatória!")]
        public string Situacao { get; set; }

        public virtual Evento IdEventoNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
