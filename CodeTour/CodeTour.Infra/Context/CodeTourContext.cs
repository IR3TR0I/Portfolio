using CodeTour.Dominio.Entidades;
using Flunt.Notifications;
using Microsoft.EntityFrameworkCore;

namespace CodeTour.Infra.Context
{
    public class CodeTourContext : DbContext
    {
       public CodeTourContext(DbContextOptions<CodeTourContext> options) : base(options)
       {

       }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Pacote> Pacotes { get; set; }
        public DbSet<Comentarios> Comentarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<Notification>();

            #region Usuario

            modelBuilder.Entity<Usuario>().ToTable("Usuarios");
            //Defini como chave primaria
            modelBuilder.Entity<Usuario>().Property(x => x.Id);
            //Nome
            modelBuilder.Entity<Usuario>().Property(x => x.Nome).HasMaxLength(40);
            modelBuilder.Entity<Usuario>().Property(x => x.Nome).HasColumnType("varchar(40)");
            modelBuilder.Entity<Usuario>().Property(x => x.Nome).IsRequired();
            //Email
            modelBuilder.Entity<Usuario>().Property(x => x.Email).HasMaxLength(60);
            modelBuilder.Entity<Usuario>().Property(x => x.Email).HasColumnType("varchar(60)");
            modelBuilder.Entity<Usuario>().Property(x => x.Email).IsRequired();
            modelBuilder.Entity<Usuario>().HasIndex(x => x.Email).IsUnique();
            //Senha
            modelBuilder.Entity<Usuario>().Property(x => x.Senha).HasMaxLength(60);
            modelBuilder.Entity<Usuario>().Property(x => x.Senha).HasColumnType("varchar(60)");
            modelBuilder.Entity<Usuario>().Property(x => x.Senha).IsRequired();
            //Telefone
            modelBuilder.Entity<Usuario>().Property(x => x.Telefone).HasMaxLength(11);
            modelBuilder.Entity<Usuario>().Property(x => x.Telefone).HasColumnType("varchar(11)");
            //Relacionamento
            modelBuilder.Entity<Usuario>().HasMany(c => c.Comentarios).WithOne(e => e.Usuario).HasForeignKey(x => x.IdUsuario);
            //DataCriacao
            modelBuilder.Entity<Usuario>().Property(t => t.DataCriacao).HasColumnType("DateTime");
            modelBuilder.Entity<Usuario>().Property(t => t.DataCriacao).HasDefaultValueSql("GetDate()");
            //DataAlteracao
            modelBuilder.Entity<Usuario>().Property(t => t.DataAlteracao).HasColumnType("DateTime");
            modelBuilder.Entity<Usuario>().Property(t => t.DataAlteracao).HasDefaultValueSql("GetDate()");
            #endregion

            #region Pacotes
            modelBuilder.Entity<Pacote>().ToTable("Pacotes");
            //Defini como chave primaria
            modelBuilder.Entity<Pacote>().Property(x => x.Id);
            //Titulo
            modelBuilder.Entity<Pacote>().Property(x => x.Titulo).HasMaxLength(120);
            modelBuilder.Entity<Pacote>().Property(x => x.Titulo).HasColumnType("varchar(120)");
            modelBuilder.Entity<Pacote>().Property(x => x.Titulo).IsRequired();
            //Descrição
            modelBuilder.Entity<Pacote>().Property(x => x.Descricao).HasColumnType("Text");
            modelBuilder.Entity<Pacote>().Property(x => x.Descricao).IsRequired();
            //Imagem
            modelBuilder.Entity<Pacote>().Property(x => x.Imagem).HasMaxLength(250);
            modelBuilder.Entity<Pacote>().Property(x => x.Imagem).HasColumnType("varchar(250)");
            modelBuilder.Entity<Pacote>().Property(x => x.Imagem).IsRequired();
            //Ativo
            modelBuilder.Entity<Pacote>().Property(x => x.Status).HasColumnType("bit");
            //Relacionamento
            modelBuilder.Entity<Pacote>().HasMany(c => c.Comentarios).WithOne(e => e.Pacote).HasForeignKey(x => x.IdPacote);
            //DataCriacao
            modelBuilder.Entity<Usuario>().Property(t => t.DataCriacao).HasColumnType("DateTime");
            modelBuilder.Entity<Usuario>().Property(t => t.DataCriacao).HasDefaultValueSql("GetDate()");
            //DataAlteracao
            modelBuilder.Entity<Usuario>().Property(t => t.DataAlteracao).HasColumnType("DateTime");
            modelBuilder.Entity<Usuario>().Property(t => t.DataAlteracao).HasDefaultValueSql("GetDate()");
            #endregion

            #region Comentarios
            modelBuilder.Entity<Comentarios>().ToTable("Comentarios");
            //Defini como chave primaria
            modelBuilder.Entity<Comentarios>().Property(x => x.Id);
            //Texto
            modelBuilder.Entity<Comentarios>().Property(x => x.Texto).HasMaxLength(500);
            modelBuilder.Entity<Comentarios>().Property(x => x.Texto).HasColumnType("varchar(500)");
            modelBuilder.Entity<Comentarios>().Property(x => x.Texto).IsRequired();
            //Sentimento
            modelBuilder.Entity<Comentarios>().Property(x => x.Sentimento).HasMaxLength(40);
            modelBuilder.Entity<Comentarios>().Property(x => x.Sentimento).HasColumnType("varchar(40)");
            modelBuilder.Entity<Comentarios>().Property(x => x.Sentimento).IsRequired();
            //Status
            modelBuilder.Entity<Comentarios>().Property(x => x.Status).HasColumnType("int");

            //DataCriacao
            modelBuilder.Entity<Usuario>().Property(t => t.DataCriacao).HasColumnType("DateTime");
            modelBuilder.Entity<Usuario>().Property(t => t.DataCriacao).HasDefaultValueSql("GetDate()");
            //DataAlteracao
            modelBuilder.Entity<Usuario>().Property(t => t.DataAlteracao).HasColumnType("DateTime");
            modelBuilder.Entity<Usuario>().Property(t => t.DataAlteracao).HasDefaultValueSql("GetDate()");
            #endregion

            base.OnModelCreating(modelBuilder);
        }
    }
}
