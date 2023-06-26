using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace The_Book_2.Migrations
{
    /// <inheritdoc />
    public partial class addedProfileImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "ProfilePictureData",
                table: "AspNetUsers",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProfilePictureMimeType",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfilePictureData",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ProfilePictureMimeType",
                table: "AspNetUsers");
        }
    }
}
