using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Giftlare.Infra.DbMigrations.Migrations
{
    /// <inheritdoc />
    public partial class AlterTableExchange_AddColumnImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Exchange",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Exchange");
        }
    }
}
