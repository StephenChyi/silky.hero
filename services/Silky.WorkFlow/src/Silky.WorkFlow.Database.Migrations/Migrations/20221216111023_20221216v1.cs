using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Silky.WorkFlow.Database.Migrations.Migrations
{
    public partial class _20221216v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActivityId",
                table: "WorkFlow");

            migrationBuilder.DropColumn(
                name: "NodeCode",
                table: "WorkFlow");

            migrationBuilder.DropColumn(
                name: "NodeType",
                table: "WorkFlow");

            migrationBuilder.DropColumn(
                name: "NodeType",
                table: "FlowNode");

            migrationBuilder.RenameColumn(
                name: "NodeName",
                table: "WorkFlow",
                newName: "FlowNodeCode");

            migrationBuilder.RenameColumn(
                name: "NextId",
                table: "WorkFlow",
                newName: "NodeTypeId");

            migrationBuilder.AddColumn<string>(
                name: "FlowNodeName",
                table: "WorkFlow",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "NodeStatus",
                table: "WorkFlow",
                type: "int",
                nullable: false,
                defaultValue: 2);

            migrationBuilder.AddColumn<long>(
                name: "NodeTypeId",
                table: "FlowNode",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

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
                name: "WorkFlowNodeActionResult",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    BusinessCode = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    WorkFlowId = table.Column<long>(type: "bigint", nullable: false),
                    FlowNodeCode = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NodeAction = table.Column<int>(type: "int", nullable: false),
                    NextFlowNodeId = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NextFlowNodeCode = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedTime = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: false),
                    UpdatedTime = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkFlowNodeActionResult", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkFlowNodeActionResult_WorkFlow_WorkFlowId",
                        column: x => x.WorkFlowId,
                        principalTable: "WorkFlow",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_WorkFlow_NodeTypeId",
                table: "WorkFlow",
                column: "NodeTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_FlowNode_NodeTypeId",
                table: "FlowNode",
                column: "NodeTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkFlowNodeActionResult_WorkFlowId",
                table: "WorkFlowNodeActionResult",
                column: "WorkFlowId");

            migrationBuilder.AddForeignKey(
                name: "FK_FlowNode_NodeType_NodeTypeId",
                table: "FlowNode",
                column: "NodeTypeId",
                principalTable: "NodeType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkFlow_NodeType_NodeTypeId",
                table: "WorkFlow",
                column: "NodeTypeId",
                principalTable: "NodeType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FlowNode_NodeType_NodeTypeId",
                table: "FlowNode");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkFlow_NodeType_NodeTypeId",
                table: "WorkFlow");

            migrationBuilder.DropTable(
                name: "NodeType");

            migrationBuilder.DropTable(
                name: "WorkFlowNodeActionResult");

            migrationBuilder.DropIndex(
                name: "IX_WorkFlow_NodeTypeId",
                table: "WorkFlow");

            migrationBuilder.DropIndex(
                name: "IX_FlowNode_NodeTypeId",
                table: "FlowNode");

            migrationBuilder.DropColumn(
                name: "FlowNodeName",
                table: "WorkFlow");

            migrationBuilder.DropColumn(
                name: "NodeStatus",
                table: "WorkFlow");

            migrationBuilder.DropColumn(
                name: "NodeTypeId",
                table: "FlowNode");

            migrationBuilder.RenameColumn(
                name: "NodeTypeId",
                table: "WorkFlow",
                newName: "NextId");

            migrationBuilder.RenameColumn(
                name: "FlowNodeCode",
                table: "WorkFlow",
                newName: "NodeName");

            migrationBuilder.AddColumn<long>(
                name: "ActivityId",
                table: "WorkFlow",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "NodeCode",
                table: "WorkFlow",
                type: "varchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "NodeType",
                table: "WorkFlow",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NodeType",
                table: "FlowNode",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
