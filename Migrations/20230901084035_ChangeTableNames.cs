using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FreeTimeSpenderWeb.Migrations
{
    /// <inheritdoc />
    public partial class ChangeTableNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "MessageDatas",
                newName: "OpinionDatas");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "OpinionDatas",
                newName: "MessageDatas");
        }
    }
}
