using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Plataforma_GUFI.Domains;

#nullable disable

namespace Plataforma_GUFI.Contexts
{
    public partial class GufiContext : DbContext
    {
        public GufiContext()
        {
        }

        public GufiContext(DbContextOptions<GufiContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Evento> Eventos { get; set; }
        public virtual DbSet<Instituico> Instituicoes { get; set; }
        public virtual DbSet<Presenca> Presencas { get; set; }
        public virtual DbSet<TiposEvento> TiposEventos { get; set; }
        public virtual DbSet<TiposUsuario> TiposUsuarios { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-FQM2QUJ\\SQLEXPRESS; initial catalog=GUFI_Senai; user Id=sa; pwd=senai@132;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Evento>(entity =>
            {
                entity.HasKey(e => e.IdEvento)
                    .HasName("PK__Eventos__034EFC0492F80ED4");

                entity.Property(e => e.AcessoLivre)
                    .HasColumnName("acessoLivre")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.DataEvento).HasColumnType("date");

                entity.Property(e => e.Descricao)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.NomeEvento)
                    .IsRequired()
                    .HasMaxLength(225)
                    .IsUnicode(false)
                    .HasColumnName("nomeEvento");

                entity.HasOne(d => d.IdTipoEventoNavigation)
                    .WithMany(p => p.Eventos)
                    .HasForeignKey(d => d.IdTipoEvento)
                    .HasConstraintName("FK__Eventos__IdTipoE__44FF419A");

                entity.HasOne(d => d.IdinstituicaoNavigation)
                    .WithMany(p => p.Eventos)
                    .HasForeignKey(d => d.Idinstituicao)
                    .HasConstraintName("FK__Eventos__Idinsti__45F365D3");
            });

            modelBuilder.Entity<Instituico>(entity =>
            {
                entity.HasKey(e => e.Idinstituicao)
                    .HasName("PK__Institui__C0945792B2AC1A47");

                entity.HasIndex(e => e.Endereco, "UQ__Institui__4DF3E1FFED4DE0A5")
                    .IsUnique();

                entity.HasIndex(e => e.Cnpj, "UQ__Institui__AA57D6B409E6D337")
                    .IsUnique();

                entity.HasIndex(e => e.NomeFantasia, "UQ__Institui__F5389F31686563CE")
                    .IsUnique();

                entity.Property(e => e.Cnpj)
                    .IsRequired()
                    .HasMaxLength(14)
                    .IsUnicode(false)
                    .HasColumnName("CNPJ")
                    .IsFixedLength(true);

                entity.Property(e => e.Endereco)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.NomeFantasia)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Presenca>(entity =>
            {
                entity.HasKey(e => e.IdPresenca)
                    .HasName("PK__Presenca__50FB6F5D81AF1F17");

                entity.Property(e => e.Situacao)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("situacao");

                entity.HasOne(d => d.IdEventoNavigation)
                    .WithMany(p => p.Presencas)
                    .HasForeignKey(d => d.IdEvento)
                    .HasConstraintName("FK__Presencas__IdEve__4AB81AF0");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Presencas)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__Presencas__IdUsu__49C3F6B7");
            });

            modelBuilder.Entity<TiposEvento>(entity =>
            {
                entity.HasKey(e => e.IdTipoEvento)
                    .HasName("PK__TiposEve__CDB3A3BEB193A9BD");

                entity.HasIndex(e => e.TituloTipoEvento, "UQ__TiposEve__D2A1CBBB48791158")
                    .IsUnique();

                entity.Property(e => e.TituloTipoEvento)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("tituloTipoEvento");
            });

            modelBuilder.Entity<TiposUsuario>(entity =>
            {
                entity.HasKey(e => e.IdTipoUsuario)
                    .HasName("PK__TiposUsu__CA04062B25C3A30A");

                entity.ToTable("TiposUsuario");

                entity.HasIndex(e => e.TituloTipoUsuario, "UQ__TiposUsu__C6B29FC369BBF28C")
                    .IsUnique();

                entity.Property(e => e.TituloTipoUsuario)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("tituloTipoUsuario");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__Usuarios__5B65BF976E27E0A3");

                entity.HasIndex(e => e.Email, "UQ__Usuarios__A9D10534315BDF3E")
                    .IsUnique();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NomeUsuario)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(220)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdTipoUsuarioNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdTipoUsuario)
                    .HasConstraintName("FK__Usuarios__IdTipo__3A81B327");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
