using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Plataforma_GUFI.Domains
{
    public partial class Instituico
    {
        public Instituico()
        {
            Eventos = new HashSet<Evento>();
        }

        public int Idinstituicao { get; set; }

        [Required(ErrorMessage = "Informe o nome fantasia")]
        public string NomeFantasia { get; set; }

        [Required(ErrorMessage = "Informe o CNPJ da instituição")]
        public string Cnpj { get; set; }

        [Required(ErrorMessage = "Informe o endereço")]
        public string Endereco { get; set; }

        public virtual ICollection<Evento> Eventos { get; set; }
    }
}
