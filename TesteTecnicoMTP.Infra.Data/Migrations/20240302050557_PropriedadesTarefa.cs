using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TesteTecnicoMTP.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class PropriedadesTarefa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DataCadastro",
                table: "Tarefas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 2, 5, 5, 57, 891, DateTimeKind.Utc).AddTicks(7129),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GETUTCDATE()");

            migrationBuilder.AlterColumn<bool>(
                name: "Ativo",
                table: "Tarefas",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataAtualizacao",
                table: "Tarefas",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataAtualizacao",
                table: "Tarefas");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataCadastro",
                table: "Tarefas",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETUTCDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 3, 2, 5, 5, 57, 891, DateTimeKind.Utc).AddTicks(7129));

            migrationBuilder.AlterColumn<bool>(
                name: "Ativo",
                table: "Tarefas",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);
        }
    }
}
