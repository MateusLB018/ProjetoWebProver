using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoWebProver.Data.Migrations
{
    public partial class TabelaPrimeiraWebRPGProver : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Personagems",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(maxLength: 100, nullable: false),
                    Idade = table.Column<int>(nullable: false),
                    Peso = table.Column<int>(nullable: false),
                    Sexo = table.Column<string>(maxLength: 1, nullable: false),
                    ItemIni = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personagems", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Armaduras",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    PersonagemId = table.Column<Guid>(nullable: false),
                    Qual = table.Column<string>(nullable: false),
                    DanoAbs = table.Column<int>(nullable: false),
                    Peso = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Armaduras", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Armaduras_Personagems_PersonagemId",
                        column: x => x.PersonagemId,
                        principalTable: "Personagems",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Armas",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    PersonagemId = table.Column<Guid>(nullable: false),
                    Dano = table.Column<int>(nullable: false),
                    Peso = table.Column<int>(nullable: false),
                    Qual = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Armas", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Armas_Personagems_PersonagemId",
                        column: x => x.PersonagemId,
                        principalTable: "Personagems",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Atributos",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    PersonagemId = table.Column<Guid>(nullable: false),
                    Inteligencia = table.Column<int>(nullable: false),
                    Força = table.Column<int>(nullable: false),
                    Fe = table.Column<int>(nullable: false),
                    Vitalidade = table.Column<int>(nullable: false),
                    Energia = table.Column<int>(nullable: false),
                    Magia = table.Column<int>(nullable: false),
                    Defesa = table.Column<int>(nullable: false),
                    Vigor = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atributos", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Atributos_Personagems_PersonagemId",
                        column: x => x.PersonagemId,
                        principalTable: "Personagems",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Poderes",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    PersonagemId = table.Column<Guid>(nullable: false),
                    Pod = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Poderes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Poderes_Personagems_PersonagemId",
                        column: x => x.PersonagemId,
                        principalTable: "Personagems",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Armaduras_PersonagemId",
                table: "Armaduras",
                column: "PersonagemId");

            migrationBuilder.CreateIndex(
                name: "IX_Armas_PersonagemId",
                table: "Armas",
                column: "PersonagemId");

            migrationBuilder.CreateIndex(
                name: "IX_Atributos_PersonagemId",
                table: "Atributos",
                column: "PersonagemId");

            migrationBuilder.CreateIndex(
                name: "IX_Poderes_PersonagemId",
                table: "Poderes",
                column: "PersonagemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Armaduras");

            migrationBuilder.DropTable(
                name: "Armas");

            migrationBuilder.DropTable(
                name: "Atributos");

            migrationBuilder.DropTable(
                name: "Poderes");

            migrationBuilder.DropTable(
                name: "Personagems");
        }
    }
}
