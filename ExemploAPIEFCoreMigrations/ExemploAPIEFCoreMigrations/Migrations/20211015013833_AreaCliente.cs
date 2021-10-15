using Microsoft.EntityFrameworkCore.Migrations;

namespace ExemploAPIEFCoreMigrations.Migrations
{
    public partial class AreaCliente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AreaId",
                table: "Cliente",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Area",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Area", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_AreaId",
                table: "Cliente",
                column: "AreaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cliente_Area_AreaId",
                table: "Cliente",
                column: "AreaId",
                principalTable: "Area",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cliente_Area_AreaId",
                table: "Cliente");

            migrationBuilder.DropTable(
                name: "Area");

            migrationBuilder.DropIndex(
                name: "IX_Cliente_AreaId",
                table: "Cliente");

            migrationBuilder.DropColumn(
                name: "AreaId",
                table: "Cliente");
        }
    }
}
