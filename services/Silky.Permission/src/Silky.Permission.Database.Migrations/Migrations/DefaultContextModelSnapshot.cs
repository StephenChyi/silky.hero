﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Silky.Permission.EntityFrameworkCore.DbContexts;

#nullable disable

namespace Silky.Permission.Database.Migrations.Migrations
{
    [DbContext(typeof(DefaultContext))]
    partial class DefaultContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Silky.Permission.Domain.Menu.Menu", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<bool?>("Cache")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("Cache");

                    b.Property<string>("Component")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)")
                        .HasColumnName("Component");

                    b.Property<long?>("CreatedBy")
                        .HasColumnType("bigint")
                        .HasColumnName("CreatedBy");

                    b.Property<DateTimeOffset>("CreatedTime")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("CreatedTime");

                    b.Property<long?>("DeletedBy")
                        .HasColumnType("bigint")
                        .HasColumnName("DeletedBy");

                    b.Property<DateTimeOffset?>("DeletedTime")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("DeletedTime");

                    b.Property<bool?>("Display")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("Display");

                    b.Property<bool?>("ExternalLink")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("ExternalLink");

                    b.Property<string>("Icon")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)")
                        .HasColumnName("Icon");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("IsDeleted");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)")
                        .HasColumnName("Name");

                    b.Property<long?>("ParentId")
                        .HasColumnType("bigint")
                        .HasColumnName("ParentId");

                    b.Property<string>("PermissionCode")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)")
                        .HasColumnName("PermissionCode");

                    b.Property<string>("RoutePath")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)")
                        .HasColumnName("RoutePath");

                    b.Property<int>("Sort")
                        .HasColumnType("int")
                        .HasColumnName("Sort");

                    b.Property<int>("Status")
                        .HasColumnType("int")
                        .HasColumnName("Status");

                    b.Property<long?>("TenantId")
                        .HasColumnType("bigint")
                        .HasColumnName("TenantId");

                    b.Property<int>("Type")
                        .HasColumnType("int")
                        .HasColumnName("Type");

                    b.Property<long?>("UpdatedBy")
                        .HasColumnType("bigint")
                        .HasColumnName("UpdatedBy");

                    b.Property<DateTimeOffset?>("UpdatedTime")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("UpdatedTime");

                    b.HasKey("Id");

                    b.ToTable("Menus", (string)null);
                });

            modelBuilder.Entity("Silky.Permission.Domain.Permission", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)")
                        .HasColumnName("Code");

                    b.Property<long?>("CreatedBy")
                        .HasColumnType("bigint")
                        .HasColumnName("CreatedBy");

                    b.Property<DateTimeOffset>("CreatedTime")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("CreatedTime");

                    b.Property<long?>("DeletedBy")
                        .HasColumnType("bigint")
                        .HasColumnName("DeletedBy");

                    b.Property<DateTimeOffset?>("DeletedTime")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("DeletedTime");

                    b.Property<string>("HostName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)")
                        .HasColumnName("HostName");

                    b.Property<string>("HttpMethod")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)")
                        .HasColumnName("HttpMethod");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("IsDeleted");

                    b.Property<string>("Method")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)")
                        .HasColumnName("Method");

                    b.Property<string>("ServiceEntryId")
                        .HasMaxLength(512)
                        .HasColumnType("varchar(512)")
                        .HasColumnName("ServiceEntryId");

                    b.Property<string>("ServiceName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)")
                        .HasColumnName("ServiceName");

                    b.Property<long?>("TenantId")
                        .HasColumnType("bigint")
                        .HasColumnName("TenantId");

                    b.Property<long?>("UpdatedBy")
                        .HasColumnType("bigint")
                        .HasColumnName("UpdatedBy");

                    b.Property<DateTimeOffset?>("UpdatedTime")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("UpdatedTime");

                    b.Property<string>("WebApi")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)")
                        .HasColumnName("WebApi");

                    b.HasKey("Id");

                    b.ToTable("Permissions", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
