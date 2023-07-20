using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace multiple_tenant_solution.Migrations
{
    /// <inheritdoc />
    public partial class removetenanttable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tenants",
                schema: "app_tenant_schema");

            migrationBuilder.UpdateData(
                schema: "app_main_schema",
                table: "users",
                keyColumn: "id",
                keyValue: 1L,
                column: "create_date",
                value: new DateTime(2023, 7, 20, 5, 10, 14, 708, DateTimeKind.Utc).AddTicks(6853));

            migrationBuilder.UpdateData(
                schema: "app_main_schema",
                table: "users",
                keyColumn: "id",
                keyValue: 2L,
                column: "create_date",
                value: new DateTime(2023, 7, 20, 5, 10, 14, 708, DateTimeKind.Utc).AddTicks(6857));

            migrationBuilder.UpdateData(
                schema: "app_main_schema",
                table: "users",
                keyColumn: "id",
                keyValue: 3L,
                column: "create_date",
                value: new DateTime(2023, 7, 20, 5, 10, 14, 708, DateTimeKind.Utc).AddTicks(6858));

            migrationBuilder.Sql("DROP SCHEMA IF EXISTS app_tenant_schema CASCADE;");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "app_tenant_schema");

            migrationBuilder.CreateTable(
                name: "tenants",
                schema: "app_tenant_schema",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    connection_pwd = table.Column<string>(type: "varchar(50)", nullable: false),
                    connection_user_id = table.Column<string>(type: "varchar(50)", nullable: false),
                    create_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    create_user = table.Column<string>(type: "varchar(50)", nullable: false),
                    is_enable = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    name = table.Column<string>(type: "varchar(50)", nullable: false),
                    number = table.Column<string>(type: "varchar(50)", nullable: false),
                    update_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    update_user = table.Column<string>(type: "varchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tenants", x => x.id);
                });

            migrationBuilder.InsertData(
                schema: "app_tenant_schema",
                table: "tenants",
                columns: new[] { "id", "connection_pwd", "connection_user_id", "create_date", "create_user", "name", "number", "update_date", "update_user" },
                values: new object[,]
                {
                    { 1L, "admin", "admin", new DateTime(2023, 7, 17, 2, 8, 8, 856, DateTimeKind.Utc).AddTicks(1388), "admin", "管理員", "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2L, "CompanyA", "CompanyA", new DateTime(2023, 7, 17, 2, 8, 8, 856, DateTimeKind.Utc).AddTicks(1391), "admin", "A公司", "CompanyA", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 3L, "CompanyB", "CompanyB", new DateTime(2023, 7, 17, 2, 8, 8, 856, DateTimeKind.Utc).AddTicks(1392), "admin", "B公司", "CompanyB", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null }
                });

            migrationBuilder.UpdateData(
                schema: "app_main_schema",
                table: "users",
                keyColumn: "id",
                keyValue: 1L,
                column: "create_date",
                value: new DateTime(2023, 7, 17, 2, 8, 8, 856, DateTimeKind.Utc).AddTicks(1411));

            migrationBuilder.UpdateData(
                schema: "app_main_schema",
                table: "users",
                keyColumn: "id",
                keyValue: 2L,
                column: "create_date",
                value: new DateTime(2023, 7, 17, 2, 8, 8, 856, DateTimeKind.Utc).AddTicks(1413));

            migrationBuilder.UpdateData(
                schema: "app_main_schema",
                table: "users",
                keyColumn: "id",
                keyValue: 3L,
                column: "create_date",
                value: new DateTime(2023, 7, 17, 2, 8, 8, 856, DateTimeKind.Utc).AddTicks(1414));

            migrationBuilder.CreateIndex(
                name: "IX_tenants_number",
                schema: "app_tenant_schema",
                table: "tenants",
                column: "number",
                unique: true);
        }
    }
}
