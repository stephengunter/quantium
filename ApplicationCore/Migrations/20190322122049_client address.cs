using Microsoft.EntityFrameworkCore.Migrations;

namespace ApplicationCore.Migrations
{
    public partial class clientaddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Clients");

            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "Clients",
                newName: "Address");

            migrationBuilder.AddColumn<int>(
                name: "Region",
                table: "Clients",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Region",
                table: "Clients");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Clients",
                newName: "Phone");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Clients",
                nullable: true);
        }
    }
}
