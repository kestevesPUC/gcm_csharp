using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MinhaApi.Migrations
{
    /// <inheritdoc />
    public partial class create_tables12 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_called_user_responsible_id",
                schema: "called",
                table: "called");

            migrationBuilder.DropForeignKey(
                name: "FK_user_apartament_apartment_id",
                schema: "user",
                table: "user");

            migrationBuilder.DropTable(
                name: "statement",
                schema: "user");

            migrationBuilder.AddColumn<string>(
                name: "photo",
                schema: "vehicle",
                table: "vehicle",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "vaga",
                schema: "vehicle",
                table: "vehicle",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "year",
                schema: "vehicle",
                table: "vehicle",
                type: "integer",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "password",
                schema: "user",
                table: "user",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<int>(
                name: "apartment_id",
                schema: "user",
                table: "user",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<string>(
                name: "cpf",
                schema: "user",
                table: "user",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "description",
                schema: "administration",
                table: "profile",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "created_at",
                schema: "called",
                table: "occurrence",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "responsible_id",
                schema: "called",
                table: "called",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<string>(
                name: "description",
                schema: "called",
                table: "called",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "title",
                schema: "called",
                table: "called",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "area",
                schema: "condominium",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_area", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "visitor",
                schema: "user",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    description = table.Column<string>(type: "text", nullable: false),
                    date_start = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    date_end = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    responsible_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_visitor", x => x.id);
                    table.ForeignKey(
                        name: "FK_visitor_user_user_id",
                        column: x => x.user_id,
                        principalSchema: "user",
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "reserve",
                schema: "condominium",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    date_start = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    date_end = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    area_id = table.Column<int>(type: "integer", nullable: false),
                    user_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reserve", x => x.id);
                    table.ForeignKey(
                        name: "FK_reserve_area_area_id",
                        column: x => x.area_id,
                        principalSchema: "condominium",
                        principalTable: "area",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_reserve_user_user_id",
                        column: x => x.user_id,
                        principalSchema: "user",
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_reserve_area_id",
                schema: "condominium",
                table: "reserve",
                column: "area_id");

            migrationBuilder.CreateIndex(
                name: "IX_reserve_user_id",
                schema: "condominium",
                table: "reserve",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_visitor_user_id",
                schema: "user",
                table: "visitor",
                column: "user_id");

            migrationBuilder.AddForeignKey(
                name: "FK_called_user_responsible_id",
                schema: "called",
                table: "called",
                column: "responsible_id",
                principalSchema: "user",
                principalTable: "user",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_user_apartament_apartment_id",
                schema: "user",
                table: "user",
                column: "apartment_id",
                principalSchema: "condominium",
                principalTable: "apartament",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_called_user_responsible_id",
                schema: "called",
                table: "called");

            migrationBuilder.DropForeignKey(
                name: "FK_user_apartament_apartment_id",
                schema: "user",
                table: "user");

            migrationBuilder.DropTable(
                name: "reserve",
                schema: "condominium");

            migrationBuilder.DropTable(
                name: "visitor",
                schema: "user");

            migrationBuilder.DropTable(
                name: "area",
                schema: "condominium");

            migrationBuilder.DropColumn(
                name: "photo",
                schema: "vehicle",
                table: "vehicle");

            migrationBuilder.DropColumn(
                name: "vaga",
                schema: "vehicle",
                table: "vehicle");

            migrationBuilder.DropColumn(
                name: "year",
                schema: "vehicle",
                table: "vehicle");

            migrationBuilder.DropColumn(
                name: "cpf",
                schema: "user",
                table: "user");

            migrationBuilder.DropColumn(
                name: "description",
                schema: "administration",
                table: "profile");

            migrationBuilder.DropColumn(
                name: "created_at",
                schema: "called",
                table: "occurrence");

            migrationBuilder.DropColumn(
                name: "description",
                schema: "called",
                table: "called");

            migrationBuilder.DropColumn(
                name: "title",
                schema: "called",
                table: "called");

            migrationBuilder.AlterColumn<string>(
                name: "password",
                schema: "user",
                table: "user",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "apartment_id",
                schema: "user",
                table: "user",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "responsible_id",
                schema: "called",
                table: "called",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "statement",
                schema: "user",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    date_end = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    visible = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_statement", x => x.id);
                    table.ForeignKey(
                        name: "FK_statement_user_user_id",
                        column: x => x.user_id,
                        principalSchema: "user",
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_statement_user_id",
                schema: "user",
                table: "statement",
                column: "user_id");

            migrationBuilder.AddForeignKey(
                name: "FK_called_user_responsible_id",
                schema: "called",
                table: "called",
                column: "responsible_id",
                principalSchema: "user",
                principalTable: "user",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_user_apartament_apartment_id",
                schema: "user",
                table: "user",
                column: "apartment_id",
                principalSchema: "condominium",
                principalTable: "apartament",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
