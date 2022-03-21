using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Plataforma_GUFI.Domains
{
    public partial class Usuario
    {
        public Usuario()
        {
            Presencas = new HashSet<Presenca>();
        }

        public int IdUsuario { get; set; }
        public int? IdTipoUsuario { get; set; }

        //classe required define que o campo é obrigatorio
        [Required(ErrorMessage = "O Titulo do Tipo do Evento é obrigatório!!")]
        public string NomeUsuario { get; set; }

        //classe required define que o campo é obrigatorio
        [Required(ErrorMessage = "O Titulo do Tipo do Evento é obrigatório!!")]
        public string Email { get; set; }

        //classe required define que o campo é obrigatorio
        [Required(ErrorMessage = "O Titulo do Tipo do Evento é obrigatório!!")]
        public string Senha { get; set; }

        public virtual TiposUsuario IdTipoUsuarioNavigation { get; set; }
        public virtual ICollection<Presenca> Presencas { get; set; }
    }
}
