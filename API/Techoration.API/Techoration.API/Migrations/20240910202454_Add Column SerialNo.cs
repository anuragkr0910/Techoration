using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Techoration.API.Migrations
{
    /// <inheritdoc />
    public partial class AddColumnSerialNo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SerialNo",
                table: "Categories",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "SerialNo",
                table: "BlogPosts",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SerialNo",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "SerialNo",
                table: "BlogPosts");
        }
    }
}
