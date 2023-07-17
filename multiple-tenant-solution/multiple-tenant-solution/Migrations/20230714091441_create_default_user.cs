using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace multiple_tenant_solution.Migrations
{
    /// <inheritdoc />
    public partial class create_default_user : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "app_tenant_schema",
                table: "tenants",
                keyColumn: "id",
                keyValue: 1L,
                column: "create_date",
                value: new DateTime(2023, 7, 14, 9, 14, 41, 78, DateTimeKind.Utc).AddTicks(7020));

            migrationBuilder.UpdateData(
                schema: "app_tenant_schema",
                table: "tenants",
                keyColumn: "id",
                keyValue: 2L,
                column: "create_date",
                value: new DateTime(2023, 7, 14, 9, 14, 41, 78, DateTimeKind.Utc).AddTicks(7025));

            migrationBuilder.UpdateData(
                schema: "app_tenant_schema",
                table: "tenants",
                keyColumn: "id",
                keyValue: 3L,
                column: "create_date",
                value: new DateTime(2023, 7, 14, 9, 14, 41, 78, DateTimeKind.Utc).AddTicks(7026));

            migrationBuilder.UpdateData(
                schema: "app_main_schema",
                table: "users",
                keyColumn: "id",
                keyValue: 1L,
                column: "create_date",
                value: new DateTime(2023, 7, 14, 9, 14, 41, 78, DateTimeKind.Utc).AddTicks(7049));

            migrationBuilder.UpdateData(
                schema: "app_main_schema",
                table: "users",
                keyColumn: "id",
                keyValue: 2L,
                column: "create_date",
                value: new DateTime(2023, 7, 14, 9, 14, 41, 78, DateTimeKind.Utc).AddTicks(7053));

            migrationBuilder.UpdateData(
                schema: "app_main_schema",
                table: "users",
                keyColumn: "id",
                keyValue: 3L,
                column: "create_date",
                value: new DateTime(2023, 7, 14, 9, 14, 41, 78, DateTimeKind.Utc).AddTicks(7054));

            CreateUser(migrationBuilder, "CompanyA");
            SettingUserRight(migrationBuilder, "CompanyA");

            CreateUser(migrationBuilder, "CompanyB");
            SettingUserRight(migrationBuilder, "CompanyB");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "app_tenant_schema",
                table: "tenants",
                keyColumn: "id",
                keyValue: 1L,
                column: "create_date",
                value: new DateTime(2023, 7, 14, 9, 13, 29, 848, DateTimeKind.Utc).AddTicks(6795));

            migrationBuilder.UpdateData(
                schema: "app_tenant_schema",
                table: "tenants",
                keyColumn: "id",
                keyValue: 2L,
                column: "create_date",
                value: new DateTime(2023, 7, 14, 9, 13, 29, 848, DateTimeKind.Utc).AddTicks(6799));

            migrationBuilder.UpdateData(
                schema: "app_tenant_schema",
                table: "tenants",
                keyColumn: "id",
                keyValue: 3L,
                column: "create_date",
                value: new DateTime(2023, 7, 14, 9, 13, 29, 848, DateTimeKind.Utc).AddTicks(6800));

            migrationBuilder.UpdateData(
                schema: "app_main_schema",
                table: "users",
                keyColumn: "id",
                keyValue: 1L,
                column: "create_date",
                value: new DateTime(2023, 7, 14, 9, 13, 29, 848, DateTimeKind.Utc).AddTicks(6856));

            migrationBuilder.UpdateData(
                schema: "app_main_schema",
                table: "users",
                keyColumn: "id",
                keyValue: 2L,
                column: "create_date",
                value: new DateTime(2023, 7, 14, 9, 13, 29, 848, DateTimeKind.Utc).AddTicks(6858));

            migrationBuilder.UpdateData(
                schema: "app_main_schema",
                table: "users",
                keyColumn: "id",
                keyValue: 3L,
                column: "create_date",
                value: new DateTime(2023, 7, 14, 9, 13, 29, 848, DateTimeKind.Utc).AddTicks(6859));
        }
        
        /// <summary>
        /// 建立DB使用者
        /// </summary>
        /// <param name="migrationBuilder"></param>
        /// <param name="user_id"></param>
        private void CreateUser(MigrationBuilder migrationBuilder, string user_id)
        {
            migrationBuilder.Sql($"CREATE USER \"" + user_id + "\" WITH PASSWORD '" + user_id + "' ;" );
        }

        /// <summary>
        /// 設定DB使用者權限
        /// </summary>
        /// <param name="migrationBuilder"></param>
        /// <param name="user_id"></param>
        private void SettingUserRight(MigrationBuilder migrationBuilder, string user_id)
        {
            migrationBuilder.Sql("GRANT CONNECT ON DATABASE myapp TO \"" + user_id + "\" ;");
            migrationBuilder.Sql("GRANT USAGE ON SCHEMA app_main_schema TO \"" + user_id + "\" ;");
            migrationBuilder.Sql("GRANT ALL ON ALL TABLES IN SCHEMA app_main_schema to \"" + user_id + "\" ;");
        }
    }
}
