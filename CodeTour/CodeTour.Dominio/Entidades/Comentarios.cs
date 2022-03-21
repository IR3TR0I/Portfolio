using CodeTour.Comum.Entidades;
using CodeTour.Comum.Enum;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTour.Dominio.Entidades
{
    public class Comentarios : Entidade
    {
        public Comentarios(string texto, string sentimento, Guid idUsuario, Guid idPacote,EnStatusComentario status)
        {
            AddNotifications(new Contract<Notification>()
               .Requires()
               .IsNotNullOrEmpty(texto, "Texto", "Informe o Texto do comentário")
               .IsNotNullOrEmpty(sentimento, "Sentimento", "Informe o sentimento do comentário")
               .AreNotEquals(idUsuario, Guid.Empty, "IdUsuario", "Informe o Id do Usuário do comentário")
               .AreNotEquals(idPacote, Guid.Empty, "IdPacote", "Informe o Id do Pacote do comentário")
           );


            if (IsValid)
            {
                Texto = texto;
                Sentimento = sentimento;
                Status = status;
                IdUsuario = idUsuario;
                IdPacote = idPacote;
            }
        }

        public string Texto { get; private set; }
        public string Sentimento { get; private set; }
        public EnStatusComentario Status { get; private set; }


        //Composições de outras entidades
       
        public Guid IdUsuario { get; private set; }
        public virtual Usuario Usuario { get; private set; }
        public Guid IdPacote { get; private set; }
        public virtual Pacote Pacote { get; private set; }

        
    }
}
