using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MinhaApi.Migrations
{
    /// <inheritdoc />
    public partial class correção1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_user_apartament_apartmentid",
                schema: "user",
                table: "user");

            migrationBuilder.DropForeignKey(
                name: "FK_visit_user_userid",
                schema: "user",
                table: "visit");

            migrationBuilder.DropColumn(
                name: "apartament_id",
                schema: "user",
                table: "user");

            migrationBuilder.RenameColumn(
                name: "userid",
                schema: "user",
                table: "visit",
                newName: "user_id");

            migrationBuilder.RenameIndex(
                name: "IX_visit_userid",
                schema: "user",
                table: "visit",
                newName: "IX_visit_user_id");

            migrationBuilder.RenameColumn(
                name: "apartmentid",
                schema: "user",
                table: "user",
                newName: "apartment_id");

            migrationBuilder.RenameIndex(
                name: "IX_user_apartmentid",
                schema: "user",
                table: "user",
                newName: "IX_user_apartment_id");

            migrationBuilder.AddForeignKey(
                name: "FK_user_apartament_apartment_id",
                schema: "user",
                table: "user",
                column: "apartment_id",
                principalSchema: "condominium",
                principalTable: "apartament",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_visit_user_user_id",
                schema: "user",
                table: "visit",
                column: "user_id",
                principalSchema: "user",
                principalTable: "user",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_user_apartament_apartment_id",
                schema: "user",
                table: "user");

            migrationBuilder.DropForeignKey(
                name: "FK_visit_user_user_id",
                schema: "user",
                table: "visit");

            migrationBuilder.RenameColumn(
                name: "user_id",
                schema: "user",
                table: "visit",
                newName: "userid");

            migrationBuilder.RenameIndex(
                name: "IX_visit_user_id",
                schema: "user",
                table: "visit",
                newName: "IX_visit_userid");

            migrationBuilder.RenameColumn(
                name: "apartment_id",
                schema: "user",
                table: "user",
                newName: "apartmentid");

            migrationBuilder.RenameIndex(
                name: "IX_user_apartment_id",
                schema: "user",
                table: "user",
                newName: "IX_user_apartmentid");

            migrationBuilder.AddColumn<int>(
                name: "apartament_id",
                schema: "user",
                table: "user",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_user_apartament_apartmentid",
                schema: "user",
                table: "user",
                column: "apartmentid",
                principalSchema: "condominium",
                principalTable: "apartament",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_visit_user_userid",
                schema: "user",
                table: "visit",
                column: "userid",
                principalSchema: "user",
                principalTable: "user",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
