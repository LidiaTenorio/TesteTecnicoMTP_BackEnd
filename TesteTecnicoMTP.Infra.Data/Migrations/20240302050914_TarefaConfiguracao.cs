using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TesteTecnicoMTP.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class TarefaConfiguracao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DataCadastro",
                table: "Tarefas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 2, 5, 9, 14, 911, DateTimeKind.Utc).AddTicks(1436),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 3, 2, 5, 5, 57, 891, DateTimeKind.Utc).AddTicks(7129));

            migrationBuilder.AlterColumn<bool>(
                name: "Concluido",
                table: "Tarefas",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DataCadastro",
                table: "Tarefas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 2, 5, 5, 57, 891, DateTimeKind.Utc).AddTicks(7129),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 3, 2, 5, 9, 14, 911, DateTimeKind.Utc).AddTicks(1436));

            migrationBuilder.AlterColumn<bool>(
                name: "Concluido",
                table: "Tarefas",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);
        }
    }
}
