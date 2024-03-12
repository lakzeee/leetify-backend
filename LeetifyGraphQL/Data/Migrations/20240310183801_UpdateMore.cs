using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeetifyGraphQL.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateMore : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlanQuestions_Plans_PlanId",
                table: "PlanQuestions");

            migrationBuilder.DropForeignKey(
                name: "FK_Plans_Users_CreatedByUserSub",
                table: "Plans");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedByUserSub",
                table: "Plans",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<Guid>(
                name: "PlanId",
                table: "PlanQuestions",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_PlanQuestions_Plans_PlanId",
                table: "PlanQuestions",
                column: "PlanId",
                principalTable: "Plans",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Plans_Users_CreatedByUserSub",
                table: "Plans",
                column: "CreatedByUserSub",
                principalTable: "Users",
                principalColumn: "Sub");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlanQuestions_Plans_PlanId",
                table: "PlanQuestions");

            migrationBuilder.DropForeignKey(
                name: "FK_Plans_Users_CreatedByUserSub",
                table: "Plans");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedByUserSub",
                table: "Plans",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "PlanId",
                table: "PlanQuestions",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PlanQuestions_Plans_PlanId",
                table: "PlanQuestions",
                column: "PlanId",
                principalTable: "Plans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Plans_Users_CreatedByUserSub",
                table: "Plans",
                column: "CreatedByUserSub",
                principalTable: "Users",
                principalColumn: "Sub",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
