using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Silky.WorkFlow.Database.Migrations.Migrations
{
    public partial class _20221226 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "BusinessCategory",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    BusinessCategoryCode = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BusinessCategoryName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedTime = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: false),
                    UpdatedTime = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessCategory", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "NodeType",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NodeTypeCode = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NodeTypeName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedTime = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: false),
                    UpdatedTime = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NodeType", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "FlowNode",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    BusinessCategoryCode = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FlowNodeCode = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FlowNodeName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NodeTypeId = table.Column<long>(type: "bigint", nullable: false),
                    StepNo = table.Column<int>(type: "int", nullable: false),
                    CreatedTime = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: false),
                    UpdatedTime = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlowNode", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FlowNode_NodeType_NodeTypeId",
                        column: x => x.NodeTypeId,
                        principalTable: "NodeType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "WorkFlowNode",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ProofId = table.Column<long>(type: "bigint", nullable: false),
                    BusinessCategoryCode = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FlowNodeCode = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FlowNodeName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NodeTypeId = table.Column<long>(type: "bigint", nullable: false),
                    NodeVariable = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NodeValue = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    StepNo = table.Column<int>(type: "int", nullable: false),
                    NodeStatus = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    PreviousId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedTime = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: false),
                    UpdatedTime = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkFlowNode", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkFlowNode_NodeType_NodeTypeId",
                        column: x => x.NodeTypeId,
                        principalTable: "NodeType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "NodeActionResult",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PrevFlowNodeId = table.Column<long>(type: "bigint", nullable: false),
                    NodeAction = table.Column<int>(type: "int", nullable: false),
                    BusinessCategoryCode = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FlowNodeId = table.Column<long>(type: "bigint", nullable: false, defaultValue: 1L),
                    CreatedTime = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: false),
                    UpdatedTime = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NodeActionResult", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NodeActionResult_FlowNode_FlowNodeId",
                        column: x => x.FlowNodeId,
                        principalTable: "FlowNode",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "NodeCalculation",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FlowNodeId = table.Column<long>(type: "bigint", nullable: false),
                    NodeVariable = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NodeFactor = table.Column<int>(type: "int", nullable: false),
                    NodeValue = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NodeInseries = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NodeStepNo = table.Column<int>(type: "int", nullable: false),
                    CreatedTime = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: false),
                    UpdatedTime = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NodeCalculation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NodeCalculation_FlowNode_FlowNodeId",
                        column: x => x.FlowNodeId,
                        principalTable: "FlowNode",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "WorkFlowNodeActionResult",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PrevWorkFlowNodeId = table.Column<long>(type: "bigint", nullable: false),
                    BusinessCategoryCode = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NodeAction = table.Column<int>(type: "int", nullable: false),
                    ProofId = table.Column<long>(type: "bigint", nullable: false),
                    WorkFlowNodeId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedTime = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: false),
                    UpdatedTime = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkFlowNodeActionResult", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkFlowNodeActionResult_WorkFlowNode_WorkFlowNodeId",
                        column: x => x.WorkFlowNodeId,
                        principalTable: "WorkFlowNode",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "BusinessCategory",
                columns: new[] { "Id", "BusinessCategoryCode", "BusinessCategoryName", "CreatedTime", "UpdatedTime" },
                values: new object[] { 1L, "0", "系统值", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null });

            migrationBuilder.InsertData(
                table: "NodeType",
                columns: new[] { "Id", "CreatedTime", "NodeTypeCode", "NodeTypeName", "UpdatedTime" },
                values: new object[,]
                {
                    { 1L, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "1", "系统节点", null },
                    { 2L, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "2", "计算节点", null },
                    { 3L, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "3", "审核节点", null }
                });

            migrationBuilder.InsertData(
                table: "FlowNode",
                columns: new[] { "Id", "BusinessCategoryCode", "CreatedTime", "FlowNodeCode", "FlowNodeName", "NodeTypeId", "StepNo", "UpdatedTime" },
                values: new object[] { 1L, "0", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "0", "终节点", 1L, -1, null });

            migrationBuilder.CreateIndex(
                name: "IX_FlowNode_NodeTypeId",
                table: "FlowNode",
                column: "NodeTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_NodeActionResult_FlowNodeId",
                table: "NodeActionResult",
                column: "FlowNodeId");

            migrationBuilder.CreateIndex(
                name: "IX_NodeCalculation_FlowNodeId",
                table: "NodeCalculation",
                column: "FlowNodeId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkFlowNode_NodeTypeId",
                table: "WorkFlowNode",
                column: "NodeTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkFlowNodeActionResult_WorkFlowNodeId",
                table: "WorkFlowNodeActionResult",
                column: "WorkFlowNodeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BusinessCategory");

            migrationBuilder.DropTable(
                name: "NodeActionResult");

            migrationBuilder.DropTable(
                name: "NodeCalculation");

            migrationBuilder.DropTable(
                name: "WorkFlowNodeActionResult");

            migrationBuilder.DropTable(
                name: "FlowNode");

            migrationBuilder.DropTable(
                name: "WorkFlowNode");

            migrationBuilder.DropTable(
                name: "NodeType");
        }
    }
}
