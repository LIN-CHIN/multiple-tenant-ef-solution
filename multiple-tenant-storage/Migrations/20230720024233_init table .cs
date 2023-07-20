using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace multiple_tenant_storage.Migrations
{
    /// <inheritdoc />
    public partial class inittable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    number = table.Column<string>(type: "varchar(50)", nullable: false),
                    name = table.Column<string>(type: "varchar(50)", nullable: false),
                    connection_user_id = table.Column<string>(type: "varchar(50)", nullable: false),
                    connection_pwd = table.Column<string>(type: "varchar(50)", nullable: false),
                    is_enable = table.Column<bool>(type: "boolean", nullable: true, defaultValue: true),
                    create_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    create_user = table.Column<string>(type: "varchar(50)", nullable: false),
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
                columns: new[] { "id", "connection_pwd", "connection_user_id", "create_date", "create_user", "is_enable", "name", "number", "update_date", "update_user" },
                values: new object[,]
                {
                    { 1L, "admin", "admin", new DateTime(2023, 7, 20, 2, 42, 32, 957, DateTimeKind.Utc).AddTicks(6313), "admin", true, "管理員", "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2L, "CompanyA", "CompanyA", new DateTime(2023, 7, 20, 2, 42, 32, 957, DateTimeKind.Utc).AddTicks(6319), "admin", true, "A公司", "CompanyA", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 3L, "CompanyB", "CompanyB", new DateTime(2023, 7, 20, 2, 42, 32, 957, DateTimeKind.Utc).AddTicks(6321), "admin", true, "B公司", "CompanyB", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_tenants_number",
                schema: "app_tenant_schema",
                table: "tenants",
                column: "number",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tenants",
                schema: "app_tenant_schema");
        }
    }
}
