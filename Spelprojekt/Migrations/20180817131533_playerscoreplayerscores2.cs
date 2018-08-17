using Microsoft.EntityFrameworkCore.Migrations;

namespace Spelprojekt.Migrations
{
    public partial class playerscoreplayerscores2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Scores_Players_PlayerId",
                table: "Scores");

            migrationBuilder.DropIndex(
                name: "IX_Scores_PlayerId",
                table: "Scores");

            migrationBuilder.DropColumn(
                name: "PlayerId",
                table: "Scores");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PlayerId",
                table: "Scores",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Scores_PlayerId",
                table: "Scores",
                column: "PlayerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Scores_Players_PlayerId",
                table: "Scores",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
