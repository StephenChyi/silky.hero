﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Silky.Permission.EntityFrameworkCore.DbContexts;

#nullable disable

namespace Silky.Permission.Database.Migrations.Migrations
{
    [DbContext(typeof(DefaultContext))]
    [Migration("20220209074209_v1.1")]
    partial class v11
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.Property<string>("Component")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)")
                        .HasColumnName("Component");

                    b.Property<long?>("CreatedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTimeOffset>("CreatedTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("CurrentActiveMenu")
                        .HasColumnType("longtext")
                        .HasColumnName("CurrentActiveMenu");

                    b.Property<long?>("DeletedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTimeOffset?>("DeletedTime")
                        .HasColumnType("datetime(6)");

                    b.Property<bool?>("Display")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("Display");

                    b.Property<bool?>("ExternalLink")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("ExternalLink");

                    b.Property<bool?>("HideBreadcrumb")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("HideBreadcrumb");

                    b.Property<string>("Icon")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)")
                        .HasColumnName("Icon");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool?>("KeepAlive")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("KeepAlive");

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

                    b.Property<int>("Type")
                        .HasColumnType("int")
                        .HasColumnName("Type");

                    b.Property<long?>("UpdatedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTimeOffset?>("UpdatedTime")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("Menus", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            CreatedTime = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            IsDeleted = false,
                            Name = "权限管理",
                            Sort = 998,
                            Status = 0,
                            Type = 0
                        },
                        new
                        {
                            Id = 2L,
                            CreatedTime = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            IsDeleted = false,
                            Name = "用户管理",
                            ParentId = 1L,
                            PermissionCode = "Identity.User",
                            Sort = 999,
                            Status = 0,
                            Type = 1
                        },
                        new
                        {
                            Id = 3L,
                            CreatedTime = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            IsDeleted = false,
                            Name = "新增",
                            ParentId = 2L,
                            PermissionCode = "Identity.User.Create",
                            Sort = 0,
                            Status = 0,
                            Type = 2
                        },
                        new
                        {
                            Id = 4L,
                            CreatedTime = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            IsDeleted = false,
                            Name = "编辑",
                            ParentId = 2L,
                            PermissionCode = "Identity.User.Update",
                            Sort = 0,
                            Status = 0,
                            Type = 2
                        },
                        new
                        {
                            Id = 5L,
                            CreatedTime = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            IsDeleted = false,
                            Name = "删除",
                            ParentId = 2L,
                            PermissionCode = "Identity.User.Delete",
                            Sort = 0,
                            Status = 0,
                            Type = 2
                        },
                        new
                        {
                            Id = 6L,
                            CreatedTime = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            IsDeleted = false,
                            Name = "锁定",
                            ParentId = 2L,
                            PermissionCode = "Identity.User.Lock",
                            Sort = 0,
                            Status = 0,
                            Type = 2
                        },
                        new
                        {
                            Id = 7L,
                            CreatedTime = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            IsDeleted = false,
                            Name = "解锁",
                            ParentId = 2L,
                            PermissionCode = "Identity.User.UnLock",
                            Sort = 0,
                            Status = 0,
                            Type = 2
                        },
                        new
                        {
                            Id = 8L,
                            CreatedTime = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            IsDeleted = false,
                            Name = "更新声明",
                            ParentId = 2L,
                            PermissionCode = "Identity.User.UpdateClaimTypes",
                            Sort = 0,
                            Status = 0,
                            Type = 2
                        },
                        new
                        {
                            Id = 9L,
                            CreatedTime = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            IsDeleted = false,
                            Name = "授权角色",
                            ParentId = 2L,
                            PermissionCode = "Identity.User.SetRoles",
                            Sort = 0,
                            Status = 0,
                            Type = 2
                        },
                        new
                        {
                            Id = 100L,
                            CreatedTime = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            IsDeleted = false,
                            Name = "机构管理",
                            ParentId = 1L,
                            PermissionCode = "Organization.Default",
                            Sort = 998,
                            Status = 0,
                            Type = 1
                        },
                        new
                        {
                            Id = 101L,
                            CreatedTime = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            IsDeleted = false,
                            Name = "新增",
                            ParentId = 100L,
                            PermissionCode = "Organization.Create",
                            Sort = 0,
                            Status = 0,
                            Type = 2
                        },
                        new
                        {
                            Id = 102L,
                            CreatedTime = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            IsDeleted = false,
                            Name = "编辑",
                            ParentId = 100L,
                            PermissionCode = "Organization.Update",
                            Sort = 0,
                            Status = 0,
                            Type = 2
                        },
                        new
                        {
                            Id = 103L,
                            CreatedTime = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            IsDeleted = false,
                            Name = "删除",
                            ParentId = 100L,
                            PermissionCode = "Organization.Delete",
                            Sort = 0,
                            Status = 0,
                            Type = 2
                        },
                        new
                        {
                            Id = 200L,
                            CreatedTime = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            IsDeleted = false,
                            Name = "职位管理",
                            ParentId = 1L,
                            PermissionCode = "Position.Default",
                            Sort = 997,
                            Status = 0,
                            Type = 1
                        },
                        new
                        {
                            Id = 201L,
                            CreatedTime = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            IsDeleted = false,
                            Name = "新增",
                            ParentId = 200L,
                            PermissionCode = "Position.Create",
                            Sort = 0,
                            Status = 0,
                            Type = 2
                        },
                        new
                        {
                            Id = 202L,
                            CreatedTime = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            IsDeleted = false,
                            Name = "编辑",
                            ParentId = 200L,
                            PermissionCode = "Position.Update",
                            Sort = 0,
                            Status = 0,
                            Type = 2
                        },
                        new
                        {
                            Id = 203L,
                            CreatedTime = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            IsDeleted = false,
                            Name = "删除",
                            ParentId = 200L,
                            PermissionCode = "Position.Delete",
                            Sort = 0,
                            Status = 0,
                            Type = 2
                        },
                        new
                        {
                            Id = 1001L,
                            CreatedTime = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            IsDeleted = false,
                            Name = "菜单管理",
                            ParentId = 1L,
                            PermissionCode = "Permission.Menu",
                            Sort = 999,
                            Status = 0,
                            Type = 1
                        },
                        new
                        {
                            Id = 1002L,
                            CreatedTime = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            IsDeleted = false,
                            Name = "新增",
                            ParentId = 1001L,
                            PermissionCode = "Permission.Menu.Create",
                            Sort = 0,
                            Status = 0,
                            Type = 2
                        },
                        new
                        {
                            Id = 1003L,
                            CreatedTime = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            IsDeleted = false,
                            Name = "编辑",
                            ParentId = 1001L,
                            PermissionCode = "Permission.Menu.Update",
                            Sort = 0,
                            Status = 0,
                            Type = 2
                        },
                        new
                        {
                            Id = 1004L,
                            CreatedTime = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            IsDeleted = false,
                            Name = "删除",
                            ParentId = 1001L,
                            PermissionCode = "Permission.MenuDelete",
                            Sort = 0,
                            Status = 0,
                            Type = 2
                        },
                        new
                        {
                            Id = 1100L,
                            CreatedTime = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            IsDeleted = false,
                            Name = "角色管理",
                            ParentId = 1L,
                            PermissionCode = "Identity.Role",
                            Sort = 998,
                            Status = 0,
                            Type = 1
                        },
                        new
                        {
                            Id = 1102L,
                            CreatedTime = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            IsDeleted = false,
                            Name = "新增",
                            ParentId = 1100L,
                            PermissionCode = "Identity.Role.Create",
                            Sort = 0,
                            Status = 0,
                            Type = 2
                        },
                        new
                        {
                            Id = 1103L,
                            CreatedTime = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            IsDeleted = false,
                            Name = "编辑",
                            ParentId = 1100L,
                            PermissionCode = "Identity.Role.Update",
                            Sort = 0,
                            Status = 0,
                            Type = 2
                        },
                        new
                        {
                            Id = 1104L,
                            CreatedTime = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            IsDeleted = false,
                            Name = "删除",
                            ParentId = 1100L,
                            PermissionCode = "Identity.Role.Delete",
                            Sort = 0,
                            Status = 0,
                            Type = 2
                        },
                        new
                        {
                            Id = 1105L,
                            CreatedTime = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            IsDeleted = false,
                            Name = "授权菜单",
                            ParentId = 1100L,
                            PermissionCode = "Identity.Role.SetMenus",
                            Sort = 0,
                            Status = 0,
                            Type = 2
                        },
                        new
                        {
                            Id = 1106L,
                            CreatedTime = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            IsDeleted = false,
                            Name = "授权数据",
                            ParentId = 1100L,
                            PermissionCode = "Identity.Role.SetMenus",
                            Sort = 0,
                            Status = 0,
                            Type = 2
                        });
                });

            modelBuilder.Entity("Silky.Permission.Domain.Menu.Menu", b =>
                {
                    b.HasOne("Silky.Permission.Domain.Menu.Menu", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("ParentId");

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("Silky.Permission.Domain.Menu.Menu", b =>
                {
                    b.Navigation("Children");
                });
#pragma warning restore 612, 618
        }
    }
}
