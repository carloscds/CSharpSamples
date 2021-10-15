using Microsoft.EntityFrameworkCore.Migrations;

namespace ExemploAPIEFCoreMigrations.Migrations
{
    public partial class AreaClienteNull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cliente_Area_AreaId",
                table: "Cliente");

            migrationBuilder.AlterColumn<int>(
                name: "AreaId",
                table: "Cliente",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Cliente_Area_AreaId",
                table: "Cliente",
                column: "AreaId",
                principalTable: "Area",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cliente_Area_AreaId",
                table: "Cliente");

            migrationBuilder.AlterColumn<int>(
                name: "AreaId",
                table: "Cliente",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Cliente_Area_AreaId",
                table: "Cliente",
                column: "AreaId",
                principalTable: "Area",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
