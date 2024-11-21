using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FutureRealty.DAL.Data.Migrations
{
    /// <inheritdoc />
    public partial class message1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "InWork",
                table: "ContactMessages",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InWork",
                table: "ContactMessages");
        }
    }
}
