using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Modifyproperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IpAddress",
                table: "Users",
                newName: "ipAddress");

            migrationBuilder.AddColumn<double>(
                name: "speed",
                table: "Users",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "speed",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "ipAddress",
                table: "Users",
                newName: "IpAddress");
        }
    }
}
