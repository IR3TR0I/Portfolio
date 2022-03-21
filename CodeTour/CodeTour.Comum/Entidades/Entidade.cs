using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTour.Comum.Entidades
{
    public abstract class Entidade : Notifiable<Notification>, IEquatable<Entidade>
    {
        protected Entidade()
        {
            Id = Guid.NewGuid();
            DataCriacao = DateTime.Now;
        }

        public Guid Id { get; private set; }
        public DateTime DataCriacao { get; private set; }
        public DateTime DataAlteracao { get; private set; }

        //Verifica se um Id é igual ao que esta recebendo
        public bool Equals([AllowNull] Entidade other)
        {
            return Id == other.Id;
        }
    }
}
