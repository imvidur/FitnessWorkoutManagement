using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessWorkoutMgmnt.Migrations
{
    /// <inheritdoc />
    public partial class Second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FitnessClass_Users_UserId",
                table: "FitnessClass");

            migrationBuilder.AddForeignKey(
                name: "FK_FitnessClass_Users_UserId",
                table: "FitnessClass",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FitnessClass_Users_UserId",
                table: "FitnessClass");

            migrationBuilder.AddForeignKey(
                name: "FK_FitnessClass_Users_UserId",
                table: "FitnessClass",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
