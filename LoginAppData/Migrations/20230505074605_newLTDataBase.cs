using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoginAppData.Migrations
{
    /// <inheritdoc />
    public partial class newLTDataBase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "safety_word",
                table: "accounts",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "safety_word",
                table: "accounts");
        }
    }
}
