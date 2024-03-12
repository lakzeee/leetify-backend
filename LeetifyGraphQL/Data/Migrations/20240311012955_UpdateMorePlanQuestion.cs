using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeetifyGraphQL.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateMorePlanQuestion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlanQuestions_Questions_QuestionId",
                table: "PlanQuestions");

            migrationBuilder.AlterColumn<int>(
                name: "QuestionId",
                table: "PlanQuestions",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "GroupName",
                table: "PlanQuestions",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddForeignKey(
                name: "FK_PlanQuestions_Questions_QuestionId",
                table: "PlanQuestions",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlanQuestions_Questions_QuestionId",
                table: "PlanQuestions");

            migrationBuilder.AlterColumn<int>(
                name: "QuestionId",
                table: "PlanQuestions",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "GroupName",
                table: "PlanQuestions",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PlanQuestions_Questions_QuestionId",
                table: "PlanQuestions",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
