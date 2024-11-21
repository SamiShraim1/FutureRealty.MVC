using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FutureRealty.DAL.Data.Migrations
{
    /// <inheritdoc />
    public partial class imageNameForService : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImgName",
                table: "Services",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImgName",
                table: "Services");
        }
    }
}
