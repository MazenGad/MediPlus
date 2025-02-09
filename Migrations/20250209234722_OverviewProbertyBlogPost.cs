using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MediPlus.Migrations
{
    /// <inheritdoc />
    public partial class OverviewProbertyBlogPost : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Overview",
                table: "BlogPosts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Overview",
                table: "BlogPosts");
        }
    }
}
