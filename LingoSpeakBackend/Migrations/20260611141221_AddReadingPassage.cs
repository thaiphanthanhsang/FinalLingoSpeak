using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LingoSpeakBackend.Migrations
{
    /// <inheritdoc />
    public partial class AddReadingPassage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReadingPassageId",
                table: "Vocabularies",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ReadingPassages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TitleId = table.Column<int>(type: "int", nullable: false),
                    ContentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReadingPassages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReadingPassages_Translations_ContentId",
                        column: x => x.ContentId,
                        principalTable: "Translations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ReadingPassages_Translations_TitleId",
                        column: x => x.TitleId,
                        principalTable: "Translations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vocabularies_ReadingPassageId",
                table: "Vocabularies",
                column: "ReadingPassageId",
                unique: true,
                filter: "[ReadingPassageId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ReadingPassages_ContentId",
                table: "ReadingPassages",
                column: "ContentId");

            migrationBuilder.CreateIndex(
                name: "IX_ReadingPassages_TitleId",
                table: "ReadingPassages",
                column: "TitleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vocabularies_ReadingPassages_ReadingPassageId",
                table: "Vocabularies",
                column: "ReadingPassageId",
                principalTable: "ReadingPassages",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vocabularies_ReadingPassages_ReadingPassageId",
                table: "Vocabularies");

            migrationBuilder.DropTable(
                name: "ReadingPassages");

            migrationBuilder.DropIndex(
                name: "IX_Vocabularies_ReadingPassageId",
                table: "Vocabularies");

            migrationBuilder.DropColumn(
                name: "ReadingPassageId",
                table: "Vocabularies");
        }
    }
}
