﻿// <auto-generated />
using System;
using LinqToEntities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LinqToEntities.Migrations
{
    [DbContext(typeof(AluraTunesDbContext))]
    partial class CPROJETOSALURATUNESALURATUNESLINQTOENTITIESDATAALURATUNESMDFContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("LinqToEntities.Models.Album", b =>
                {
                    b.Property<int>("AlbumId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AlbumId"), 1L, 1);

                    b.Property<int>("ArtistaId")
                        .HasColumnType("int");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasMaxLength(160)
                        .HasColumnType("nvarchar(160)");

                    b.HasKey("AlbumId");

                    b.HasIndex(new[] { "ArtistaId" }, "IFK_AlbumArtistaId");

                    b.ToTable("Album", (string)null);
                });

            modelBuilder.Entity("LinqToEntities.Models.Artistum", b =>
                {
                    b.Property<int>("ArtistaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ArtistaId"), 1L, 1);

                    b.Property<string>("Nome")
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.HasKey("ArtistaId")
                        .HasName("PK_Artist");

                    b.ToTable("Artista");
                });

            modelBuilder.Entity("LinqToEntities.Models.Cliente", b =>
                {
                    b.Property<int>("ClienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClienteId"), 1L, 1);

                    b.Property<string>("Cep")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)")
                        .HasColumnName("CEP");

                    b.Property<string>("Cidade")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("Empresa")
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<string>("Endereco")
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)");

                    b.Property<string>("Estado")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("Fax")
                        .HasMaxLength(24)
                        .HasColumnType("nvarchar(24)");

                    b.Property<string>("Fone")
                        .HasMaxLength(24)
                        .HasColumnType("nvarchar(24)");

                    b.Property<string>("Pais")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("PrimeiroNome")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("Sobrenome")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int?>("SuporteId")
                        .HasColumnType("int");

                    b.HasKey("ClienteId");

                    b.HasIndex(new[] { "SuporteId" }, "IFK_ClienteSuporteId");

                    b.ToTable("Cliente", (string)null);
                });

            modelBuilder.Entity("LinqToEntities.Models.Faixa", b =>
                {
                    b.Property<int>("FaixaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FaixaId"), 1L, 1);

                    b.Property<int?>("AlbumId")
                        .HasColumnType("int");

                    b.Property<int?>("Bytes")
                        .HasColumnType("int");

                    b.Property<string>("Compositor")
                        .HasMaxLength(220)
                        .HasColumnType("nvarchar(220)");

                    b.Property<int?>("GeneroId")
                        .HasColumnType("int");

                    b.Property<int>("Milissegundos")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<decimal>("PrecoUnitario")
                        .HasColumnType("numeric(10,2)");

                    b.Property<int>("TipoMidiaId")
                        .HasColumnType("int");

                    b.HasKey("FaixaId");

                    b.HasIndex(new[] { "AlbumId" }, "IFK_FaixaAlbumId");

                    b.HasIndex(new[] { "GeneroId" }, "IFK_FaixaGeneroId");

                    b.HasIndex(new[] { "TipoMidiaId" }, "IFK_FaixaTipoMidiaId");

                    b.ToTable("Faixa", (string)null);
                });

            modelBuilder.Entity("LinqToEntities.Models.Funcionario", b =>
                {
                    b.Property<int>("FuncionarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FuncionarioId"), 1L, 1);

                    b.Property<string>("Cep")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)")
                        .HasColumnName("CEP");

                    b.Property<string>("Cidade")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<DateTime?>("DataAdmissao")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("DataNascimento")
                        .HasColumnType("datetime");

                    b.Property<string>("Email")
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("Endereco")
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)");

                    b.Property<string>("Estado")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("Fax")
                        .HasMaxLength(24)
                        .HasColumnType("nvarchar(24)");

                    b.Property<string>("Fone")
                        .HasMaxLength(24)
                        .HasColumnType("nvarchar(24)");

                    b.Property<string>("Pais")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("PrimeiroNome")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int?>("SeReportaA")
                        .HasColumnType("int");

                    b.Property<string>("Sobrenome")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Titulo")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("FuncionarioId");

                    b.HasIndex(new[] { "SeReportaA" }, "IFK_FuncionarioSeReportaA");

                    b.ToTable("Funcionario", (string)null);
                });

            modelBuilder.Entity("LinqToEntities.Models.Genero", b =>
                {
                    b.Property<int>("GeneroId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GeneroId"), 1L, 1);

                    b.Property<string>("Nome")
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.HasKey("GeneroId");

                    b.ToTable("Genero", (string)null);
                });

            modelBuilder.Entity("LinqToEntities.Models.ItemNotaFiscal", b =>
                {
                    b.Property<int>("ItemNotaFiscalId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ItemNotaFiscalId"), 1L, 1);

                    b.Property<int>("FaixaId")
                        .HasColumnType("int");

                    b.Property<int>("NotaFiscalId")
                        .HasColumnType("int");

                    b.Property<decimal>("PrecoUnitario")
                        .HasColumnType("numeric(10,2)");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.HasKey("ItemNotaFiscalId");

                    b.HasIndex(new[] { "FaixaId" }, "IFK_ItemNotaFiscalFaixaId");

                    b.HasIndex(new[] { "NotaFiscalId" }, "IFK_ItemNotaFiscalNotaFiscalId");

                    b.ToTable("ItemNotaFiscal", (string)null);
                });

            modelBuilder.Entity("LinqToEntities.Models.NotaFiscal", b =>
                {
                    b.Property<int>("NotaFiscalId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NotaFiscalId"), 1L, 1);

                    b.Property<string>("Cep")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)")
                        .HasColumnName("CEP");

                    b.Property<string>("Cidade")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataNotaFiscal")
                        .HasColumnType("datetime");

                    b.Property<string>("Endereco")
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)");

                    b.Property<string>("Estado")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("Pais")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<decimal>("Total")
                        .HasColumnType("numeric(10,2)");

                    b.HasKey("NotaFiscalId");

                    b.HasIndex(new[] { "ClienteId" }, "IFK_NotaFiscalClienteId");

                    b.ToTable("NotaFiscal", (string)null);
                });

            modelBuilder.Entity("LinqToEntities.Models.Playlist", b =>
                {
                    b.Property<int>("PlaylistId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PlaylistId"), 1L, 1);

                    b.Property<string>("Nome")
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.HasKey("PlaylistId");

                    b.ToTable("Playlist", (string)null);
                });

            modelBuilder.Entity("LinqToEntities.Models.TipoMidium", b =>
                {
                    b.Property<int>("TipoMidiaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TipoMidiaId"), 1L, 1);

                    b.Property<string>("Nome")
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.HasKey("TipoMidiaId");

                    b.ToTable("TipoMidia");
                });

            modelBuilder.Entity("PlaylistFaixa", b =>
                {
                    b.Property<int>("PlaylistId")
                        .HasColumnType("int");

                    b.Property<int>("FaixaId")
                        .HasColumnType("int");

                    b.HasKey("PlaylistId", "FaixaId");

                    SqlServerKeyBuilderExtensions.IsClustered(b.HasKey("PlaylistId", "FaixaId"), false);

                    b.HasIndex(new[] { "FaixaId" }, "IFK_PlaylistFaixaFaixaId");

                    b.ToTable("PlaylistFaixa", (string)null);
                });

            modelBuilder.Entity("LinqToEntities.Models.Album", b =>
                {
                    b.HasOne("LinqToEntities.Models.Artistum", "Artista")
                        .WithMany("Albums")
                        .HasForeignKey("ArtistaId")
                        .IsRequired()
                        .HasConstraintName("FK_AlbumArtistaId");

                    b.Navigation("Artista");
                });

            modelBuilder.Entity("LinqToEntities.Models.Cliente", b =>
                {
                    b.HasOne("LinqToEntities.Models.Funcionario", "Suporte")
                        .WithMany("Clientes")
                        .HasForeignKey("SuporteId")
                        .HasConstraintName("FK_ClienteSuporteId");

                    b.Navigation("Suporte");
                });

            modelBuilder.Entity("LinqToEntities.Models.Faixa", b =>
                {
                    b.HasOne("LinqToEntities.Models.Album", "Album")
                        .WithMany("Faixas")
                        .HasForeignKey("AlbumId")
                        .HasConstraintName("FK_FaixaAlbumId");

                    b.HasOne("LinqToEntities.Models.Genero", "Genero")
                        .WithMany("Faixas")
                        .HasForeignKey("GeneroId")
                        .HasConstraintName("FK_FaixaGeneroId");

                    b.HasOne("LinqToEntities.Models.TipoMidium", "TipoMidia")
                        .WithMany("Faixas")
                        .HasForeignKey("TipoMidiaId")
                        .IsRequired()
                        .HasConstraintName("FK_FaixaTipoMidiaId");

                    b.Navigation("Album");

                    b.Navigation("Genero");

                    b.Navigation("TipoMidia");
                });

            modelBuilder.Entity("LinqToEntities.Models.Funcionario", b =>
                {
                    b.HasOne("LinqToEntities.Models.Funcionario", "SeReportaANavigation")
                        .WithMany("InverseSeReportaANavigation")
                        .HasForeignKey("SeReportaA")
                        .HasConstraintName("FK_FuncionarioSeReportaA");

                    b.Navigation("SeReportaANavigation");
                });

            modelBuilder.Entity("LinqToEntities.Models.ItemNotaFiscal", b =>
                {
                    b.HasOne("LinqToEntities.Models.Faixa", "Faixa")
                        .WithMany("ItemNotaFiscals")
                        .HasForeignKey("FaixaId")
                        .IsRequired()
                        .HasConstraintName("FK_ItemNotaFiscalFaixaId");

                    b.HasOne("LinqToEntities.Models.NotaFiscal", "NotaFiscal")
                        .WithMany("ItemNotaFiscals")
                        .HasForeignKey("NotaFiscalId")
                        .IsRequired()
                        .HasConstraintName("FK_ItemNotaFiscalNotaFiscalId");

                    b.Navigation("Faixa");

                    b.Navigation("NotaFiscal");
                });

            modelBuilder.Entity("LinqToEntities.Models.NotaFiscal", b =>
                {
                    b.HasOne("LinqToEntities.Models.Cliente", "Cliente")
                        .WithMany("NotaFiscals")
                        .HasForeignKey("ClienteId")
                        .IsRequired()
                        .HasConstraintName("FK_NotaFiscalClienteId");

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("PlaylistFaixa", b =>
                {
                    b.HasOne("LinqToEntities.Models.Faixa", null)
                        .WithMany()
                        .HasForeignKey("FaixaId")
                        .IsRequired()
                        .HasConstraintName("FK_PlaylistFaixaFaixaId");

                    b.HasOne("LinqToEntities.Models.Playlist", null)
                        .WithMany()
                        .HasForeignKey("PlaylistId")
                        .IsRequired()
                        .HasConstraintName("FK_PlaylistFaixaPlaylistId");
                });

            modelBuilder.Entity("LinqToEntities.Models.Album", b =>
                {
                    b.Navigation("Faixas");
                });

            modelBuilder.Entity("LinqToEntities.Models.Artistum", b =>
                {
                    b.Navigation("Albums");
                });

            modelBuilder.Entity("LinqToEntities.Models.Cliente", b =>
                {
                    b.Navigation("NotaFiscals");
                });

            modelBuilder.Entity("LinqToEntities.Models.Faixa", b =>
                {
                    b.Navigation("ItemNotaFiscals");
                });

            modelBuilder.Entity("LinqToEntities.Models.Funcionario", b =>
                {
                    b.Navigation("Clientes");

                    b.Navigation("InverseSeReportaANavigation");
                });

            modelBuilder.Entity("LinqToEntities.Models.Genero", b =>
                {
                    b.Navigation("Faixas");
                });

            modelBuilder.Entity("LinqToEntities.Models.NotaFiscal", b =>
                {
                    b.Navigation("ItemNotaFiscals");
                });

            modelBuilder.Entity("LinqToEntities.Models.TipoMidium", b =>
                {
                    b.Navigation("Faixas");
                });
#pragma warning restore 612, 618
        }
    }
}
