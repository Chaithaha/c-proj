using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameFinder.Migrations
{
    /// <inheritdoc />
    public partial class SeedDummyGame : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Title", "Genre", "Platform", "Rating" },
                values: new object[] { "The Legend of Zelda: Breath of the Wild", "Action-Adventure", "Nintendo Switch", 9.5 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Title",
                keyValue: "The Legend of Zelda: Breath of the Wild");
        }
    }
} 