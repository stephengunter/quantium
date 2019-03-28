using Microsoft.EntityFrameworkCore.Migrations;

namespace ApplicationCore.Migrations
{
    public partial class edithealth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Time",
                table: "Healths",
                newName: "Duration");

            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "Healths",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Url",
                table: "Healths");

            migrationBuilder.RenameColumn(
                name: "Duration",
                table: "Healths",
                newName: "Time");
        }
    }
}
