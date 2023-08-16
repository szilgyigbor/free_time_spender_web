using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FreeTimeSpenderWeb.Migrations
{
    /// <inheritdoc />
    public partial class TimeInDouble : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "TimeInSeconds",
                table: "SortingGameDatas",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "TimeInSeconds",
                table: "SortingGameDatas",
                type: "integer",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");
        }
    }
}
