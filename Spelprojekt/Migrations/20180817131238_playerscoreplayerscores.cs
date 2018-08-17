using Microsoft.EntityFrameworkCore.Migrations;

namespace Spelprojekt.Migrations
{
    public partial class playerscoreplayerscores : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PlayerScores",
                columns: table => new
                {
                    PlayerId = table.Column<int>(nullable: false),
                    ScoreId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerScores", x => new { x.ScoreId, x.PlayerId });
                    table.ForeignKey(
                        name: "FK_PlayerScores_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerScores_Scores_ScoreId",
                        column: x => x.ScoreId,
                        principalTable: "Scores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Scores_PlayerId",
                table: "Scores",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerScores_PlayerId",
                table: "PlayerScores",
                column: "PlayerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Scores_Players_PlayerId",
                table: "Scores",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Scores_Players_PlayerId",
                table: "Scores");

            migrationBuilder.DropTable(
                name: "PlayerScores");

            migrationBuilder.DropIndex(
                name: "IX_Scores_PlayerId",
                table: "Scores");
        }
    }
}
