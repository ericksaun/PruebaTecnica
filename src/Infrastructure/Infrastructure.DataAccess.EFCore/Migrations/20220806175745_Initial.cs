using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.DataAccess.EFCore.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "clientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cl_contraseña = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cl_estado = table.Column<bool>(type: "bit", nullable: false),
                    pr_id_persona = table.Column<int>(type: "int", nullable: false),
                    pr_nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    pr_genero = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    pr_edad = table.Column<int>(type: "int", nullable: false),
                    pr_identificacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    pr_telefono = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "cuentas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cu_numero_cuenta = table.Column<int>(type: "int", nullable: false),
                    cu_tipo_cuenta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cu_saldo_inicial = table.Column<double>(type: "float", nullable: false),
                    cu_estado = table.Column<bool>(type: "bit", nullable: false),
                    clienteId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cuentas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_cuentas_clientes_clienteId",
                        column: x => x.clienteId,
                        principalTable: "clientes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "movimientos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    mo_fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    mo_tipo_movimiento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    valor = table.Column<int>(type: "int", nullable: false),
                    mo_saldo = table.Column<double>(type: "float", nullable: false),
                    cuentaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_movimientos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_movimientos_cuentas_cuentaId",
                        column: x => x.cuentaId,
                        principalTable: "cuentas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_cuentas_clienteId",
                table: "cuentas",
                column: "clienteId");

            migrationBuilder.CreateIndex(
                name: "IX_movimientos_cuentaId",
                table: "movimientos",
                column: "cuentaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "movimientos");

            migrationBuilder.DropTable(
                name: "cuentas");

            migrationBuilder.DropTable(
                name: "clientes");
        }
    }
}
