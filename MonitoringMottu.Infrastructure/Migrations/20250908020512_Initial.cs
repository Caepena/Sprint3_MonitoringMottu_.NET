using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MonitoringMottu.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GARAGEM",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    ENDERECO = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    CAPACIDADE = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    RESPONSAVEL = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GARAGEM", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Moto",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    MODELO = table.Column<string>(type: "NVARCHAR2(15)", maxLength: 15, nullable: false),
                    MARCA = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    COR = table.Column<string>(type: "NVARCHAR2(10)", maxLength: 10, nullable: false),
                    PLACA = table.Column<string>(type: "NVARCHAR2(7)", maxLength: 7, nullable: false),
                    STATUS = table.Column<string>(type: "NVARCHAR2(15)", maxLength: 15, nullable: false),
                    IdGaragem = table.Column<Guid>(type: "RAW(16)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Moto", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Moto_GARAGEM_IdGaragem",
                        column: x => x.IdGaragem,
                        principalTable: "GARAGEM",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Moto_IdGaragem",
                table: "Moto",
                column: "IdGaragem");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Moto");

            migrationBuilder.DropTable(
                name: "GARAGEM");
        }
    }
}
