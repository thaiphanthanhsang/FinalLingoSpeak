using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LingoSpeakBackend.Migrations
{
    /// <inheritdoc />
    public partial class MergeTopicConversation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Conversations");

            migrationBuilder.DropColumn(
                name: "Topic",
                table: "Conversations");

            migrationBuilder.AddColumn<int>(
                name: "ConversationId",
                table: "Vocabularies",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vocabularies_ConversationId",
                table: "Vocabularies",
                column: "ConversationId",
                unique: true,
                filter: "[ConversationId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Vocabularies_Conversations_ConversationId",
                table: "Vocabularies",
                column: "ConversationId",
                principalTable: "Conversations",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vocabularies_Conversations_ConversationId",
                table: "Vocabularies");

            migrationBuilder.DropIndex(
                name: "IX_Vocabularies_ConversationId",
                table: "Vocabularies");

            migrationBuilder.DropColumn(
                name: "ConversationId",
                table: "Vocabularies");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Conversations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Topic",
                table: "Conversations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
