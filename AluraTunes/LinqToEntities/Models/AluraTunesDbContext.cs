using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace LinqToEntities.Models
{
    public partial class AluraTunesDbContext : DbContext
    {
        public AluraTunesDbContext()
        {
        }

        public AluraTunesDbContext(DbContextOptions<AluraTunesDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Album> Albums { get; set; } = null!;
        public virtual DbSet<Artistum> Artista { get; set; } = null!;
        public virtual DbSet<Cliente> Clientes { get; set; } = null!;
        public virtual DbSet<Faixa> Faixas { get; set; } = null!;
        public virtual DbSet<Funcionario> Funcionarios { get; set; } = null!;
        public virtual DbSet<Genero> Generos { get; set; } = null!;
        public virtual DbSet<ItemNotaFiscal> ItemNotaFiscals { get; set; } = null!;
        public virtual DbSet<NotaFiscal> NotaFiscals { get; set; } = null!;
        public virtual DbSet<Playlist> Playlists { get; set; } = null!;
        public virtual DbSet<TipoMidium> TipoMidia { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\projetos\\AluraTunes\\AluraTunes\\LinqToEntities\\Data\\AluraTunes.mdf;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Album>(entity =>
            {
                entity.ToTable("Album");

                entity.HasIndex(e => e.ArtistaId, "IFK_AlbumArtistaId");

                entity.Property(e => e.Titulo).HasMaxLength(160);

                entity.HasOne(d => d.Artista)
                    .WithMany(p => p.Albums)
                    .HasForeignKey(d => d.ArtistaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AlbumArtistaId");
            });

            modelBuilder.Entity<Artistum>(entity =>
            {
                entity.HasKey(e => e.ArtistaId)
                    .HasName("PK_Artist");

                entity.Property(e => e.Nome).HasMaxLength(120);
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.ToTable("Cliente");

                entity.HasIndex(e => e.SuporteId, "IFK_ClienteSuporteId");

                entity.Property(e => e.Cep)
                    .HasMaxLength(10)
                    .HasColumnName("CEP");

                entity.Property(e => e.Cidade).HasMaxLength(40);

                entity.Property(e => e.Email).HasMaxLength(60);

                entity.Property(e => e.Empresa).HasMaxLength(80);

                entity.Property(e => e.Endereco).HasMaxLength(70);

                entity.Property(e => e.Estado).HasMaxLength(40);

                entity.Property(e => e.Fax).HasMaxLength(24);

                entity.Property(e => e.Fone).HasMaxLength(24);

                entity.Property(e => e.Pais).HasMaxLength(40);

                entity.Property(e => e.PrimeiroNome).HasMaxLength(40);

                entity.Property(e => e.Sobrenome).HasMaxLength(20);

                entity.HasOne(d => d.Suporte)
                    .WithMany(p => p.Clientes)
                    .HasForeignKey(d => d.SuporteId)
                    .HasConstraintName("FK_ClienteSuporteId");
            });

            modelBuilder.Entity<Faixa>(entity =>
            {
                entity.ToTable("Faixa");

                entity.HasIndex(e => e.AlbumId, "IFK_FaixaAlbumId");

                entity.HasIndex(e => e.GeneroId, "IFK_FaixaGeneroId");

                entity.HasIndex(e => e.TipoMidiaId, "IFK_FaixaTipoMidiaId");

                entity.Property(e => e.Compositor).HasMaxLength(220);

                entity.Property(e => e.Nome).HasMaxLength(200);

                entity.Property(e => e.PrecoUnitario).HasColumnType("numeric(10, 2)");

                entity.HasOne(d => d.Album)
                    .WithMany(p => p.Faixas)
                    .HasForeignKey(d => d.AlbumId)
                    .HasConstraintName("FK_FaixaAlbumId");

                entity.HasOne(d => d.Genero)
                    .WithMany(p => p.Faixas)
                    .HasForeignKey(d => d.GeneroId)
                    .HasConstraintName("FK_FaixaGeneroId");

                entity.HasOne(d => d.TipoMidia)
                    .WithMany(p => p.Faixas)
                    .HasForeignKey(d => d.TipoMidiaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FaixaTipoMidiaId");
            });

            modelBuilder.Entity<Funcionario>(entity =>
            {
                entity.ToTable("Funcionario");

                entity.HasIndex(e => e.SeReportaA, "IFK_FuncionarioSeReportaA");

                entity.Property(e => e.Cep)
                    .HasMaxLength(10)
                    .HasColumnName("CEP");

                entity.Property(e => e.Cidade).HasMaxLength(40);

                entity.Property(e => e.DataAdmissao).HasColumnType("datetime");

                entity.Property(e => e.DataNascimento).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(60);

                entity.Property(e => e.Endereco).HasMaxLength(70);

                entity.Property(e => e.Estado).HasMaxLength(40);

                entity.Property(e => e.Fax).HasMaxLength(24);

                entity.Property(e => e.Fone).HasMaxLength(24);

                entity.Property(e => e.Pais).HasMaxLength(40);

                entity.Property(e => e.PrimeiroNome).HasMaxLength(20);

                entity.Property(e => e.Sobrenome).HasMaxLength(20);

                entity.Property(e => e.Titulo).HasMaxLength(30);

                entity.HasOne(d => d.SeReportaANavigation)
                    .WithMany(p => p.InverseSeReportaANavigation)
                    .HasForeignKey(d => d.SeReportaA)
                    .HasConstraintName("FK_FuncionarioSeReportaA");
            });

            modelBuilder.Entity<Genero>(entity =>
            {
                entity.ToTable("Genero");

                entity.Property(e => e.Nome).HasMaxLength(120);
            });

            modelBuilder.Entity<ItemNotaFiscal>(entity =>
            {
                entity.ToTable("ItemNotaFiscal");

                entity.HasIndex(e => e.FaixaId, "IFK_ItemNotaFiscalFaixaId");

                entity.HasIndex(e => e.NotaFiscalId, "IFK_ItemNotaFiscalNotaFiscalId");

                entity.Property(e => e.PrecoUnitario).HasColumnType("numeric(10, 2)");

                entity.HasOne(d => d.Faixa)
                    .WithMany(p => p.ItemNotaFiscals)
                    .HasForeignKey(d => d.FaixaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ItemNotaFiscalFaixaId");

                entity.HasOne(d => d.NotaFiscal)
                    .WithMany(p => p.ItemNotaFiscals)
                    .HasForeignKey(d => d.NotaFiscalId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ItemNotaFiscalNotaFiscalId");
            });

            modelBuilder.Entity<NotaFiscal>(entity =>
            {
                entity.ToTable("NotaFiscal");

                entity.HasIndex(e => e.ClienteId, "IFK_NotaFiscalClienteId");

                entity.Property(e => e.Cep)
                    .HasMaxLength(10)
                    .HasColumnName("CEP");

                entity.Property(e => e.Cidade).HasMaxLength(40);

                entity.Property(e => e.DataNotaFiscal).HasColumnType("datetime");

                entity.Property(e => e.Endereco).HasMaxLength(70);

                entity.Property(e => e.Estado).HasMaxLength(40);

                entity.Property(e => e.Pais).HasMaxLength(40);

                entity.Property(e => e.Total).HasColumnType("numeric(10, 2)");

                entity.HasOne(d => d.Cliente)
                    .WithMany(p => p.NotaFiscals)
                    .HasForeignKey(d => d.ClienteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NotaFiscalClienteId");
            });

            modelBuilder.Entity<Playlist>(entity =>
            {
                entity.ToTable("Playlist");

                entity.Property(e => e.Nome).HasMaxLength(120);

                entity.HasMany(d => d.Faixas)
                    .WithMany(p => p.Playlists)
                    .UsingEntity<Dictionary<string, object>>(
                        "PlaylistFaixa",
                        l => l.HasOne<Faixa>().WithMany().HasForeignKey("FaixaId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_PlaylistFaixaFaixaId"),
                        r => r.HasOne<Playlist>().WithMany().HasForeignKey("PlaylistId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_PlaylistFaixaPlaylistId"),
                        j =>
                        {
                            j.HasKey("PlaylistId", "FaixaId").IsClustered(false);

                            j.ToTable("PlaylistFaixa");

                            j.HasIndex(new[] { "FaixaId" }, "IFK_PlaylistFaixaFaixaId");
                        });
            });

            modelBuilder.Entity<TipoMidium>(entity =>
            {
                entity.HasKey(e => e.TipoMidiaId);

                entity.Property(e => e.Nome).HasMaxLength(120);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
