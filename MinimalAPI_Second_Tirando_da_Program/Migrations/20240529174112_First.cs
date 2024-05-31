using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MinimalAPI_Second_Tirando_da_Program.Migrations
{
    /// <inheritdoc />
    public partial class First : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Assuntos",
                columns: table => new
                {
                    CodAs = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Codl = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CodAu = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assuntos", x => x.CodAs);
                });

            migrationBuilder.CreateTable(
                name: "Autores",
                columns: table => new
                {
                    CodAu = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Codl = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CodAs = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autores", x => x.CodAu);
                    table.ForeignKey(
                        name: "FK_Autores_Assuntos_CodAs",
                        column: x => x.CodAs,
                        principalTable: "Assuntos",
                        principalColumn: "CodAs");
                });

            migrationBuilder.CreateTable(
                name: "Livros",
                columns: table => new
                {
                    Codl = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CodAu = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CodAs = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Editora = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Edicao = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Image_Address = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    AnoPublicacao = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Livros", x => x.Codl);
                    table.ForeignKey(
                        name: "FK_Livros_Assuntos_CodAs",
                        column: x => x.CodAs,
                        principalTable: "Assuntos",
                        principalColumn: "CodAs");
                    table.ForeignKey(
                        name: "FK_Livros_Autores_CodAu",
                        column: x => x.CodAu,
                        principalTable: "Autores",
                        principalColumn: "CodAu");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Assuntos_CodAu",
                table: "Assuntos",
                column: "CodAu");

            migrationBuilder.CreateIndex(
                name: "IX_Assuntos_Codl",
                table: "Assuntos",
                column: "Codl");

            migrationBuilder.CreateIndex(
                name: "IX_Autores_CodAs",
                table: "Autores",
                column: "CodAs");

            migrationBuilder.CreateIndex(
                name: "IX_Livros_CodAs",
                table: "Livros",
                column: "CodAs");

            migrationBuilder.CreateIndex(
                name: "IX_Livros_CodAu",
                table: "Livros",
                column: "CodAu");

            migrationBuilder.AddForeignKey(
                name: "FK_Assuntos_Autores_CodAu",
                table: "Assuntos",
                column: "CodAu",
                principalTable: "Autores",
                principalColumn: "CodAu");

            migrationBuilder.AddForeignKey(
                name: "FK_Assuntos_Livros_Codl",
                table: "Assuntos",
                column: "Codl",
                principalTable: "Livros",
                principalColumn: "Codl");

            migrationBuilder.AddForeignKey(
                name: "FK_Autores_Livros_CodAu",
                table: "Autores",
                column: "CodAu",
                principalTable: "Livros",
                principalColumn: "Codl");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assuntos_Autores_CodAu",
                table: "Assuntos");

            migrationBuilder.DropForeignKey(
                name: "FK_Livros_Autores_CodAu",
                table: "Livros");

            migrationBuilder.DropForeignKey(
                name: "FK_Assuntos_Livros_Codl",
                table: "Assuntos");

            migrationBuilder.DropTable(
                name: "Autores");

            migrationBuilder.DropTable(
                name: "Livros");

            migrationBuilder.DropTable(
                name: "Assuntos");
        }
    }
}
