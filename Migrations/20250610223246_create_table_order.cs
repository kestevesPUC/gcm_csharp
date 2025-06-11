using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MinhaApi.Migrations
{
    /// <inheritdoc />
    public partial class create_table_order : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "photo",
                schema: "user",
                table: "user",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "photo",
                schema: "user",
                table: "user");
        }
    }
}
