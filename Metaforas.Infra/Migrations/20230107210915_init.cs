using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Metaforas.Infra.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pensadores",
                columns: table => new
                {
                    IdPensador = table.Column<Guid>(type: "uuid", nullable: false),
                    IdUsuario = table.Column<Guid>(type: "uuid", nullable: false),
                    Nome = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Ativo = table.Column<bool>(type: "boolean", nullable: false),
                    UsuarioCriacao = table.Column<Guid>(type: "uuid", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UsuarioAlteracao = table.Column<Guid>(type: "uuid", nullable: true),
                    DataAlteracao = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UsuarioInativacao = table.Column<Guid>(type: "uuid", nullable: true),
                    DataInativacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pensadores", x => x.IdPensador);
                });

            migrationBuilder.CreateTable(
                name: "Times",
                columns: table => new
                {
                    IdTime = table.Column<Guid>(type: "uuid", nullable: false),
                    Nome = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Ativo = table.Column<bool>(type: "boolean", nullable: false),
                    UsuarioCriacao = table.Column<Guid>(type: "uuid", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UsuarioAlteracao = table.Column<Guid>(type: "uuid", nullable: true),
                    DataAlteracao = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UsuarioInativacao = table.Column<Guid>(type: "uuid", nullable: true),
                    DataInativacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Times", x => x.IdTime);
                });

            migrationBuilder.CreateTable(
                name: "Frases",
                columns: table => new
                {
                    IdFrase = table.Column<Guid>(type: "uuid", nullable: false),
                    IdPensador = table.Column<Guid>(type: "uuid", nullable: false),
                    IdTime = table.Column<Guid>(type: "uuid", nullable: false),
                    FraseTexto = table.Column<string>(type: "VARCHAR", maxLength: 500, nullable: false),
                    Ativo = table.Column<bool>(type: "boolean", nullable: false),
                    UsuarioCriacao = table.Column<Guid>(type: "uuid", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UsuarioAlteracao = table.Column<Guid>(type: "uuid", nullable: true),
                    DataAlteracao = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UsuarioInativacao = table.Column<Guid>(type: "uuid", nullable: true),
                    DataInativacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Frases", x => x.IdFrase);
                    table.ForeignKey(
                        name: "FK_Frases_Pensadores_IdPensador",
                        column: x => x.IdPensador,
                        principalTable: "Pensadores",
                        principalColumn: "IdPensador",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Frases_Times_IdTime",
                        column: x => x.IdTime,
                        principalTable: "Times",
                        principalColumn: "IdTime",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PensadorTimes",
                columns: table => new
                {
                    IdPensadorTime = table.Column<Guid>(type: "uuid", nullable: false),
                    IdPensador = table.Column<Guid>(type: "uuid", nullable: false),
                    IdTime = table.Column<Guid>(type: "uuid", nullable: false),
                    Ativo = table.Column<bool>(type: "boolean", nullable: false),
                    UsuarioCriacao = table.Column<Guid>(type: "uuid", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UsuarioAlteracao = table.Column<Guid>(type: "uuid", nullable: true),
                    DataAlteracao = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UsuarioInativacao = table.Column<Guid>(type: "uuid", nullable: true),
                    DataInativacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PensadorTimes", x => x.IdPensadorTime);
                    table.ForeignKey(
                        name: "FK_PensadorTimes_Pensadores_IdPensador",
                        column: x => x.IdPensador,
                        principalTable: "Pensadores",
                        principalColumn: "IdPensador",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PensadorTimes_Times_IdTime",
                        column: x => x.IdTime,
                        principalTable: "Times",
                        principalColumn: "IdTime",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Frases_IdPensador",
                table: "Frases",
                column: "IdPensador");

            migrationBuilder.CreateIndex(
                name: "IX_Frases_IdTime",
                table: "Frases",
                column: "IdTime");

            migrationBuilder.CreateIndex(
                name: "IX_Pensadores_IdUsuario",
                table: "Pensadores",
                column: "IdUsuario",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PensadorTimes_IdPensador",
                table: "PensadorTimes",
                column: "IdPensador");

            migrationBuilder.CreateIndex(
                name: "IX_PensadorTimes_IdTime",
                table: "PensadorTimes",
                column: "IdTime");

            migrationBuilder.CreateIndex(
                name: "IX_Times_Nome",
                table: "Times",
                column: "Nome",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Frases");

            migrationBuilder.DropTable(
                name: "PensadorTimes");

            migrationBuilder.DropTable(
                name: "Pensadores");

            migrationBuilder.DropTable(
                name: "Times");
        }
    }
}
