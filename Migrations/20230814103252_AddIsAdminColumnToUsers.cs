﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FreeTimeSpenderWeb.Migrations
{
    /// <inheritdoc />
    public partial class AddIsAdminColumnToUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAdmin",
                table: "SignUpDatas",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAdmin",
                table: "SignUpDatas");
        }
    }
}
