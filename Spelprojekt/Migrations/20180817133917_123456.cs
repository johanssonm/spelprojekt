using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Spelprojekt.Migrations
{
    public partial class _123456 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Players");

            migrationBuilder.AddColumn<int>(
                name: "IdentityId",
                table: "Players",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Identity",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Identity", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Players_IdentityId",
                table: "Players",
                column: "IdentityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Identity_IdentityId",
                table: "Players",
                column: "IdentityId",
                principalTable: "Identity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_Identity_IdentityId",
                table: "Players");

            migrationBuilder.DropTable(
                name: "Identity");

            migrationBuilder.DropIndex(
                name: "IX_Players_IdentityId",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "IdentityId",
                table: "Players");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Players",
                nullable: true);
        }
    }
}
