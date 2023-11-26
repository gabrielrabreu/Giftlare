using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Giftlare.Infra.DbMigrations.Migrations
{
    /// <inheritdoc />
    public partial class ConvertingInvitationTokenToGuid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "InviteToken",
                table: "Gathering",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "InviteToken",
                table: "Gathering",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");
        }
    }
}
