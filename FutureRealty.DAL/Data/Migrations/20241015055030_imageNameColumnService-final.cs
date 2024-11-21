using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FutureRealty.DAL.Data.Migrations
{
    /// <inheritdoc />
    public partial class imageNameColumnServicefinal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImgName",
                table: "Services",
                newName: "ImageName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageName",
                table: "Services",
                newName: "ImgName");
        }
    }
}
