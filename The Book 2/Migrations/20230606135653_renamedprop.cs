using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace The_Book_2.Migrations
{
    /// <inheritdoc />
    public partial class renamedprop : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ForumId",
                table: "Post",
                newName: "TopicId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TopicId",
                table: "Post",
                newName: "ForumId");
        }
    }
}
