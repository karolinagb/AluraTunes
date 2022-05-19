using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LinqToEntities.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Artista",
                columns: table => new
                {
                    ArtistaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artist", x => x.ArtistaId);
                });

            migrationBuilder.CreateTable(
                name: "Funcionario",
                columns: table => new
                {
                    FuncionarioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sobrenome = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    PrimeiroNome = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    SeReportaA = table.Column<int>(type: "int", nullable: true),
                    DataNascimento = table.Column<DateTime>(type: "datetime", nullable: true),
                    DataAdmissao = table.Column<DateTime>(type: "datetime", nullable: true),
                    Endereco = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: true),
                    Cidade = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    Pais = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    CEP = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Fone = table.Column<string>(type: "nvarchar(24)", maxLength: 24, nullable: true),
                    Fax = table.Column<string>(type: "nvarchar(24)", maxLength: 24, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionario", x => x.FuncionarioId);
                    table.ForeignKey(
                        name: "FK_FuncionarioSeReportaA",
                        column: x => x.SeReportaA,
                        principalTable: "Funcionario",
                        principalColumn: "FuncionarioId");
                });

            migrationBuilder.CreateTable(
                name: "Genero",
                columns: table => new
                {
                    GeneroId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genero", x => x.GeneroId);
                });

            migrationBuilder.CreateTable(
                name: "Playlist",
                columns: table => new
                {
                    PlaylistId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Playlist", x => x.PlaylistId);
                });

            migrationBuilder.CreateTable(
                name: "TipoMidia",
                columns: table => new
                {
                    TipoMidiaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoMidia", x => x.TipoMidiaId);
                });

            migrationBuilder.CreateTable(
                name: "Album",
                columns: table => new
                {
                    AlbumId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(160)", maxLength: 160, nullable: false),
                    ArtistaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Album", x => x.AlbumId);
                    table.ForeignKey(
                        name: "FK_AlbumArtistaId",
                        column: x => x.ArtistaId,
                        principalTable: "Artista",
                        principalColumn: "ArtistaId");
                });

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    ClienteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrimeiroNome = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Sobrenome = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Empresa = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    Endereco = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: true),
                    Cidade = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    Pais = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    CEP = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Fone = table.Column<string>(type: "nvarchar(24)", maxLength: 24, nullable: true),
                    Fax = table.Column<string>(type: "nvarchar(24)", maxLength: 24, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    SuporteId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.ClienteId);
                    table.ForeignKey(
                        name: "FK_ClienteSuporteId",
                        column: x => x.SuporteId,
                        principalTable: "Funcionario",
                        principalColumn: "FuncionarioId");
                });

            migrationBuilder.CreateTable(
                name: "Faixa",
                columns: table => new
                {
                    FaixaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    AlbumId = table.Column<int>(type: "int", nullable: true),
                    TipoMidiaId = table.Column<int>(type: "int", nullable: false),
                    GeneroId = table.Column<int>(type: "int", nullable: true),
                    Compositor = table.Column<string>(type: "nvarchar(220)", maxLength: 220, nullable: true),
                    Milissegundos = table.Column<int>(type: "int", nullable: false),
                    Bytes = table.Column<int>(type: "int", nullable: true),
                    PrecoUnitario = table.Column<decimal>(type: "numeric(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faixa", x => x.FaixaId);
                    table.ForeignKey(
                        name: "FK_FaixaAlbumId",
                        column: x => x.AlbumId,
                        principalTable: "Album",
                        principalColumn: "AlbumId");
                    table.ForeignKey(
                        name: "FK_FaixaGeneroId",
                        column: x => x.GeneroId,
                        principalTable: "Genero",
                        principalColumn: "GeneroId");
                    table.ForeignKey(
                        name: "FK_FaixaTipoMidiaId",
                        column: x => x.TipoMidiaId,
                        principalTable: "TipoMidia",
                        principalColumn: "TipoMidiaId");
                });

            migrationBuilder.CreateTable(
                name: "NotaFiscal",
                columns: table => new
                {
                    NotaFiscalId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    DataNotaFiscal = table.Column<DateTime>(type: "datetime", nullable: false),
                    Endereco = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: true),
                    Cidade = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    Pais = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    CEP = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Total = table.Column<decimal>(type: "numeric(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotaFiscal", x => x.NotaFiscalId);
                    table.ForeignKey(
                        name: "FK_NotaFiscalClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "ClienteId");
                });

            migrationBuilder.CreateTable(
                name: "PlaylistFaixa",
                columns: table => new
                {
                    PlaylistId = table.Column<int>(type: "int", nullable: false),
                    FaixaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlaylistFaixa", x => new { x.PlaylistId, x.FaixaId })
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_PlaylistFaixaFaixaId",
                        column: x => x.FaixaId,
                        principalTable: "Faixa",
                        principalColumn: "FaixaId");
                    table.ForeignKey(
                        name: "FK_PlaylistFaixaPlaylistId",
                        column: x => x.PlaylistId,
                        principalTable: "Playlist",
                        principalColumn: "PlaylistId");
                });

            migrationBuilder.CreateTable(
                name: "ItemNotaFiscal",
                columns: table => new
                {
                    ItemNotaFiscalId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NotaFiscalId = table.Column<int>(type: "int", nullable: false),
                    FaixaId = table.Column<int>(type: "int", nullable: false),
                    PrecoUnitario = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemNotaFiscal", x => x.ItemNotaFiscalId);
                    table.ForeignKey(
                        name: "FK_ItemNotaFiscalFaixaId",
                        column: x => x.FaixaId,
                        principalTable: "Faixa",
                        principalColumn: "FaixaId");
                    table.ForeignKey(
                        name: "FK_ItemNotaFiscalNotaFiscalId",
                        column: x => x.NotaFiscalId,
                        principalTable: "NotaFiscal",
                        principalColumn: "NotaFiscalId");
                });

            migrationBuilder.CreateIndex(
                name: "IFK_AlbumArtistaId",
                table: "Album",
                column: "ArtistaId");

            migrationBuilder.CreateIndex(
                name: "IFK_ClienteSuporteId",
                table: "Cliente",
                column: "SuporteId");

            migrationBuilder.CreateIndex(
                name: "IFK_FaixaAlbumId",
                table: "Faixa",
                column: "AlbumId");

            migrationBuilder.CreateIndex(
                name: "IFK_FaixaGeneroId",
                table: "Faixa",
                column: "GeneroId");

            migrationBuilder.CreateIndex(
                name: "IFK_FaixaTipoMidiaId",
                table: "Faixa",
                column: "TipoMidiaId");

            migrationBuilder.CreateIndex(
                name: "IFK_FuncionarioSeReportaA",
                table: "Funcionario",
                column: "SeReportaA");

            migrationBuilder.CreateIndex(
                name: "IFK_ItemNotaFiscalFaixaId",
                table: "ItemNotaFiscal",
                column: "FaixaId");

            migrationBuilder.CreateIndex(
                name: "IFK_ItemNotaFiscalNotaFiscalId",
                table: "ItemNotaFiscal",
                column: "NotaFiscalId");

            migrationBuilder.CreateIndex(
                name: "IFK_NotaFiscalClienteId",
                table: "NotaFiscal",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IFK_PlaylistFaixaFaixaId",
                table: "PlaylistFaixa",
                column: "FaixaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemNotaFiscal");

            migrationBuilder.DropTable(
                name: "PlaylistFaixa");

            migrationBuilder.DropTable(
                name: "NotaFiscal");

            migrationBuilder.DropTable(
                name: "Faixa");

            migrationBuilder.DropTable(
                name: "Playlist");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Album");

            migrationBuilder.DropTable(
                name: "Genero");

            migrationBuilder.DropTable(
                name: "TipoMidia");

            migrationBuilder.DropTable(
                name: "Funcionario");

            migrationBuilder.DropTable(
                name: "Artista");
        }
    }
}
