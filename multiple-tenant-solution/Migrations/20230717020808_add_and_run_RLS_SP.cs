using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace multiple_tenant_solution.Migrations
{
    /// <inheritdoc />
    public partial class add_and_run_RLS_SP : Migration
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
                value: new DateTime(2023, 7, 17, 2, 8, 8, 856, DateTimeKind.Utc).AddTicks(1388));

            migrationBuilder.UpdateData(
                schema: "app_tenant_schema",
                table: "tenants",
                keyColumn: "id",
                keyValue: 2L,
                column: "create_date",
                value: new DateTime(2023, 7, 17, 2, 8, 8, 856, DateTimeKind.Utc).AddTicks(1391));

            migrationBuilder.UpdateData(
                schema: "app_tenant_schema",
                table: "tenants",
                keyColumn: "id",
                keyValue: 3L,
                column: "create_date",
                value: new DateTime(2023, 7, 17, 2, 8, 8, 856, DateTimeKind.Utc).AddTicks(1392));

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

            CreateSPForEnableTableRLS(migrationBuilder);
            CreateSPForTenantPromission(migrationBuilder);
            ExecuteProcedure(migrationBuilder);
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
        }

        /// <summary>
        /// 建立Store Procedure 
        /// 目的: 開啟所有Table RLS
        /// </summary>
        /// <param name="migrationBuilder"></param>
        private void CreateSPForEnableTableRLS(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@" CREATE OR REPLACE PROCEDURE app_main_schema.sp_enable_table_rls()
                                    LANGUAGE 'plpgsql'
                                    AS $BODY$
	                                    declare table_list record;
	                                    declare tb_name varchar(255);
                                    BEGIN 
		                                    FOR table_list IN 
			                                    SELECT tablename
			                                    FROM pg_tables
			                                    WHERE schemaname = 'app_main_schema'
		                                    LOOP
			                                    tb_name = table_list.tablename;
			                                    EXECUTE FORMAT('ALTER Table app_main_schema.%I ENABLE ROW LEVEL SECURITY; ', tb_name); 
		                                    END loop;
                                    END
                                    $BODY$;");
        }

        /// <summary>
        /// 建立Store Procedure 
        /// 目的: 針對Tenant 開啟所有Table 的權限 
        /// </summary>
        /// <param name="migrationBuilder"></param>
        private void CreateSPForTenantPromission(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($@"CREATE OR REPLACE PROCEDURE app_main_schema.sp_alter_tenant_permission()
                                    LANGUAGE 'plpgsql'
                                    AS $BODY$
	                                    declare tenant_list record;
	                                    declare table_list record;
	                                    declare tenant_number varchar(50);
	                                    declare tb_name varchar(255);

                                    BEGIN 
	                                    FOR tenant_list IN
		                                    SELECT number
		                                    FROM app_tenant_schema.tenants  
	                                    LOOP
		                                    tenant_number = tenant_list.number;

		                                    IF(tenant_number = 'admin' ) THEN
			                                    Continue;
		                                    END IF;

		                                    -- 設定租戶對Table的權限
		                                    EXECUTE FORMAT('GRANT CONNECT ON DATABASE myapp TO %I ;', tenant_number);
		                                    EXECUTE FORMAT('GRANT USAGE ON SCHEMA app_main_schema TO %I ;', tenant_number);
		                                    EXECUTE FORMAT('GRANT ALL ON ALL TABLES IN SCHEMA app_main_schema to %I;', tenant_number);

		                                    FOR table_list IN 
			                                    SELECT tablename
			                                    FROM pg_tables
			                                    WHERE schemaname = 'app_main_schema'
		                                    LOOP
			                                    tb_name = table_list.tablename;

			                                    -- 判斷Policy是否存在，若不存在 則+上 Select Policy
			                                    IF NOT EXISTS( SELECT 1 FROM pg_policies WHERE policyname = tenant_number || '_select_' || tb_name ) THEN
				                                    IF(tb_name <> '__EFMigrationsHistory') THEN 
					                                    -- 如果是 users table 要把 系統管理員的帳號排除
					                                    IF(tb_name = 'users') THEN
						                                    EXECUTE FORMAT('CREATE policy %1$I ON app_main_schema.%2$I for select TO %3$I using(current_user=tenant_number) ;',
							                                       tenant_number || '_select_' || tb_name,
							                                       tb_name,
							                                       tenant_number ); 
					                                    ELSE 
						                                    EXECUTE FORMAT('CREATE policy %1$I ON app_main_schema.%2$I for select TO %4$I using(current_user=tenant_number or tenant_number=%3$L) ;',
							                                       tenant_number || '_select_' || tb_name,
							                                       tb_name,
							                                       'admin',
							                                       tenant_number ); 
					                                    END IF;
				                                    END if ;
			                                    END IF;

			                                    -- 判斷Policy是否存在，若不存在 則+上 Update Policy
			                                    IF NOT EXISTS( SELECT 1 FROM pg_policies WHERE policyname = tenant_number || '_update_' || tb_name ) THEN
				                                    IF(tb_name <> '__EFMigrationsHistory') then 
					                                    EXECUTE FORMAT('CREATE policy %1$I ON app_main_schema.%2$I for update TO %3$I using(current_user=tenant_number) ;',
							                                       tenant_number || '_update_' || tb_name,
							                                       tb_name,
							                                       tenant_number ); 
				                                    end if ;
			                                    END IF;

			                                    -- 判斷Policy是否存在，若不存在 則+上 Insert Policy
			                                    IF NOT EXISTS( SELECT 1 FROM pg_policies WHERE policyname = tenant_number || '_insert_' || tb_name ) THEN
				                                    IF(tb_name <> '__EFMigrationsHistory') then 
					                                    EXECUTE FORMAT('CREATE policy %1$I ON app_main_schema.%2$I for insert TO %3$I WITH CHECK(current_user=tenant_number) ;',
							                                       tenant_number || '_insert' || tb_name,
							                                       tb_name,
							                                       tenant_number ); 
				                                    end if ;
			                                    END IF;

			                                    -- 判斷Policy是否存在，若不存在 則+上 Delete Policy
			                                    IF NOT EXISTS( SELECT 1 FROM pg_policies WHERE policyname = tenant_number || '_delete_' || tb_name ) THEN
				                                    IF(tb_name <> '__EFMigrationsHistory') then 
					                                    EXECUTE FORMAT('CREATE policy %1$I ON app_main_schema.%2$I for delete TO %3$I using(current_user=tenant_number) ;',
							                                       tenant_number || '_delete' || tb_name,
							                                       tb_name,
							                                       tenant_number ); 
				                                    end if ;
			                                    END IF;
		                                    END Loop;
	                                    END loop;
                                    END
                                    $BODY$;");
        }

        /// <summary>
        /// 執行SP
        /// </summary>
        /// <param name="migrationBuilder"></param>
        private void ExecuteProcedure(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("CALL app_main_schema.sp_enable_table_rls() ;");
            migrationBuilder.Sql("CALL app_main_schema.sp_alter_tenant_permission() ;");
        }
    }
}
