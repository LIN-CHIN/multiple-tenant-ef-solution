﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using multiple_tenant_solution.Context;

#nullable disable

namespace multiple_tenant_solution.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230717020808_add_and_run_RLS_SP")]
    partial class add_and_run_RLS_SP
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("app_main_schema")
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("multiple_tenant_solution.Entities.Materials", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("create_date");

                    b.Property<string>("CreateUser")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasColumnName("create_user");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasColumnName("name");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasColumnName("number");

                    b.Property<string>("TenantNumber")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasColumnName("tenant_number");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("update_date");

                    b.Property<string>("UpdateUser")
                        .HasColumnType("varchar(50)")
                        .HasColumnName("update_user");

                    b.HasKey("Id");

                    b.HasIndex("Number", "TenantNumber")
                        .IsUnique();

                    b.ToTable("materials", "app_main_schema");
                });

            modelBuilder.Entity("multiple_tenant_solution.Entities.Tenants", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("ConnectionPwd")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasColumnName("connection_pwd");

                    b.Property<string>("ConnectionUserId")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasColumnName("connection_user_id");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("create_date");

                    b.Property<string>("CreateUser")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasColumnName("create_user");

                    b.Property<bool>("IsEnable")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(true)
                        .HasColumnName("is_enable");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasColumnName("name");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasColumnName("number");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("update_date");

                    b.Property<string>("UpdateUser")
                        .HasColumnType("varchar(50)")
                        .HasColumnName("update_user");

                    b.HasKey("Id");

                    b.HasIndex("Number")
                        .IsUnique();

                    b.ToTable("tenants", "app_tenant_schema");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            ConnectionPwd = "admin",
                            ConnectionUserId = "admin",
                            CreateDate = new DateTime(2023, 7, 17, 2, 8, 8, 856, DateTimeKind.Utc).AddTicks(1388),
                            CreateUser = "admin",
                            IsEnable = false,
                            Name = "管理員",
                            Number = "admin",
                            UpdateDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2L,
                            ConnectionPwd = "CompanyA",
                            ConnectionUserId = "CompanyA",
                            CreateDate = new DateTime(2023, 7, 17, 2, 8, 8, 856, DateTimeKind.Utc).AddTicks(1391),
                            CreateUser = "admin",
                            IsEnable = false,
                            Name = "A公司",
                            Number = "CompanyA",
                            UpdateDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 3L,
                            ConnectionPwd = "CompanyB",
                            ConnectionUserId = "CompanyB",
                            CreateDate = new DateTime(2023, 7, 17, 2, 8, 8, 856, DateTimeKind.Utc).AddTicks(1392),
                            CreateUser = "admin",
                            IsEnable = false,
                            Name = "B公司",
                            Number = "CompanyB",
                            UpdateDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("multiple_tenant_solution.Entities.Users", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Account")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasColumnName("account");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("create_date");

                    b.Property<string>("CreateUser")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasColumnName("create_user");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasColumnName("name");

                    b.Property<string>("Pwd")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasColumnName("pwd");

                    b.Property<string>("TenantNumber")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasColumnName("tenant_number");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("update_date");

                    b.Property<string>("UpdateUser")
                        .HasColumnType("varchar(50)")
                        .HasColumnName("update_user");

                    b.HasKey("Id");

                    b.HasIndex("Account", "TenantNumber")
                        .IsUnique();

                    b.ToTable("users", "app_main_schema");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Account = "admin",
                            CreateDate = new DateTime(2023, 7, 17, 2, 8, 8, 856, DateTimeKind.Utc).AddTicks(1411),
                            CreateUser = "admin",
                            Name = "系統管理員",
                            Pwd = "admin",
                            TenantNumber = "admin",
                            UpdateDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2L,
                            Account = "A-user",
                            CreateDate = new DateTime(2023, 7, 17, 2, 8, 8, 856, DateTimeKind.Utc).AddTicks(1413),
                            CreateUser = "admin",
                            Name = "A的一般使用者",
                            Pwd = "A-user",
                            TenantNumber = "CompanyA",
                            UpdateDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 3L,
                            Account = "B-user",
                            CreateDate = new DateTime(2023, 7, 17, 2, 8, 8, 856, DateTimeKind.Utc).AddTicks(1414),
                            CreateUser = "admin",
                            Name = "B的一般使用者",
                            Pwd = "B-user",
                            TenantNumber = "CompanyB",
                            UpdateDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
