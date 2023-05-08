using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoginAppData.Migrations
{
    /// <inheritdoc />
    public partial class ListItemsDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "account_type",
                table: "accounts",
                newName: "Admin_status");

            migrationBuilder.AddColumn<bool>(
                name: "completed",
                table: "todoitems",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "completed",
                table: "todoitems");

            migrationBuilder.RenameColumn(
                name: "Admin_status",
                table: "accounts",
                newName: "account_type");
        }
    }
}
