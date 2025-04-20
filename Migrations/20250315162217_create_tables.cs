using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MinhaApi.Migrations
{
    /// <inheritdoc />
    public partial class create_tables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "vehicle");

            migrationBuilder.EnsureSchema(
                name: "user");

            migrationBuilder.CreateTable(
                name: "bloco",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bloco", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "color",
                schema: "vehicle",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_color", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "mark",
                schema: "vehicle",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mark", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "model",
                schema: "vehicle",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_model", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "type",
                schema: "vehicle",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_type", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "type_user",
                schema: "user",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_type_user", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "apartament",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    number = table.Column<int>(type: "integer", nullable: false),
                    bloco_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_apartament", x => x.id);
                    table.ForeignKey(
                        name: "FK_apartament_bloco_bloco_id",
                        column: x => x.bloco_id,
                        principalTable: "bloco",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user",
                schema: "user",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
                    apartment_id = table.Column<int>(type: "integer", nullable: false),
                    type_id = table.Column<int>(type: "integer", nullable: false),
                    active = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.id);
                    table.ForeignKey(
                        name: "FK_user_apartament_apartment_id",
                        column: x => x.apartment_id,
                        principalTable: "apartament",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_user_type_user_type_id",
                        column: x => x.type_id,
                        principalSchema: "user",
                        principalTable: "type_user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "vehicle",
                schema: "vehicle",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    type_id = table.Column<int>(type: "integer", nullable: false),
                    model_id = table.Column<int>(type: "integer", nullable: false),
                    mark_id = table.Column<int>(type: "integer", nullable: false),
                    color_id = table.Column<int>(type: "integer", nullable: false),
                    plate = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    user_id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vehicle", x => x.id);
                    table.ForeignKey(
                        name: "FK_vehicle_color_color_id",
                        column: x => x.color_id,
                        principalSchema: "vehicle",
                        principalTable: "color",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_vehicle_mark_mark_id",
                        column: x => x.mark_id,
                        principalSchema: "vehicle",
                        principalTable: "mark",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_vehicle_model_model_id",
                        column: x => x.model_id,
                        principalSchema: "vehicle",
                        principalTable: "model",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_vehicle_type_type_id",
                        column: x => x.type_id,
                        principalSchema: "vehicle",
                        principalTable: "type",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_vehicle_user_user_id",
                        column: x => x.user_id,
                        principalSchema: "user",
                        principalTable: "user",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_apartament_bloco_id",
                table: "apartament",
                column: "bloco_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_apartment_id",
                schema: "user",
                table: "user",
                column: "apartment_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_type_id",
                schema: "user",
                table: "user",
                column: "type_id");

            migrationBuilder.CreateIndex(
                name: "IX_vehicle_color_id",
                schema: "vehicle",
                table: "vehicle",
                column: "color_id");

            migrationBuilder.CreateIndex(
                name: "IX_vehicle_mark_id",
                schema: "vehicle",
                table: "vehicle",
                column: "mark_id");

            migrationBuilder.CreateIndex(
                name: "IX_vehicle_model_id",
                schema: "vehicle",
                table: "vehicle",
                column: "model_id");

            migrationBuilder.CreateIndex(
                name: "IX_vehicle_type_id",
                schema: "vehicle",
                table: "vehicle",
                column: "type_id");

            migrationBuilder.CreateIndex(
                name: "IX_vehicle_user_id",
                schema: "vehicle",
                table: "vehicle",
                column: "user_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "vehicle",
                schema: "vehicle");

            migrationBuilder.DropTable(
                name: "color",
                schema: "vehicle");

            migrationBuilder.DropTable(
                name: "mark",
                schema: "vehicle");

            migrationBuilder.DropTable(
                name: "model",
                schema: "vehicle");

            migrationBuilder.DropTable(
                name: "type",
                schema: "vehicle");

            migrationBuilder.DropTable(
                name: "user",
                schema: "user");

            migrationBuilder.DropTable(
                name: "apartament");

            migrationBuilder.DropTable(
                name: "type_user",
                schema: "user");

            migrationBuilder.DropTable(
                name: "bloco");
        }
    }
}
