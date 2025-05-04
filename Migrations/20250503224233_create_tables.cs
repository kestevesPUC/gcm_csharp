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
                name: "condominium");

            migrationBuilder.EnsureSchema(
                name: "vehicle");

            migrationBuilder.EnsureSchema(
                name: "called");

            migrationBuilder.EnsureSchema(
                name: "administration");

            migrationBuilder.EnsureSchema(
                name: "user");

            migrationBuilder.CreateTable(
                name: "address",
                schema: "condominium",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    country = table.Column<string>(type: "text", nullable: false),
                    state = table.Column<string>(type: "text", nullable: false),
                    city = table.Column<string>(type: "text", nullable: false),
                    postal_cod = table.Column<string>(type: "text", nullable: false),
                    number = table.Column<int>(type: "integer", nullable: false),
                    complement = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_address", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "brand",
                schema: "vehicle",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_brand", x => x.id);
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
                name: "profile",
                schema: "administration",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_profile", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "status",
                schema: "called",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    description = table.Column<string>(type: "text", nullable: false),
                    description2 = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_status", x => x.id);
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
                name: "condominium",
                schema: "condominium",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    cnpj = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    address_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_condominium", x => x.id);
                    table.ForeignKey(
                        name: "FK_condominium_address_address_id",
                        column: x => x.address_id,
                        principalSchema: "condominium",
                        principalTable: "address",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "apartament",
                schema: "condominium",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    number = table.Column<int>(type: "integer", nullable: false),
                    bloco = table.Column<int>(type: "integer", nullable: false),
                    condominium_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_apartament", x => x.id);
                    table.ForeignKey(
                        name: "FK_apartament_condominium_condominium_id",
                        column: x => x.condominium_id,
                        principalSchema: "condominium",
                        principalTable: "condominium",
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
                    email = table.Column<string>(type: "text", nullable: true),
                    password = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    apartment_id = table.Column<int>(type: "integer", nullable: false),
                    profile_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.id);
                    table.ForeignKey(
                        name: "FK_user_apartament_apartment_id",
                        column: x => x.apartment_id,
                        principalSchema: "condominium",
                        principalTable: "apartament",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_user_profile_profile_id",
                        column: x => x.profile_id,
                        principalSchema: "administration",
                        principalTable: "profile",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "called",
                schema: "called",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    applicant_id = table.Column<int>(type: "integer", nullable: false),
                    responsible_id = table.Column<int>(type: "integer", nullable: false),
                    status_id = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_called", x => x.id);
                    table.ForeignKey(
                        name: "FK_called_status_status_id",
                        column: x => x.status_id,
                        principalSchema: "called",
                        principalTable: "status",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_called_user_applicant_id",
                        column: x => x.applicant_id,
                        principalSchema: "user",
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_called_user_responsible_id",
                        column: x => x.responsible_id,
                        principalSchema: "user",
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "statement",
                schema: "user",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    description = table.Column<string>(type: "text", nullable: false),
                    date_end = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    visible = table.Column<bool>(type: "boolean", nullable: false),
                    user_id = table.Column<int>(type: "integer", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "vehicle",
                schema: "vehicle",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    type_id = table.Column<int>(type: "integer", nullable: false),
                    model_id = table.Column<int>(type: "integer", nullable: false),
                    brand_id = table.Column<int>(type: "integer", nullable: false),
                    color_id = table.Column<int>(type: "integer", nullable: false),
                    plate = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vehicle", x => x.id);
                    table.ForeignKey(
                        name: "FK_vehicle_brand_brand_id",
                        column: x => x.brand_id,
                        principalSchema: "vehicle",
                        principalTable: "brand",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_vehicle_color_color_id",
                        column: x => x.color_id,
                        principalSchema: "vehicle",
                        principalTable: "color",
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
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "occurrence",
                schema: "called",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    called_id = table.Column<int>(type: "integer", nullable: false),
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    status_id = table.Column<int>(type: "integer", nullable: false),
                    message = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_occurrence", x => x.id);
                    table.ForeignKey(
                        name: "FK_occurrence_called_called_id",
                        column: x => x.called_id,
                        principalSchema: "called",
                        principalTable: "called",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_occurrence_status_status_id",
                        column: x => x.status_id,
                        principalSchema: "called",
                        principalTable: "status",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_occurrence_user_user_id",
                        column: x => x.user_id,
                        principalSchema: "user",
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_apartament_condominium_id",
                schema: "condominium",
                table: "apartament",
                column: "condominium_id");

            migrationBuilder.CreateIndex(
                name: "IX_called_applicant_id",
                schema: "called",
                table: "called",
                column: "applicant_id");

            migrationBuilder.CreateIndex(
                name: "IX_called_responsible_id",
                schema: "called",
                table: "called",
                column: "responsible_id");

            migrationBuilder.CreateIndex(
                name: "IX_called_status_id",
                schema: "called",
                table: "called",
                column: "status_id");

            migrationBuilder.CreateIndex(
                name: "IX_condominium_address_id",
                schema: "condominium",
                table: "condominium",
                column: "address_id");

            migrationBuilder.CreateIndex(
                name: "IX_occurrence_called_id",
                schema: "called",
                table: "occurrence",
                column: "called_id");

            migrationBuilder.CreateIndex(
                name: "IX_occurrence_status_id",
                schema: "called",
                table: "occurrence",
                column: "status_id");

            migrationBuilder.CreateIndex(
                name: "IX_occurrence_user_id",
                schema: "called",
                table: "occurrence",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_statement_user_id",
                schema: "user",
                table: "statement",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_apartment_id",
                schema: "user",
                table: "user",
                column: "apartment_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_profile_id",
                schema: "user",
                table: "user",
                column: "profile_id");

            migrationBuilder.CreateIndex(
                name: "IX_vehicle_brand_id",
                schema: "vehicle",
                table: "vehicle",
                column: "brand_id");

            migrationBuilder.CreateIndex(
                name: "IX_vehicle_color_id",
                schema: "vehicle",
                table: "vehicle",
                column: "color_id");

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
                name: "occurrence",
                schema: "called");

            migrationBuilder.DropTable(
                name: "statement",
                schema: "user");

            migrationBuilder.DropTable(
                name: "vehicle",
                schema: "vehicle");

            migrationBuilder.DropTable(
                name: "called",
                schema: "called");

            migrationBuilder.DropTable(
                name: "brand",
                schema: "vehicle");

            migrationBuilder.DropTable(
                name: "color",
                schema: "vehicle");

            migrationBuilder.DropTable(
                name: "model",
                schema: "vehicle");

            migrationBuilder.DropTable(
                name: "type",
                schema: "vehicle");

            migrationBuilder.DropTable(
                name: "status",
                schema: "called");

            migrationBuilder.DropTable(
                name: "user",
                schema: "user");

            migrationBuilder.DropTable(
                name: "apartament",
                schema: "condominium");

            migrationBuilder.DropTable(
                name: "profile",
                schema: "administration");

            migrationBuilder.DropTable(
                name: "condominium",
                schema: "condominium");

            migrationBuilder.DropTable(
                name: "address",
                schema: "condominium");
        }
    }
}
