﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Silky.WorkFlow.EntityFrameworkCore.DbContexts;

#nullable disable

namespace Silky.WorkFlow.Database.Migrations.Migrations
{
    [DbContext(typeof(DefaultDbContext))]
    partial class DefaultDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Silky.WorkFlow.Domain.BusinessCategory", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("BusinessCategoryCode")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)")
                        .HasColumnName("BusinessCategoryCode");

                    b.Property<string>("BusinessCategoryName")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)")
                        .HasColumnName("BusinessCategoryName");

                    b.Property<DateTimeOffset>("CreatedTime")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTimeOffset?>("UpdatedTime")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("BusinessCategory", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            BusinessCategoryCode = "0",
                            BusinessCategoryName = "系统值",
                            CreatedTime = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0))
                        });
                });

            modelBuilder.Entity("Silky.WorkFlow.Domain.FlowNode", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("BusinessCategoryCode")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)")
                        .HasColumnName("BusinessCategoryCode");

                    b.Property<DateTimeOffset>("CreatedTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("FlowNodeCode")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)")
                        .HasColumnName("FlowNodeCode");

                    b.Property<string>("FlowNodeName")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)")
                        .HasColumnName("FlowNodeName");

                    b.Property<long>("NodeTypeId")
                        .HasColumnType("bigint")
                        .HasColumnName("NodeTypeId");

                    b.Property<int>("StepNo")
                        .HasColumnType("int")
                        .HasColumnName("StepNo");

                    b.Property<DateTimeOffset?>("UpdatedTime")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("NodeTypeId");

                    b.ToTable("FlowNode", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            BusinessCategoryCode = "0",
                            CreatedTime = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            FlowNodeCode = "0",
                            FlowNodeName = "终节点",
                            NodeTypeId = 1L,
                            StepNo = -1
                        });
                });

            modelBuilder.Entity("Silky.WorkFlow.Domain.NodeActionResult", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("BusinessCategoryCode")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)")
                        .HasColumnName("BusinessCategoryCode");

                    b.Property<DateTimeOffset>("CreatedTime")
                        .HasColumnType("datetime(6)");

                    b.Property<long>("FlowNodeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasDefaultValue(1L)
                        .HasColumnName("FlowNodeId");

                    b.Property<int>("NodeAction")
                        .HasColumnType("int")
                        .HasColumnName("NodeAction");

                    b.Property<long>("PrevFlowNodeId")
                        .HasColumnType("bigint")
                        .HasColumnName("PrevFlowNodeId");

                    b.Property<DateTimeOffset?>("UpdatedTime")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("FlowNodeId");

                    b.ToTable("NodeActionResult", (string)null);
                });

            modelBuilder.Entity("Silky.WorkFlow.Domain.NodeCalculation", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<DateTimeOffset>("CreatedTime")
                        .HasColumnType("datetime(6)");

                    b.Property<long>("FlowNodeId")
                        .HasColumnType("bigint");

                    b.Property<int>("NodeFactor")
                        .HasColumnType("int")
                        .HasColumnName("NodeFactor");

                    b.Property<string>("NodeInseries")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)")
                        .HasColumnName("NodeInseries");

                    b.Property<int>("NodeStepNo")
                        .HasColumnType("int")
                        .HasColumnName("NodeStepNo");

                    b.Property<string>("NodeValue")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)")
                        .HasColumnName("NodeValue");

                    b.Property<string>("NodeVariable")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)")
                        .HasColumnName("NodeVariable");

                    b.Property<DateTimeOffset?>("UpdatedTime")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("FlowNodeId");

                    b.ToTable("NodeCalculation", (string)null);
                });

            modelBuilder.Entity("Silky.WorkFlow.Domain.NodeType", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<DateTimeOffset>("CreatedTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("NodeTypeCode")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)")
                        .HasColumnName("NodeTypeCode");

                    b.Property<string>("NodeTypeName")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)")
                        .HasColumnName("NodeTypeName");

                    b.Property<DateTimeOffset?>("UpdatedTime")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("NodeType", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            CreatedTime = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            NodeTypeCode = "1",
                            NodeTypeName = "系统节点"
                        },
                        new
                        {
                            Id = 2L,
                            CreatedTime = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            NodeTypeCode = "2",
                            NodeTypeName = "计算节点"
                        },
                        new
                        {
                            Id = 3L,
                            CreatedTime = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            NodeTypeCode = "3",
                            NodeTypeName = "审核节点"
                        });
                });

            modelBuilder.Entity("Silky.WorkFlow.Domain.WorkFlowNode", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("BusinessCategoryCode")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)")
                        .HasColumnName("BusinessCategoryCode");

                    b.Property<DateTimeOffset>("CreatedTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("FlowNodeCode")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)")
                        .HasColumnName("FlowNodeCode");

                    b.Property<string>("FlowNodeName")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)")
                        .HasColumnName("FlowNodeName");

                    b.Property<int>("NodeStatus")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1)
                        .HasColumnName("NodeStatus");

                    b.Property<long>("NodeTypeId")
                        .HasColumnType("bigint")
                        .HasColumnName("NodeTypeId");

                    b.Property<string>("NodeValue")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)")
                        .HasColumnName("NodeValue");

                    b.Property<string>("NodeVariable")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)")
                        .HasColumnName("NodeVariable");

                    b.Property<long>("PreviousId")
                        .HasColumnType("bigint")
                        .HasColumnName("PreviousId");

                    b.Property<long>("ProofId")
                        .HasColumnType("bigint")
                        .HasColumnName("ProofId");

                    b.Property<int>("StepNo")
                        .HasColumnType("int")
                        .HasColumnName("StepNo");

                    b.Property<DateTimeOffset?>("UpdatedTime")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("NodeTypeId");

                    b.ToTable("WorkFlowNode", (string)null);
                });

            modelBuilder.Entity("Silky.WorkFlow.Domain.WorkFlowNodeActionResult", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("BusinessCategoryCode")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)")
                        .HasColumnName("BusinessCategoryCode");

                    b.Property<DateTimeOffset>("CreatedTime")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("NodeAction")
                        .HasColumnType("int")
                        .HasColumnName("NodeAction");

                    b.Property<long>("PrevWorkFlowNodeId")
                        .HasColumnType("bigint");

                    b.Property<long>("ProofId")
                        .HasColumnType("bigint")
                        .HasColumnName("ProofId");

                    b.Property<DateTimeOffset?>("UpdatedTime")
                        .HasColumnType("datetime(6)");

                    b.Property<long>("WorkFlowNodeId")
                        .HasColumnType("bigint")
                        .HasColumnName("WorkFlowNodeId");

                    b.HasKey("Id");

                    b.HasIndex("WorkFlowNodeId");

                    b.ToTable("WorkFlowNodeActionResult", (string)null);
                });

            modelBuilder.Entity("Silky.WorkFlow.Domain.FlowNode", b =>
                {
                    b.HasOne("Silky.WorkFlow.Domain.NodeType", "NodeType")
                        .WithMany("FlowNodes")
                        .HasForeignKey("NodeTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("NodeType");
                });

            modelBuilder.Entity("Silky.WorkFlow.Domain.NodeActionResult", b =>
                {
                    b.HasOne("Silky.WorkFlow.Domain.FlowNode", "FlowNode")
                        .WithMany("NextNodes")
                        .HasForeignKey("FlowNodeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FlowNode");
                });

            modelBuilder.Entity("Silky.WorkFlow.Domain.NodeCalculation", b =>
                {
                    b.HasOne("Silky.WorkFlow.Domain.FlowNode", "FlowNode")
                        .WithMany("NodeCalculations")
                        .HasForeignKey("FlowNodeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FlowNode");
                });

            modelBuilder.Entity("Silky.WorkFlow.Domain.WorkFlowNode", b =>
                {
                    b.HasOne("Silky.WorkFlow.Domain.NodeType", "NodeType")
                        .WithMany("WorkFlows")
                        .HasForeignKey("NodeTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("NodeType");
                });

            modelBuilder.Entity("Silky.WorkFlow.Domain.WorkFlowNodeActionResult", b =>
                {
                    b.HasOne("Silky.WorkFlow.Domain.WorkFlowNode", "WorkFlowNode")
                        .WithMany("NextFlowNodes")
                        .HasForeignKey("WorkFlowNodeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("WorkFlowNode");
                });

            modelBuilder.Entity("Silky.WorkFlow.Domain.FlowNode", b =>
                {
                    b.Navigation("NextNodes");

                    b.Navigation("NodeCalculations");
                });

            modelBuilder.Entity("Silky.WorkFlow.Domain.NodeType", b =>
                {
                    b.Navigation("FlowNodes");

                    b.Navigation("WorkFlows");
                });

            modelBuilder.Entity("Silky.WorkFlow.Domain.WorkFlowNode", b =>
                {
                    b.Navigation("NextFlowNodes");
                });
#pragma warning restore 612, 618
        }
    }
}
