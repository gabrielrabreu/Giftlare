using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Giftlare.Infra.DbMigrations.Migrations
{
    /// <inheritdoc />
    public partial class CreateGatheringTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Gathering",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InviteToken = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModifiedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gathering", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GatheringMember",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GatheringId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MemberId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModifiedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GatheringMember", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GatheringMember_AspNetUsers_MemberId",
                        column: x => x.MemberId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GatheringMember_Gathering_GatheringId",
                        column: x => x.GatheringId,
                        principalTable: "Gathering",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GatheringMember_GatheringId_MemberId",
                table: "GatheringMember",
                columns: new[] { "GatheringId", "MemberId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GatheringMember_MemberId",
                table: "GatheringMember",
                column: "MemberId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GatheringMember");

            migrationBuilder.DropTable(
                name: "Gathering");
        }
    }
}
