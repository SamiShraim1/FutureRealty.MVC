using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FutureRealty.DAL.Data.Migrations
{
    /// <inheritdoc />
    public partial class AboutNumbers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AboutNumbers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HappyClients = table.Column<int>(type: "int", nullable: false),
                    Projects = table.Column<int>(type: "int", nullable: false),
                    HoursOfSupport = table.Column<int>(type: "int", nullable: false),
                    HardWorkers = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AboutNumbers", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AboutNumbers");
        }
    }
}
