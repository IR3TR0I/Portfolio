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
    public class Pacote : Entidade
    {
        //As validações serão feitos em nosso Command
        private IList<Comentarios> _comentarios;
        public Pacote()
        {

        }
        public Pacote(string titulo, string imagem, string descricao,bool status, string telefone)
        {
            AddNotifications(
            new Contract<Notification>()
                .Requires()
                .IsNotNullOrEmpty(titulo, "Título", "Título não pode ser vazio")
                .IsNotNullOrEmpty(imagem, "Imagem", "Imagem não pode ser vazio")
                .IsNotNullOrEmpty(descricao, "Descrição", "Descrição não pode ser vazio")
                .IsNotNullOrEmpty(telefone, "Telefone", "Informe o Telefone para mais informações sobre o pacote")
            );

            if (IsValid)
            {
                Titulo = titulo;
                Imagem = imagem;
                Descricao = descricao;
                Status = status;
                Telefone = telefone;
            }
        }


        public string Titulo { get;private set; }
        public string Imagem { get; private set; }
        public string Descricao { get; private set; }
        public bool Status { get; private set; }
        public string Telefone { get; set; }
        public IReadOnlyCollection<Comentarios> Comentarios { get { return _comentarios.ToArray(); } }
        
         public void AdicionarComentarioPacote(Comentarios comentario)
         {
            //Metodo para usuário Comentar apenas 1 vez no pacote
            if (_comentarios.Any(x=>x.IdUsuario == comentario.IdUsuario))
            {
                AddNotification("Comentarios", "Este Usuario já Comentou!");
            }
            if (IsValid)
            {
                _comentarios.Add(comentario);
            }
         }
        public void AlterarStatus(bool status)
        {
            Status = status;
        }

        public void AlterarPacote(string titulo, string descricao)
        {
            AddNotifications(new Contract<Notification>()
                .Requires()
                .IsNotNullOrEmpty(titulo, "Titulo", "Informe o Título do pacote")
                .IsNotNullOrEmpty(descricao, "Descricao", "Informe o Descrição do pacote")
            );

            if (IsValid)
            {
                Titulo = titulo;
                Descricao = descricao;
            }
        }

        public void AlterarImagem(string imagem)
        {
            AddNotifications(new Contract<Notification>()
                .Requires()
                .IsNotNullOrEmpty(imagem, "Imagem", "Informe a imagem do pacote")
            );

            if (IsValid)
                Imagem = imagem;
        }
    }
}
