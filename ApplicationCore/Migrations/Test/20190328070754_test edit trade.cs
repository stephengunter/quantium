using Microsoft.EntityFrameworkCore.Migrations;

namespace ApplicationCore.Migrations.Test
{
    public partial class testedittrade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Shares",
                table: "Trades",
                nullable: false,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Shares",
                table: "Trades",
                nullable: false,
                oldClrType: typeof(decimal));
        }
    }
}
