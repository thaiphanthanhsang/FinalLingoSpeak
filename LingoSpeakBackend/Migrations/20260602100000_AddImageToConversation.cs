using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LingoSpeakBackend.Migrations
{
    /// <inheritdoc />
    public partial class AddImageToConversation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Conversations",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Conversations");
        }
    }
}
