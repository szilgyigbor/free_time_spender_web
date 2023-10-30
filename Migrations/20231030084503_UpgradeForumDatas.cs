using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FreeTimeSpenderWeb.Migrations
{
    /// <inheritdoc />
    public partial class UpgradeForumDatas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Author",
                table: "Posts",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Author",
                table: "Comments",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Author",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "Author",
                table: "Comments");
        }
    }
}
