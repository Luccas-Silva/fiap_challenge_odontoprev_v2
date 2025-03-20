using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace C__Challenge_v2.Migrations
{
    /// <inheritdoc />
    public partial class intitdb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbV2_Usuario",
                columns: table => new
                {
                    IdUsuario = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    CpfCnpj = table.Column<string>(type: "NVARCHAR2(20)", maxLength: 20, nullable: false),
                    Nome = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: false),
                    DataNascimento = table.Column<string>(type: "NVARCHAR2(10)", nullable: false),
                    Email = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: false),
                    Celular = table.Column<string>(type: "NVARCHAR2(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbV2_Usuario", x => x.IdUsuario);
                });

            migrationBuilder.CreateTable(
                name: "tbV2_Cliente",
                columns: table => new
                {
                    IdCliente = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    Cep = table.Column<string>(type: "NVARCHAR2(10)", maxLength: 10, nullable: false),
                    TipoPlano = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    UsuarioId = table.Column<Guid>(type: "RAW(16)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbV2_Cliente", x => x.IdCliente);
                    table.ForeignKey(
                        name: "FK_tbV2_Cliente_tbV2_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "tbV2_Usuario",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbV2_Dentista",
                columns: table => new
                {
                    IdDentista = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    CepClinica = table.Column<string>(type: "NVARCHAR2(10)", maxLength: 10, nullable: false),
                    NomeClinica = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    TipoClinica = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    AlvaraFuncionamento = table.Column<string>(type: "NVARCHAR2(1)", nullable: false),
                    SiteRedesSocial = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: false),
                    UsuarioId = table.Column<Guid>(type: "RAW(16)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbV2_Dentista", x => x.IdDentista);
                    table.ForeignKey(
                        name: "FK_tbV2_Dentista_tbV2_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "tbV2_Usuario",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbV2_Consulta",
                columns: table => new
                {
                    IdConsulta = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    DateConsulta = table.Column<string>(type: "NVARCHAR2(10)", nullable: false),
                    TipoConsulta = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    ValorMedioConsulta = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    DentistaCpfCnpj = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DentistaIdDentista = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    ClienteCpfCnpj = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    ClienteIdCliente = table.Column<Guid>(type: "RAW(16)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbV2_Consulta", x => x.IdConsulta);
                    table.ForeignKey(
                        name: "FK_tbV2_Consulta_tbV2_Cliente_ClienteIdCliente",
                        column: x => x.ClienteIdCliente,
                        principalTable: "tbV2_Cliente",
                        principalColumn: "IdCliente",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbV2_Consulta_tbV2_Dentista_DentistaIdDentista",
                        column: x => x.DentistaIdDentista,
                        principalTable: "tbV2_Dentista",
                        principalColumn: "IdDentista",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbV2_Cliente_UsuarioId",
                table: "tbV2_Cliente",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_tbV2_Consulta_ClienteIdCliente",
                table: "tbV2_Consulta",
                column: "ClienteIdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_tbV2_Consulta_DentistaIdDentista",
                table: "tbV2_Consulta",
                column: "DentistaIdDentista");

            migrationBuilder.CreateIndex(
                name: "IX_tbV2_Dentista_UsuarioId",
                table: "tbV2_Dentista",
                column: "UsuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbV2_Consulta");

            migrationBuilder.DropTable(
                name: "tbV2_Cliente");

            migrationBuilder.DropTable(
                name: "tbV2_Dentista");

            migrationBuilder.DropTable(
                name: "tbV2_Usuario");
        }
    }
}
