using Microsoft.EntityFrameworkCore.Migrations;

namespace ApplicationCore.Migrations.Test
{
    public partial class testeditmarket : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Market",
                table: "Assets",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Market",
                table: "Assets",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
