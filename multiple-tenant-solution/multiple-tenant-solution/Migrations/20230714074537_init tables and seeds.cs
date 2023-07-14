using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace multiple_tenant_solution.Migrations
{
    /// <inheritdoc />
    public partial class inittablesandseeds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "app_main_schema");

            migrationBuilder.EnsureSchema(
                name: "app_tenant_schema");

            migrationBuilder.CreateTable(
                name: "materials",
                schema: "app_main_schema",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    number = table.Column<string>(type: "varchar(50)", nullable: false),
                    name = table.Column<string>(type: "varchar(50)", nullable: false),
                    tenant_number = table.Column<string>(type: "varchar(50)", nullable: false),
                    create_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    create_user = table.Column<string>(type: "varchar(50)", nullable: false),
                    update_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    update_user = table.Column<string>(type: "varchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_materials", x => x.id);
                });

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
                    is_enable = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    create_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    create_user = table.Column<string>(type: "varchar(50)", nullable: false),
                    update_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    update_user = table.Column<string>(type: "varchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tenants", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                schema: "app_main_schema",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    account = table.Column<string>(type: "varchar(50)", nullable: false),
                    pwd = table.Column<string>(type: "varchar(50)", nullable: false),
                    name = table.Column<string>(type: "varchar(50)", nullable: false),
                    tenant_number = table.Column<string>(type: "varchar(50)", nullable: false),
                    create_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    create_user = table.Column<string>(type: "varchar(50)", nullable: false),
                    update_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    update_user = table.Column<string>(type: "varchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
                });

            migrationBuilder.InsertData(
                schema: "app_tenant_schema",
                table: "tenants",
                columns: new[] { "id", "connection_pwd", "connection_user_id", "create_date", "create_user", "name", "number", "update_date", "update_user" },
                values: new object[,]
                {
                    { 1L, "Admin", "Admin", new DateTime(2023, 7, 14, 7, 45, 37, 136, DateTimeKind.Utc).AddTicks(8221), "admin", "管理員", "Admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2L, "CompanyA", "CompanyA", new DateTime(2023, 7, 14, 7, 45, 37, 136, DateTimeKind.Utc).AddTicks(8225), "admin", "A公司", "CompanyA", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 3L, "CompanyB", "CompanyB", new DateTime(2023, 7, 14, 7, 45, 37, 136, DateTimeKind.Utc).AddTicks(8227), "admin", "B公司", "CompanyB", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null }
                });

            migrationBuilder.InsertData(
                schema: "app_main_schema",
                table: "users",
                columns: new[] { "id", "account", "create_date", "create_user", "name", "pwd", "tenant_number", "update_date", "update_user" },
                values: new object[,]
                {
                    { 1L, "admin", new DateTime(2023, 7, 14, 7, 45, 37, 136, DateTimeKind.Utc).AddTicks(8260), "admin", "系統管理員", "admin", "Admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2L, "A-user", new DateTime(2023, 7, 14, 7, 45, 37, 136, DateTimeKind.Utc).AddTicks(8262), "admin", "A的一般使用者", "A-user", "CompanyA", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 3L, "B-user", new DateTime(2023, 7, 14, 7, 45, 37, 136, DateTimeKind.Utc).AddTicks(8300), "admin", "B的一般使用者", "B-user", "CompanyB", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_materials_number_tenant_number",
                schema: "app_main_schema",
                table: "materials",
                columns: new[] { "number", "tenant_number" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tenants_number",
                schema: "app_tenant_schema",
                table: "tenants",
                column: "number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_users_account_tenant_number",
                schema: "app_main_schema",
                table: "users",
                columns: new[] { "account", "tenant_number" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "materials",
                schema: "app_main_schema");

            migrationBuilder.DropTable(
                name: "tenants",
                schema: "app_tenant_schema");

            migrationBuilder.DropTable(
                name: "users",
                schema: "app_main_schema");
        }
    }
}
