using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LingoSpeakBackend.Migrations
{
    /// <inheritdoc />
    public partial class AddStudiedReadingPassage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StudiedReadingPassages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReadingPassageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudiedReadingPassages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudiedReadingPassages_ReadingPassages_ReadingPassageId",
                        column: x => x.ReadingPassageId,
                        principalTable: "ReadingPassages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudiedReadingPassages_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudiedReadingPassages_ReadingPassageId",
                table: "StudiedReadingPassages",
                column: "ReadingPassageId");

            migrationBuilder.CreateIndex(
                name: "IX_StudiedReadingPassages_UserId",
                table: "StudiedReadingPassages",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudiedReadingPassages");
        }
    }
}
