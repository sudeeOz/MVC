using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestOBS.Migrations
{
    /// <inheritdoc />
    public partial class Again : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Department",
                table: "Admins",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Phone",
                table: "Admins",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Department",
                table: "Admins");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Admins");
        }
    }
}
