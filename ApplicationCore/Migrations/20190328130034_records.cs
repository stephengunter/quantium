using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ApplicationCore.Migrations
{
    public partial class records : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Pages",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdated",
                table: "Pages",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "Pages",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PS",
                table: "Pages",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Removed",
                table: "Pages",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Pages",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdated",
                table: "Healths",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "Healths",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PS",
                table: "Healths",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Removed",
                table: "Healths",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Healths",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Pages");

            migrationBuilder.DropColumn(
                name: "LastUpdated",
                table: "Pages");

            migrationBuilder.DropColumn(
                name: "Order",
                table: "Pages");

            migrationBuilder.DropColumn(
                name: "PS",
                table: "Pages");

            migrationBuilder.DropColumn(
                name: "Removed",
                table: "Pages");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Pages");

            migrationBuilder.DropColumn(
                name: "LastUpdated",
                table: "Healths");

            migrationBuilder.DropColumn(
                name: "Order",
                table: "Healths");

            migrationBuilder.DropColumn(
                name: "PS",
                table: "Healths");

            migrationBuilder.DropColumn(
                name: "Removed",
                table: "Healths");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Healths");
        }
    }
}
